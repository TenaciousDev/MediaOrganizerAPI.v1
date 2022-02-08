using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
  }
}