using Stefanini.Desafio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Desafio.Domain.Interfaces.Services
{
  public interface IPersonService
  {
    Task<Person> CreateAsync(Person person);
    Task<List<Person>> GetAllAsync();
    Task DeleteAsync(int id);
    Task<Person> GetByIdAsync(int id);
    Task<Person> UpdateAsync(Person person);

  }
}
