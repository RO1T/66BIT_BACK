using Football.Core.Abstractions;
using Football.Core.Models;

namespace Football.BusinessLogic.Services
{
    public class FootballService(IFootballRepo footballRepo) : IFootballService
    {
        private readonly IFootballRepo footballRepo = footballRepo;

        public async Task<List<FootballPlayer>> AsyncGetPlayers()
        {
            return await footballRepo.AsyncGet();
        }
        public async Task<Guid> AsyncCreatePlayer(FootballPlayer player)
        {
            return await footballRepo.AsyncCreate(player);
        }
        public async Task<Guid> AsyncUpdatePlayer(Guid id, string firstName, string lastName, string gender, DateTime dateOfBith, string teamName, string country)
        {
            return await footballRepo.AsyncUpdate(id, firstName, lastName, gender, dateOfBith, teamName, country);
        }
        public async Task<Guid> AsyncDeletePlayer(Guid id)
        {
            return await footballRepo.AsyncDelete(id);
        }
    }
}
