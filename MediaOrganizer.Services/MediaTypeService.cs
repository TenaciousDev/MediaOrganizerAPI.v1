using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Data;
using MediaOrganizer.Data.Entities;
using MediaOrganizer.Models;
using MediaOrganizer.Models.MediaTypeModels;
using Microsoft.EntityFrameworkCore;

namespace MediaOrganizer.Services
{
  public class MediaTypeService : IMediaService
  {
    private ApplicationDbContext _context;

    public MediaTypeService(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<bool> CreateAsync<T>(T model)
    {
      MediaTypeCreate mediaTypeModel = model as MediaTypeCreate;
      var entity = new MediaType
      {
        Title = mediaTypeModel.Title,
        Description = mediaTypeModel.Description
      };

      _context.MediaTypes.Add(entity);
      var numberOfChanges = await _context.SaveChangesAsync();
      return numberOfChanges == 1;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>()
    {
      var mediaTypes = (await _context.MediaTypes.Select(entity => new MediaTypeListItem
      {
        Title = entity.Title
      }).ToListAsync());

      return (IEnumerable<T>)mediaTypes;
    }

    public async Task<MediaTypeDetail> GetByIdAsync<MediaTypeDetail>(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync<MediaTypeEdit>(MediaTypeEdit model)
    {
      throw new NotImplementedException();
    }
    public async Task<bool> DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}