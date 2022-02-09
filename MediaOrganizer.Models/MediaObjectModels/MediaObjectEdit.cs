using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Models.MediaObjectModels
{
  public class MediaObjectEdit
  {
    public int MediaTypeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
  }
}