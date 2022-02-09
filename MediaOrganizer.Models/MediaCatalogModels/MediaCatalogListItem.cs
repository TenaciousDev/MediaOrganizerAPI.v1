using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Models.MediaCatalogModels
{
  public class MediaCatalogListItem
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public int NumberOfMembers { get; set; }
  }
}