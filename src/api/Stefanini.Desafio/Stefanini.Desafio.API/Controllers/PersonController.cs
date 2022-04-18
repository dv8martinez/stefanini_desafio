using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Desafio.Domain.Interfaces.Services;
using Stefanini.Desafio.Domain.Models;

namespace Stefanini.Desafio.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonController : ControllerBase
  {

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAllAsync([FromServices] IPersonService personService)
    {
      try
      {
        var _result = await personService.GetAllAsync();
        return Ok(_result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetAllByID([FromServices] IPersonService personService, int id)
    {
      try
      {
        var _result = await personService.GetByIdAsync(id);
        return Ok(_result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpPost]
    public async Task<ActionResult<Person>> CreateAsync([FromServices] IPersonService personService, [FromBody] Person person)
    {
      try
      {
        var _result = await personService.CreateAsync(person);
        return Ok(_result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Person>> CreateAsync([FromServices] IPersonService personService, int id, [FromBody] Person person)
    {
      try
      {
        person.Id = id;
        var _result = await personService.UpdateAsync(person);
        return Ok(_result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Person>> DeleteAsync([FromServices] IPersonService personService, int id)
    {
      try
      {
        
       await personService.DeleteAsync(id);
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }


  }
}
