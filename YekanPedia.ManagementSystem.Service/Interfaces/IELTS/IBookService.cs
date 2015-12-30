namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using Domain.Entity;
    using System.Collections.Generic;
    using InfraStructure;

    public interface IBookService
    {
        IEnumerable<Book> GetValidBook();
        IEnumerable<Book> GetAllBook();
        IServiceResults<bool> ChangeBookStatus(int id, bool status);
        Book FindBook(int id);
        IServiceResults<int> AddBook(string type);
    }
}
