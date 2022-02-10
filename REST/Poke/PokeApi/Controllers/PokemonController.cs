using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using PokeBL;
/*
    Auto generate by utilizing aspnet-codegenerator tool 
    https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-6.0

    -To start
    --Install tool first => dotnet tool install -g dotnet-aspnet-codegenerator
    --Add package to api project Microsoft.VisualStudio.Web.CodeGeneration.Design

    -To create a controller
    dotnet aspnet-codegenerator controller -name Pokemon -api -outDir Controllers -actions

    "dotnet aspnet-codegenerator controller" - creates a controller

    "-name {NameOfController}" - names the controller to whatever you put

    "-api" - Makes the controller restful style api

    "-outDir Controllers" - Puts the controller inside the Controllers folder in api project

    "-actions" - Adds in action(methods) in your controllers

*/

namespace PokeApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PokemonController : ControllerBase
  {
    private IPokemonBL _pokeBL;

    public PokemonController(IPokemonBL p_pokeBL)
    {
      _pokeBL = p_pokeBL;
    }

    // GET: api/Pokemon
    [HttpGet]
    public IActionResult GetAllPokemon()
    {
      try
      {
        return Ok(_pokeBL.GetAllPokemon());
      }
      catch (SqlException)
      {
        //The API is responsible for sending the right resource and the right status code
        //In this case, if it was unable to connect to the database, it will give a 404 error
        return NotFound();
      }
    }

    // GET: api/Pokemon/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Pokemon
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Pokemon/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Pokemon/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
