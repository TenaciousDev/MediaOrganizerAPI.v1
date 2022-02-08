using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganizer.Models;

namespace MediaOrganizer.Services
{
  public interface IMediaService
  {
    public Task<bool> CreateAsync<T>(T model);
    Task<IEnumerable<T>> GetAllAsync<T>();
    Task<T> GetByIdAsync<T>(int id);
    Task<bool> UpdateAsync<T>(T model);
    Task<bool> DeleteAsync(int id);
  }
}