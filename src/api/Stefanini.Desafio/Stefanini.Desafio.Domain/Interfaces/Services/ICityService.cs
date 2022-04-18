using Stefanini.Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Desafio.Domain.Interfaces.Services
{
  public interface ICityService
  {
    Task<City> CreateAsync(City person);
    Task<List<City>> GetAllAsync();
    Task DeleteAsync(int id);
    Task<City> GetByIdAsync(int id);
    Task<City> UpdateAsync(City person);
  }
}
