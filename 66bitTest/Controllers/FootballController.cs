using _66bitTest.Contracts;
using Football.BusinessLogic.Services;
using Football.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _66bitTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FootballController : ControllerBase
    {
        private readonly IFootballService footballService;

        public FootballController(IFootballService footballService) 
        {
            this.footballService = footballService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballResponse>>> GetPlayers()
        {
            var players = await footballService.GetPlayers();
            var response = players.Select(x => new FootballResponse(x.Id, x.FirstName, x.LastName, x.Gender, x.DateOfBirth, x.TeamName, x.Country));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePlayer([FromBody] FootballRequest footballRequest)
        {
            var (player, error) = FootballPlayer.Create(
                Guid.NewGuid(),
                footballRequest.FirstName,
                footballRequest.LastName,
                footballRequest.Gender,
                footballRequest.DateOfBirth,
                footballRequest.TeamName,
                footballRequest.Country
                );

            if (!string.IsNullOrEmpty( error ) )
            {
                return BadRequest(error);
            }
            var footballerId = await footballService.CreatePlayer(player);
            return Ok(footballerId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdatePlayer(Guid id, [FromBody] FootballRequest footballRequest)
        {
            var footballerId = await footballService.UpdatePlayer(id, footballRequest.FirstName, footballRequest.LastName, footballRequest.Gender, footballRequest.DateOfBirth, footballRequest.TeamName, footballRequest.Country);
            return Ok(footballerId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeletePlayer(Guid id)
        {
            return Ok(await footballService.DeletePlayer(id));
        }
    }
}
