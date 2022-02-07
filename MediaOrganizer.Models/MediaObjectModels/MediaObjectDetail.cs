using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Data.Entities;

namespace MediaOrganizer.Models.MediaObjectModels
{
  public class MediaObjectDetail
  {
    public int Id { get; set; }
    public string MediaTypeName { get; set; }
    public string MediaTypeDescription { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<MediaCatalog> Catalogs { get; set; } = new List<MediaCatalog>();
  }
}