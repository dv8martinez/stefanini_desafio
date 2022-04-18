using Microsoft.EntityFrameworkCore;
using Stefanini.Desafio.Domain.Interfaces.Services;
using Stefanini.Desafio.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Desafio.Service.City
{
    public class Citieservice : ICityService
    {
        private readonly StefaniniContext _context;
        public Citieservice(StefaniniContext context)
        {
            _context = context;
        }
        public async Task<Domain.Models.City> CreateAsync(Domain.Models.City City)
        {
            try
            {
                _context.Cities.Add(City);
                await _context.SaveChangesAsync();
                return City;
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
                Domain.Models.City City = new Domain.Models.City() { CityId = id };
                _context.Cities.Attach(City);
                _context.Cities.Remove(City);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Domain.Models.City>> GetAllAsync()
        {
            try
            {
                return await _context.Cities.OrderBy(p => p.Name).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Domain.Models.City> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Cities.SingleAsync(p => p.CityId == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Domain.Models.City> UpdateAsync(Domain.Models.City City)
        {
            try
            {
                _context.Cities.Update(City);
                await _context.SaveChangesAsync();
                return City;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
