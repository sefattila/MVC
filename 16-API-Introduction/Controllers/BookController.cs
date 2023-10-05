using _16_API_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _16_API_Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]s/[action]")] //--> api/books/books
    public class BookController : Controller
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book{Id=1,Title="Kitap-1",GenreId=1,PageCount=200,PublishDate=new DateTime(1999,01,22)},
            new Book{Id=2,Title="Kitap-2",GenreId=1,PageCount=100,PublishDate=new DateTime(1998,06,04)},
            new Book{Id=3,Title="Kitap-3",GenreId=1,PageCount=196,PublishDate=new DateTime(1700,01,22)},
            new Book{Id=4,Title="Kitap-4",GenreId=2,PageCount=321,PublishDate=new DateTime(1500,01,22)},
            new Book{Id=5,Title="Kitap-5",GenreId=2,PageCount=123,PublishDate=new DateTime(2003,03,19)},
            new Book{Id=6,Title="Kitap-6",GenreId=2,PageCount=258,PublishDate=new DateTime(2000,01,22)},
            new Book{Id=7,Title="Kitap-7",GenreId=2,PageCount=456,PublishDate=new DateTime(1888,01,22)},
            new Book{Id=8,Title="Kitap-8",GenreId=2,PageCount=654,PublishDate=new DateTime(2012,01,22)},
        };

        //Api metotlarda
        /*
         * Void, Primitive(ilkel) tip veya complex tip
         * HttpResponseMessage
         * IActionResult
         */

        [HttpGet]
        public List<Book> Books()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList();
            return bookList;
        }
        //[HttpGet("Id")]
        //public Book BookById(int id)
        //{
        //    var book=BookList.SingleOrDefault(x=>x.Id==id);
        //    return book;
        //}

        [HttpGet]
        public Book BookById([FromQuery] string id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == Convert.ToInt32(id));
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if(book is not null)
            {
                return BadRequest();
            }
            else
            {
                BookList.Add(newBook);
                return Ok();
            }
        }

        [HttpPut("Id")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
        {
            var book=BookList.SingleOrDefault(x=>x.Id==id);
            if(book is null)
            {
                return BadRequest();
            }
            else
            {
                book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
                book.PageCount= updateBook.PageCount != default ? updateBook.PageCount:book.PageCount;
                book.PublishDate=updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
                book.Title=updateBook.Title != "string" ? updateBook.Title : book.Title;
                return Ok();
            }
        }

        [HttpDelete("id")]
        public void DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            BookList.Remove(book);
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if(book == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
        }
    }
}
