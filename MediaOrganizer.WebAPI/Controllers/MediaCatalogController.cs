using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Models.MediaCatalogModels;
using MediaOrganizer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaOrganizer.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MediaCatalogController : ControllerBase
  {
    private IMediaService _service;
    public MediaCatalogController(ServiceResolver serviceAccessor)
    {
      _service = serviceAccessor(nameof(MediaCatalogService));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MediaCatalogCreate request)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      if (!await _service.CreateAsync<MediaCatalogCreate>(request)) return BadRequest("Unable to create entity.");

      return Ok("Entity created.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var mediaTypes = await _service.GetAllAsync<MediaCatalogListItem>();
      return Ok(mediaTypes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var detail = await _service.GetByIdAsync<MediaCatalogDetail>(id);
      return detail is not null ? Ok(detail) : NotFound($"Entity with id {id} not found.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MediaCatalogEdit model)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      return await _service.UpdateAsync<MediaCatalogEdit>(id, model) ? Ok("Entity updated.") : BadRequest("Unable to update entity.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      return await _service.DeleteAsync(id) ? Ok($"Entity with id {id} deleted.") : BadRequest($"Entithy with id {id} could not be deleted.");
    }
  }
}