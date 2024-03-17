using _66bitTest.Contracts;
using Football.Core.Abstractions;
using Football.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace _66bitTest.Controllers;

[ApiController]
[Route("[controller]")]
public class FootballController(IFootballService footballService) : ControllerBase
{
    private readonly IFootballService _footballService = footballService;

    [HttpGet]
    public async Task<ActionResult<List<FootballResponse>>> AsyncGetPlayers()
    {
        var players = await _footballService.AsyncGetPlayers();
        var response = players.Select(x => new FootballResponse(x.Id, x.FirstName, x.LastName, x.Gender, x.DateOfBirth, x.TeamName, x.Country));
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AsyncCreatePlayer([FromBody] FootballRequest footballRequest)
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
        var footballerId = await _footballService.AsyncCreatePlayer(player);
        return Ok(footballerId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> AsyncUpdatePlayer([FromRoute] Guid id, [FromBody] FootballRequest footballRequest)
    {
        var footballerId = await footballService.AsyncUpdatePlayer(
                id,
                footballRequest.FirstName,
                footballRequest.LastName,
                footballRequest.Gender,
                footballRequest.DateOfBirth,
                footballRequest.TeamName,
                footballRequest.Country);
        return Ok(footballerId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> AsyncDeletePlayer([FromRoute] Guid id)
    {
        return Ok(await _footballService.AsyncDeletePlayer(id));
    }
}
