namespace YekanPedia.ManagementSystem.Console.Controllers
{
    using System.Web.Mvc;
    using Service.Interfaces;

    public partial class BookController : Controller
    {
        #region Constructure
        private readonly IBookService _bookService;
        public BookController(IBookService BookService)
        {
            _bookService = BookService;
        }
        #endregion

        [ChildActionOnly]
        public virtual PartialViewResult GetBook()
        {
            return PartialView(MVC.Book.Views.Partial._Book, _bookService.GetAllBook());
        }

        [HttpPost]
        public virtual JsonResult ChangeBookStatus(int id, bool status)
        {
            return Json(_bookService.ChangeBookStatus(id, status));
        }
        [HttpPost]
        public virtual JsonResult AddBook(string text)
        {
            return Json(_bookService.AddBook(text));
        }
    }
}