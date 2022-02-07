using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Models.MediaObjectModels
{
  public class MediaObjectCatalogAssignment
  {
    public int MediaObjectId { get; set; }
    public int MediaCatalogId { get; set; }
  }
}