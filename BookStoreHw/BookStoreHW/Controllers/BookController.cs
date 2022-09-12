using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookStoreHW;

namespace BookController.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
             
        private static List<Book> BookList =new List<Book>()
            {
                new Book{
                    Id = 1 ,
                    Title = "Matematik Ders Kitabı 7",
                    GenreId=1, //Ders Kitabı
                    PageCount = 200,
                    PublishDate = new System.DateTime(2021,01,01)

                },
                new Book{
                    Id = 2,
                    Title = "Matematik Soru Kitabı 7",
                    GenreId=2, //Soru Kitabı
                    PageCount = 250,
                    PublishDate = new System.DateTime(2021,01,01)

                },
                new Book{
                    Id = 3,
                    Title = "Matematik Etkinlik Kitabı 7",
                    GenreId=3, //Etkinlik Kitabı
                    PageCount = 540,
                    PublishDate = new System.DateTime(2001,12,21)

                }
            };
        
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList= BookList.OrderBy(x=> x.Id).ToList<Book>();
            return bookList;
        }
        
        [HttpGet("{id}")]
          public Book GetByID(int id)
        {
            var book= BookList.Where(book=> book.Id == id).SingleOrDefault();
            return book;
        }
        /*
         [HttpGet]
          public Book Get([FromQuery] string id)
        {
            var book= BookList.Where(book=> book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        } 
        */

        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book =BookList.SingleOrDefault(x=> x.Title == newBook.Title);
            if(book is not null)
                return BadRequest();

            BookList.Add(newBook);
            //BookList.SaveChanges();
            return Ok();
        }
        /*
        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook( int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();
            
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            //BookList.SaveChanges();
            return Ok();
        } */
        
        //Delete

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x=> x.Id == id);
            if(book is null)
                return BadRequest();
            
            BookList.Remove(book);
            //_context.SaveChanges();
            return Ok();
        }
       
        
    }
}
