using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Models;

namespace MediaOrganizer.Services
{
  public interface IMediaService
  {

    // Basic CRUD
    public Task<bool> CreateAsync<T>(T model);
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class, new();
    Task<T> GetByIdAsync<T>(int id) where T : class, new();
    Task<bool> UpdateAsync<T>(int id, T model);
    Task<bool> DeleteAsync(int id);

    // Additional Features
    Task<bool> Assign(int entityId, int assignmentId);
  }

  public delegate IMediaService ServiceResolver(string key);
}