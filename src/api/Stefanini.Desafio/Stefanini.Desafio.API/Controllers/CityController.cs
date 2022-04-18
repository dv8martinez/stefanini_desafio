using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Desafio.Domain.Interfaces.Services;
using Stefanini.Desafio.Domain.Models;

namespace Stefanini.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllAsync([FromServices] ICityService cityService)
        {
            try
            {
                var _result = await cityService.GetAllAsync();
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetAllByID([FromServices] ICityService cityService, int id)
        {
            try
            {
                var _result = await cityService.GetByIdAsync(id);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateAsync([FromServices] ICityService cityService, [FromBody] City City)
        {
            try
            {
                var _result = await cityService.CreateAsync(City);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<City>> CreateAsync([FromServices] ICityService cityService, int id, [FromBody] City City)
        {
            try
            {
                City.CityId = id;
                var _result = await cityService.UpdateAsync(City);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteAsync([FromServices] ICityService cityService, int id)
        {
            try
            {

                await cityService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
