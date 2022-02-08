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

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class, new()
    {
      var mediaTypes = (await _context.MediaTypes.Select(entity => new MediaTypeListItem
      {
        Id = entity.Id,
        Title = entity.Title
      }).ToListAsync());

      return mediaTypes as IEnumerable<T>;
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : class, new()
    {
      var entity = await _context.MediaTypes.FindAsync(id);
      if (entity is null) return default;
      MediaTypeDetail detail = new MediaTypeDetail
      {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
      };
      return detail as T;
    }

    public async Task<bool> UpdateAsync<T>(int id, T model)
    {
      var entity = await _context.MediaTypes.FindAsync(id);
      if (entity is null) return false;

      MediaTypeEdit editModel = model as MediaTypeEdit;

      entity.Title = editModel.Title;
      entity.Description = editModel.Description;

      var numberOfChanges = await _context.SaveChangesAsync();
      return numberOfChanges == 1;
    }
    public async Task<bool> DeleteAsync(int id)
    {
      var entity = await _context.MediaTypes.FindAsync(id);
      if (entity is null) return false;

      _context.MediaTypes.Remove(entity);
      return await _context.SaveChangesAsync() == 1;
    }
  }
}