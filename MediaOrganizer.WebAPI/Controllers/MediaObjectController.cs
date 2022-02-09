using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Models.MediaObjectModels;
using MediaOrganizer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaOrganizer.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MediaObjectController : ControllerBase
  {
    private IMediaService _service;
    public MediaObjectController(ServiceResolver serviceAccessor)
    {
      _service = serviceAccessor(nameof(MediaObjectService));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MediaObjectCreate request)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      if (!await _service.CreateAsync<MediaObjectCreate>(request)) return BadRequest("Unable to create entity.");

      return Ok("Entity created.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var mediaTypes = await _service.GetAllAsync<MediaObjectListItem>();
      return Ok(mediaTypes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var detail = await _service.GetByIdAsync<MediaObjectDetail>(id);
      return detail is not null ? Ok(detail) : NotFound($"Entity with id {id} not found.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MediaObjectEdit model)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      return await _service.UpdateAsync<MediaObjectEdit>(id, model) ? Ok("Entity updated.") : BadRequest("Unable to update entity.");
    }

    [HttpPatch("{objectId}/assignTo/{catalogId}")]
    public async Task<IActionResult> Assign([FromRoute] int objectId, [FromRoute] int catalogId)
    {
      return await _service.Assign(objectId, catalogId) ? Ok("Assignment successful.") : BadRequest("Unable to assign.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      return await _service.DeleteAsync(id) ? Ok($"Entity with id {id} deleted.") : BadRequest($"Entity with id {id} could not be deleted.");
    }
  }
}