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
  public class MediaCatalogService : IMediaService
  {
    private readonly ApplicationDbContext _context;
    public MediaCatalogService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<bool> CreateAsync<T>(T model)
    {
      MediaCatalogCreate mediaCatalogModel = model as MediaCatalogCreate;
      var entity = new MediaCatalog
      {
        Title = mediaCatalogModel.Title,
        Description = mediaCatalogModel.Description
      };

      _context.MediaCatalogs.Add(entity);
      var numberOfChanges = await _context.SaveChangesAsync();
      return numberOfChanges == 1;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class, new()
    {
      var mediaCatalogs = (await _context.MediaCatalogs
        .Select(entity => new MediaCatalogListItem
        {
          Id = entity.Id,
          Title = entity.Title,
          NumberOfMembers = entity.Members.Count
        }).ToListAsync());

      return mediaCatalogs as IEnumerable<T>;
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : class, new()
    {
      var entity = await _context.MediaCatalogs
      .Include(c => c.Members)
      .ThenInclude(member => member.TypeOfMedia)
      .FirstOrDefaultAsync(c => c.Id == id);
      if (entity is null) return default;
      MediaCatalogDetail detail = new MediaCatalogDetail
      {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Members = entity.Members.Select(m => new MediaObjectListItem
        {
          Id = m.Id,
          Title = m.Title,
          MediaTypeName = m.TypeOfMedia.Title,
          NumberOfCatalogs = m.Catalogs.Count
        }).ToList()
      };
      return detail as T;
    }

    public async Task<bool> UpdateAsync<T>(int id, T model)
    {
      var entity = await _context.MediaCatalogs.FindAsync(id);
      if (entity is null) return false;

      MediaCatalogEdit editModel = model as MediaCatalogEdit;

      entity.Title = editModel.Title;
      entity.Description = editModel.Description;

      var numberOfChanges = await _context.SaveChangesAsync();
      return numberOfChanges == 1;
    }
    public async Task<bool> DeleteAsync(int id)
    {
      var entity = await _context.MediaCatalogs.FindAsync(id);
      if (entity is null) return false;

      _context.MediaCatalogs.Remove(entity);
      return await _context.SaveChangesAsync() == 1;
    }

    public Task<bool> Assign(int entityId, int assignmentId)
    {
      throw new NotImplementedException();
    }
  }
}