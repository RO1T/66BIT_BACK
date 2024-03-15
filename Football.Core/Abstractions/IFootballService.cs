using Football.Core.Models;

namespace Football.BusinessLogic.Services
{
    public interface IFootballService
    {
        Task<Guid> CreatePlayer(FootballPlayer player);
        Task<Guid> DeletePlayer(Guid id);
        Task<List<FootballPlayer>> GetPlayers();
        Task<Guid> UpdatePlayer(Guid id, string firstname, string lastname, string gender, DateTime dateofbith, string teamname, string country);
    }
}