using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Data;
using MediaOrganizer.Data.Entities;
using MediaOrganizer.Models.MediaCatalogModels;
using MediaOrganizer.Models.MediaObjectModels;
using Microsoft.EntityFrameworkCore;

namespace MediaOrganizer.Services
{
  public class MediaObjectService : IMediaService
  {
    private ApplicationDbContext _context;

    public MediaObjectService(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<bool> CreateAsync<T>(T model)
    {
      MediaObjectCreate mediaObjectModel = model as MediaObjectCreate;
      var entity = new MediaObject
      {
        MediaTypeId = mediaObjectModel.MediaTypeId,
        Title = mediaObjectModel.Title,
        Description = mediaObjectModel.Description
      };

      _context.MediaObjects.Add(entity);
      var numberOfChanges = await _context.SaveChangesAsync();
      return numberOfChanges == 1;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class, new()
    {
      var mediaObjects = (await _context.MediaObjects
        .Include(e => e.TypeOfMedia)
        .Include(e => e.Catalogs)
        .Select(entity => new MediaObjectListItem
        {
          Id = entity.Id,
          Title = entity.Title,
          MediaTypeName = entity.TypeOfMedia.Title,
          NumberOfCatalogs = entity.Catalogs.Count
        }).ToListAsync());

      return mediaObjects as IEnumerable<T>;
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : class, new()
    {
      var entity = await _context.MediaObjects.Include(o => o.TypeOfMedia).Include(o => o.Catalogs).FirstOrDefaultAsync(o => o.Id == id);
      if (entity is null) return default;
      MediaObjectDetail detail = new MediaObjectDetail
      {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        MediaTypeName = entity.TypeOfMedia.Title,
        MediaTypeDescription = entity.TypeOfMedia.Description,
        Catalogs = entity.Catalogs.Select(c => new MediaCatalogListItem
        {
          Id = c.Id,
          Title = c.Title,
          NumberOfMembers = c.Members.Count
        }).ToList()

      };
      return detail as T;
    }

    public async Task<bool> UpdateAsync<T>(int id, T model)
    {
      var entity = await _context.MediaObjects.FindAsync(id);
      if (entity is null) return false;

      MediaObjectEdit editModel = model as MediaObjectEdit;

      entity.MediaTypeId = editModel.MediaTypeId;
      entity.Title = editModel.Title;
      entity.Description = editModel.Description;

      var numberOfChanges = await _context.SaveChangesAsync();
      return numberOfChanges == 1;
    }

    public async Task<bool> Assign(int entityId, int assignmentId)
    {
      var entity = await _context.MediaObjects.FindAsync(entityId);
      if (entity is null) return false;
      var assignment = await _context.MediaCatalogs.Include(c => c.Members).SingleOrDefaultAsync(c => c.Id == assignmentId);
      if (assignment is null) return false;

      assignment.Members.Add(entity);
      return await _context.SaveChangesAsync() >= 1;

    }

    public async Task<bool> DeleteAsync(int id)
    {
      var entity = await _context.MediaObjects.FindAsync(id);
      if (entity is null) return false;

      _context.MediaObjects.Remove(entity);
      return await _context.SaveChangesAsync() == 1;
    }
  }
}