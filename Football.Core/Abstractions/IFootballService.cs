using Football.Core.Models;

namespace Football.Core.Abstractions;

public interface IFootballService
{
    Task<Guid> AsyncCreatePlayer(FootballPlayer player);
    Task<Guid> AsyncDeletePlayer(Guid id);
    Task<List<FootballPlayer>> AsyncGetPlayers();
    Task<Guid> AsyncUpdatePlayer(Guid id, string firstName, string lastName, string gender, DateTime dateOfBith, string teamName, string country);
}