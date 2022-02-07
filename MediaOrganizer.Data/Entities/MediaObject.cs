using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganizer.Data.Entities
{
  public class MediaObject
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(TypeOfMedia))]
    public int MediaTypeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual MediaType TypeOfMedia { get; set; }
    public ICollection<MediaCatalog> Catalogs { get; set; }
  }
}