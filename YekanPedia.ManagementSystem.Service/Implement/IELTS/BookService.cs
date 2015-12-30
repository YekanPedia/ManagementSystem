namespace YekanPedia.ManagementSystem.Service.Implement
{
    using System.Collections.Generic;
    using Interfaces;
    using Domain.Entity;
    using System.Linq;
    using Data.Context;
    using System.Data.Entity;
    using InfraStructure;
    using Properties;

    public class BookService : IBookService
    {
        readonly IUnitOfWork _uow;
        readonly IDbSet<Book> _book;
        public BookService(IUnitOfWork uow)
        {
            _uow = uow;
            _book = uow.Set<Book>();
        }

        public IEnumerable<Book> GetValidBook()
        {
            return _book.Where(X => X.IsActive == true).AsNoTracking().ToList();
        }
        public IEnumerable<Book> GetAllBook()
        {
            return _book.AsNoTracking().ToList();
        }
        public IServiceResults<bool> ChangeBookStatus(int id, bool status)
        {
            var result = FindBook(id);
            if (result != null)
            {
                result.IsActive = status;
                var saveResult = _uow.SaveChanges();
                return new ServiceResults<bool>()
                {
                    IsSuccessfull = saveResult.ToBool(),
                    Message = saveResult.ToMessage(BusinessMessage.Error),
                    Result = saveResult.ToBool()
                };
            }
            return new ServiceResults<bool>()
            {
                IsSuccessfull = false,
                Message = BusinessMessage.RecordNotExist,
                Result = false
            };
        }
        public Book FindBook(int id)
        {
            return _book.Find(id);
        }
        public IServiceResults<int> AddBook(string type)
        {
            _book.Add(new Book()
            {
                Type = type,
                IsActive = true
            });
            var result = _uow.SaveChanges();
            return new ServiceResults<int>()
            {
                IsSuccessfull = result.ToBool(),
                Message = result.ToMessage(BusinessMessage.Error),
                Result = result
            };
        }
    }
}
