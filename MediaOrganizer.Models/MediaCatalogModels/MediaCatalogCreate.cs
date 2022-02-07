using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Models.MediaCatalogModels
{
  public class MediaCatalogCreate
  {
    [Required]
    public string Title { get; set; }
    [Required(ErrorMessage = "A catalog requires a description.")]
    public string Description { get; set; }
  }
}