using Microsoft.EntityFrameworkCore;
using Stefanini.Desafio.Domain.Interfaces.Services;
using Stefanini.Desafio.Infra.Context;

namespace Stefanini.Desafio.Service.Person
{
  public class PersonService : IPersonService
  {
    private readonly StefaniniContext _context;
    public PersonService(StefaniniContext context)
    {
      _context = context;
    }
    public async Task<Domain.Models.Person> CreateAsync(Domain.Models.Person person)
    {
      try
      {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
        return person;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task DeleteAsync(int id)
    {
      try
      {
        Domain.Models.Person person = new Domain.Models.Person() { Id = id };
        _context.Persons.Attach(person);
        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task<List<Domain.Models.Person>> GetAllAsync()
    {
      try
      {
        return await _context.Persons.OrderBy(p => p.Name).ToListAsync();
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task<Domain.Models.Person> GetByIdAsync(int id)
    {
      try
      {
        return await _context.Persons.SingleAsync(p => p.Id == id);
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task<Domain.Models.Person> UpdateAsync(Domain.Models.Person person)
    {
      try
      {
        _context.Persons.Update(person);
        await _context.SaveChangesAsync();
        return person;
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
