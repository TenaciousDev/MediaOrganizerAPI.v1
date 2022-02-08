using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Models.MediaTypeModels;
using MediaOrganizer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaOrganizer.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MediaTypeController : ControllerBase
  {
    private readonly IMediaService _service;
    public MediaTypeController(IMediaService service)
    {
      _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MediaTypeCreate request)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      if (!await _service.CreateAsync<MediaTypeCreate>(request)) return BadRequest("Unable to create entity.");

      return Ok("Entity created.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var mediaTypes = await _service.GetAllAsync<MediaTypeListItem>();
      return Ok(mediaTypes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var detail = await _service.GetByIdAsync<MediaTypeDetail>(id);
      return detail is not null ? Ok(detail) : NotFound($"Entity with id {id} not found.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MediaTypeEdit model)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      return await _service.UpdateAsync<MediaTypeEdit>(id, model) ? Ok("Entity updated.") : BadRequest("Unable to update entity.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      return await _service.DeleteAsync(id) ? Ok($"Entity with id {id} deleted.") : BadRequest($"Entithy with id {id} could not be deleted.");
    }
  }
}