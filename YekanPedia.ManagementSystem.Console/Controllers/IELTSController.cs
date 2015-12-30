namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;
    using System.Linq;
    using Extensions.Authentication;
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
        readonly IBookService _bookService;
        readonly IExamTypeService _examTypeService;
        readonly IIeltsMaterialService _ieltsMaterialService;
        readonly IFilesProxyAdapter _filesProxyAdapter;
        public IELTSController(IIeltsMaterialService ieltsMaterialService, IBookService bookService, IExamTypeService examTypeService, IFilesProxyAdapter filesProxyAdapter)
        {
            _examTypeService = examTypeService;
            _bookService = bookService;
            _ieltsMaterialService = ieltsMaterialService;
            _filesProxyAdapter = filesProxyAdapter;
        }

        #endregion

        [NonAction]
        private void SetDropDownlist()
        {
            #region book
            var book = _bookService.GetValidBook();
            ViewBag.Book = book.Select(x => new SelectListItem()
            {
                Text = x.Type.ToString(),
                Value = x.BookId.ToString()
            });
            #endregion
            #region examType
            var examType = _examTypeService.GetValidExamType();
            ViewBag.ExamType = examType.Select(x => new SelectListItem()
            {
                Text = x.Type.ToString(),
                Value = x.ExamTypeId.ToString()
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
    }
}