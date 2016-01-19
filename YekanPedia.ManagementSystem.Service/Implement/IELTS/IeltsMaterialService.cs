
namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using Data.Context;
    using System.Data.Entity;
    using System.Linq;
    using InfraStructure;
    using Properties;
    using InfraStructure.Date;
    using ExternalService.Interfaces;
    using ExternalService.FilesProxy;

    public class IeltsMaterialService : IIeltsMaterialService
    {
        readonly IUnitOfWork _uow;
        readonly IDbSet<IeltsMaterial> _IeltsMaterial;
        readonly Lazy<INotificationService> _notificationService;
        readonly Lazy<IFilesProxyAdapter> _filesProxyAdapter;
        public IeltsMaterialService(IUnitOfWork uow, Lazy<INotificationService> notificationService, Lazy<IFilesProxyAdapter> filesProxyAdapter)
        {
            _uow = uow;
            _IeltsMaterial = uow.Set<IeltsMaterial>();
            _notificationService = notificationService;
            _filesProxyAdapter = filesProxyAdapter;
        }

        public IEnumerable<IeltsMaterial> UserFilesList(Guid userId)
        {
            return _IeltsMaterial.Where(X => X.UserId == userId)
                .Include(X => X.Topic.ExamType)
                .Include(X => X.Topic.Book)
                .Include(X => X.User)
                .AsNoTracking()
                .ToList();
        }

        public IServiceResults<Guid> Add(IeltsMaterial model)
        {
            _IeltsMaterial.Add(model);
            var result = _uow.SaveChanges();
            return new ServiceResults<Guid>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = model.IeltsMaterialId
            };
        }

        public IeltsMaterial Find(Guid ieltsMaterialId)
        {
            return _IeltsMaterial.Find(ieltsMaterialId);
        }

        public IServiceResults<bool> Delete(Guid ieltsMaterialId)
        {
            var record = Find(ieltsMaterialId);
            if (record.IsComplete)
                return new ServiceResults<bool>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.NotAuthorizeForDelete,
                    Result = false
                };
            _IeltsMaterial.Remove(record);
            var result = _uow.SaveChanges();
            return new ServiceResults<bool>
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result.ToBool()
            };
        }

        public IEnumerable<IeltsMaterial> GetNewFiles()
        {
            return _IeltsMaterial.Where(X => !X.IsComplete)
               .Include(X => X.Topic.ExamType)
               .Include(X => X.Topic.Book)
              .Include(X => X.User)
              .AsNoTracking()
              .ToList();
        }

        public IServiceResults<Guid> Complete(Guid ieltsMaterialId, float score, byte[] fileData, string extensionFile)
        {
            var record = Find(ieltsMaterialId);
            if (record == null)
                return new ServiceResults<Guid>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.RecordNotExist,
                    Result = ieltsMaterialId
                };
            var overrid = _filesProxyAdapter.Value.OverrideDocument(new PostedFile
            {
                Content = fileData,
                FileName = $"{ieltsMaterialId.ToString()}.{extensionFile}"
            }, record.Path);

            if (!overrid)
                return new ServiceResults<Guid>
                {
                    IsSuccessfull = false,
                    Message = BusinessMessage.Error,
                    Result = ieltsMaterialId
                };

            record.IsComplete = true;
            record.Score = score;
            record.SendFeedbackDateMi = DateTime.Now;
            record.SendFeedbackDateSh = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date);
            var result = _uow.SaveChanges();
            if (result.ToBool())
            {
                _notificationService.Value.SendNotificationToUser(record.UserId,
                    NotificationType.PrivateMessage,
                    BusinessMessage.SendFeedbackFiles + record.File);
            }
            return new ServiceResults<Guid>
            {
                IsSuccessfull = result.ToBool(),
                Message = record.Path.ToString(),
                Result = ieltsMaterialId
            };
        }

        public IEnumerable<IeltsMaterial> GetTodayCompleteFiles()
        {
            return _IeltsMaterial.Where(X => X.SendFeedbackDateMi == DateTime.Now)
               .Include(X => X.Topic.ExamType)
               .Include(X => X.Topic.Book)
              .Include(X => X.User)
              .AsNoTracking()
              .ToList();
        }

        public IeltsMaterial GetUserInfoByIeltsFile(Guid ieltsMaterialId)
        {
            var file = _IeltsMaterial.Where(X => X.IeltsMaterialId == ieltsMaterialId)
              .Include(X => X.Topic)
              .Include(X => X.Topic.Book)
              .Include(X => X.Topic.ExamType)
              .Include(X => X.User)
              .AsNoTracking()
              .FirstOrDefault();

            if (file == null)
                return null;
            return new IeltsMaterial
            {
                User = new User
                {
                    FullName = file.User.FullName,
                    Picture = file.User.Picture.Replace("{size}", "48")
                },
                Path = file.Path,
                Topic = new Topic { TopicCode = file.Topic.TopicCode, Book = new Book { Type = file.Topic.Book.Type }, ExamType = new ExamType { Type = file.Topic.ExamType.Type } },
                IeltsMaterialId = file.IeltsMaterialId
            };
        }
    }
}
