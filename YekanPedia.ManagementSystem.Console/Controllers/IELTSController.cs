namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using System.Linq;
    using InfraStructure.Extension.Authentication;
    using Domain.Entity;
    using System.Web;
    using ExternalService.Interfaces;
    using ExternalService.FilesProxy;
    using System.IO;
    using System;
    using Resources;

    public partial class IELTSController : Controller
    {
        #region Constructur

        readonly IIeltsMaterialService _ieltsMaterialService;
        readonly ITopicService _topicService;
        readonly IFilesProxyAdapter _filesProxyAdapter;
        public IELTSController(IIeltsMaterialService ieltsMaterialService,
            ITopicService topicService,
            IFilesProxyAdapter filesProxyAdapter)
        {
            _topicService = topicService;
            _ieltsMaterialService = ieltsMaterialService;
            _filesProxyAdapter = filesProxyAdapter;
        }
        #endregion

        [HttpGet]
        public virtual JsonResult GetUserInfoByIeltsFile(Guid ieltsMaterialId)
        {
            return Json(_ieltsMaterialService.GetUserInfoByIeltsFile(ieltsMaterialId), JsonRequestBehavior.AllowGet);
        }
        [NonAction]
        private void SetDropDownlist()
        {
            #region book
            var Topic = _topicService.GetAllTopic();
            ViewBag.Topic = Topic.Select(x => new SelectListItem()
            {
                Text = x.TopicCode.ToString(),
                Value = x.TopicId.ToString()
            });
            #endregion

        }

        [HttpGet]
        public virtual ViewResult SendWrittingFile()
        {
            SetDropDownlist();
            return View(new IeltsMaterial { UserId = (User as ICurrentUserPrincipal).UserId });
        }

        [ChildActionOnly]
        public virtual PartialViewResult UserFilesList()
        {
            return PartialView(MVC.IELTS.Views.Partial._UserFilesList, _ieltsMaterialService.UserFilesList((User as ICurrentUserPrincipal).UserId));
        }

        [HttpPost]
        public virtual ActionResult SendWrittingFile(IeltsMaterial model, HttpPostedFileBase file)
        {
            model.IeltsMaterialId = Guid.NewGuid();
            if (!ModelState.IsValid)
            {
                SetDropDownlist();
                return View(model);
            }
            if (file == null)
            {
                SetDropDownlist();
                ModelState.AddModelError(nameof(model.File), LocalMessage.PleaseSelectFile);
                return View(model);
            }
            model.Rebind();
            #region SaveFile

            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            var url = _filesProxyAdapter.UploadDocument(new PostedFile
            {
                Content = fileData,
                FileName = $"{model.IeltsMaterialId}.{file.FileName.Split('.')[1]}"
            });
            if (string.IsNullOrEmpty(url.DirectLink))
            {
                SetDropDownlist();
                ModelState.AddModelError(nameof(model.File), LocalMessage.Error);
                return View(model);
            }
            #endregion
            #region SaveRecord
            model.File = url.DirectLink;
            model.Path = url.Extension;
            var insertResult = _ieltsMaterialService.Add(model);
            if (!insertResult.IsSuccessfull)
            {
                this.NotificationController().Notify(insertResult.Message, NotificationStatus.Error);
                _filesProxyAdapter.Delete(url.Extension);
            }
            #endregion
            return RedirectToAction(MVC.IELTS.ActionNames.SendWrittingFile, MVC.IELTS.Name);
        }

        #region Delete
        [HttpPost]
        public virtual JsonResult Delete(Guid ieltsMaterialId, string path)
        {
            var result = _ieltsMaterialService.Delete(ieltsMaterialId);
            if (result.IsSuccessfull)
            {
                _filesProxyAdapter.Delete(path);
            }
            return Json(result);
        }
        #endregion

        #region SendFeedback
        [HttpGet]
        public virtual ViewResult SendFeedback()
        {
            return View(_ieltsMaterialService.GetNewFiles());
        }

        [HttpPost]
        public virtual ActionResult SendFeedback(string data)
        {
            var Id = Guid.Parse(Request.Form.AllKeys[0]);
            var score = float.Parse(Request.Form[0]);
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(fileContent.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(fileContent.ContentLength);
                        }
                        return Json(_ieltsMaterialService.Complete(Id, score, fileData, fileContent.FileName.Split('.')[1]));
                    }
                }
                return Json(new
                {
                    IsSuccessfull = false,
                    Message = "NO Files!",
                    Result = Id.ToString()
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    IsSuccessfull = false,
                    Message = e.Message,
                    Result = Id.ToString()
                });
            }
        }
        #endregion

        [HttpGet]
        public virtual PartialViewResult GetTopic(int topicId)
        {
            return PartialView(MVC.IELTS.Views.Partial._Topic,_topicService.Find(topicId));
        }
    }
}