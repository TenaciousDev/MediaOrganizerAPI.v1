using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Models.MediaTypeModels
{
  public class MediaTypeCreate
  {
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
  }
}