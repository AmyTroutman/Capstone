using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryApp.ApiModels;
using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogsController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        private string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

        // GET api/values
        //uncomment below if you want to allow other users to see all users' catalogs
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allCat = _catalogService.GetAll().ToApiModels();
                return Ok(allCat);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetCatalogs", ex.Message);
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
                var catalog = _catalogService.Get(id);
                if (catalog == null) return null;
                return Ok(catalog.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetCatalog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CatalogModel catalog)
        {
            try
            {
                //catalog.UserId = CurrentUserId;
                var newCatalog = _catalogService.Add(catalog.ToDomainModel());
                return CreatedAtAction("Get", new { newCatalog.Id }, newCatalog.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddCatalog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Catalog catalog)
        {
            try
            {
                return Ok(_catalogService.Update(catalog).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateCatalog", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _catalogService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteCatalog", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
