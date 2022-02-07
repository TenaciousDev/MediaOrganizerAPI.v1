using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Models.MediaObjectModels
{
  public class MediaObjectCreate
  {
    [Required]
    public int MediaTypeId { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }

  }
}