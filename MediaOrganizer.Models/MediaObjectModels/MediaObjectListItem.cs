using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Models.MediaObjectModels
{
  public class MediaObjectListItem
  {
    public string MediaTypeName { get; set; }
    public string Title { get; set; }
    public int NumberOfCatalogs { get; set; }
  }
}