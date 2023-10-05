using _16_API_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _16_API_Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class HomeController : Controller
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
        //Endpoints(uç nokta)
        [HttpGet]
        public List<Book> Books()
        {
            var bookList = BookList.OrderBy(x=>x.Id).ToList();
            return bookList;
        }
    }
}
