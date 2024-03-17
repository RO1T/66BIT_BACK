using Football.Core.Models;

namespace Football.Core.Abstractions;
public interface IFootballRepo
{
    Task<Guid> AsyncCreate(FootballPlayer player);
    Task<Guid> AsyncDelete(Guid id);
    Task<List<FootballPlayer>> AsyncGet();
    Task<Guid> AsyncUpdate(Guid id, string fristName, string lastName, string gender, DateTime dateOfBirth, string teamName, string country);
}
