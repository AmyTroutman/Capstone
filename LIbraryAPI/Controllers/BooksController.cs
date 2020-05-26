using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.ApiModels;
using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allBooks = _bookService.GetAll().ToList();
                return Ok(allBooks.ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Getbooks", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/values/5
        //Same as above
        //[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var book = _bookService.Get(id);
                if (book == null) return NotFound();
                return Ok(book.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetBook", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/author/{authorId}/books
        [HttpGet("/api/authors/{authorId}/books")]
        public IActionResult GetBooksForAuthor(int authorId)
        {
            var bookModels = _bookService
                .GetBooksForAuthor(authorId)
                .ToApiModels();

            return Ok(bookModels);
        }

        // GET api/series/{seriesId}/books
        [HttpGet("/api/series/{seriesId}/books")]
        public IActionResult GetBooksForSeries(int seriesId)
        {
            var bookModels = _bookService
                .GetBooksForSeries(seriesId)
                .ToApiModels();

            return Ok(bookModels);
        }

        // GET api/catalogs/{catalogId}/books
        [HttpGet("/api/catalogs/{catalogId}/books")]
        public IActionResult GetBooksForCatalog(int catalogId)
        {
            var bookModels = _bookService
                .GetBooksForCatalog(catalogId)
                .ToApiModels();

            return Ok(bookModels);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] BookModel bookModel)
        {
            try
            {
                var savedBook= _bookService.Add(bookModel.ToDomainModel());
                //return Ok(_bookService.Add(book).ToApiModel());
                return CreatedAtAction("Get", new { savedBook.Id }, savedBook.ToApiModel());

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddBook", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookModel book)
        {
            try
            {
                var updatedBook = _bookService.Update(book.ToDomainModel());
                return Ok(updatedBook.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateBook", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteBook", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}