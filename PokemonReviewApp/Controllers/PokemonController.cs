using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepositoryrepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepositoryrepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]

        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRepositoryrepository.GetPokemons();

            if (!ModelState.IsValid)
            {
                BadRequest(pokemons);
            }
            return Ok(pokemons);
        }
    }
}