using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Data.Entities;
using MediaOrganizer.Models.MediaObjectModels;

namespace MediaOrganizer.Models.MediaCatalogModels
{
  public class MediaCatalogDetail
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<MediaObjectListItem> Members { get; set; } = new List<MediaObjectListItem>();
  }
}