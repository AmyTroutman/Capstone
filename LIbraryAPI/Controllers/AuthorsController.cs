using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.ApiModels;
using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService);

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allAuthors = _authorService.GetAll().ToList();
                return Ok(allAuthors.ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAuthors", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var author = _authorService.Get(id);
                if (author == null) return NotFound();
                return Ok(author.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAuthor", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST: api/Authors
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            try
            {
                return Ok(_authorService.Add(author).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("AddAuthor", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            try
            {
                return Ok(_authorService.Update(author).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateAuthor", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _authorService.Remove(id);
                return Ok();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeleteAuthor", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
