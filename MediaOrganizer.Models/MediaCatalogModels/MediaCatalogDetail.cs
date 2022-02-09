using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Data.Entities;

namespace MediaOrganizer.Models.MediaCatalogModels
{
  public class MediaCatalogDetail
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<MediaObject> Members { get; set; } = new List<MediaObject>();
  }
}