using Football.Core.Models;
using Football.Data.Access.Repositories;

namespace Football.BusinessLogic.Services
{
    public class FootballService : IFootballService
    {
        private readonly IFootballRepo footballRepo;

        public FootballService(IFootballRepo footballRepo)
        {
            this.footballRepo = footballRepo;
        }

        public async Task<List<FootballPlayer>> GetPlayers()
        {
            return await footballRepo.Get();
        }
        public async Task<Guid> CreatePlayer(FootballPlayer player)
        {
            return await footballRepo.Create(player);
        }
        public async Task<Guid> UpdatePlayer(Guid id, string firstname, string lastname, string gender, DateTime dateofbith, string teamname, string country)
        {
            return await footballRepo.Update(id, firstname, lastname, gender, dateofbith, teamname, country);
        }
        public async Task<Guid> DeletePlayer(Guid id)
        {
            return await footballRepo.Delete(id);
        }
    }
}
