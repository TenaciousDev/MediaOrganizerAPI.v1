using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Data.Entities
{
  public class MediaCatalog
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<MediaObject> Members { get; set; }
  }
}