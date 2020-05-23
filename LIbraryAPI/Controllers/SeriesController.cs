using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.ApiModels;
using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        //GET: api/Series
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allSeries = _seriesService.GetAll().ToList();
                return Ok(allSeries.ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetSeries", ex.Message);
                return BadRequest(ModelState);
            }
        }

        //GET: api/Series/4
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var series = _seriesService.Get(id);
                if (series == null) return NotFound();
                return Ok(series.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetSeries", ex.Message);
                return BadRequest(ModelState);
            }
        }

        //POST: api/Series
        [HttpPost]
        public IActionResult Post([FromBody] Series series)
        {
            try
            {
                return Ok(_seriesService.Add(series).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("AddSeries", ex.Message);
                return BadRequest(ModelState);
            }
        }

        //PUT: api/Series/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Series series)
        {
            try
            {
                return Ok(_seriesService.Update(series).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateSeries", ex.Message);
                return BadRequest(ModelState);
            }
        }

        //DELETE: api/Series/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _seriesService.Remove(id);
                return Ok();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeleteSeries", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}