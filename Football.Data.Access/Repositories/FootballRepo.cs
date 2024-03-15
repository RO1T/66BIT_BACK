using Football.Core.Models;
using Football.Data.Access.Entites;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Football.Data.Access.Repositories
{
    public class FootballRepo : IFootballRepo
    {
        private readonly FootballDbContext _context;
        public FootballRepo(FootballDbContext context)
        {
            _context = context;
        }

        public async Task<List<FootballPlayer>> Get()
        {
            var footballEntities = await _context.FootballPlayers.AsNoTracking().ToListAsync();
            var footballPlayers = footballEntities
                .Select(x => FootballPlayer.Create(x.Id, x.FirstName, x.LastName, x.Gender, x.DateOfBirth, x.TeamName, x.Country).player)
                .ToList();
            return footballPlayers;
        }

        public async Task<Guid> Create(FootballPlayer player)
        {
            var footballEntity = new FootballPlayerEntity
            {

                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Gender = player.Gender,
                DateOfBirth = player.DateOfBirth,
                TeamName = player.TeamName,
                Country = player.Country,
            };
            await _context.FootballPlayers.AddAsync(footballEntity);
            await _context.SaveChangesAsync();

            return footballEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string firstname, string lastname, string gender, DateTime dateofbith, string teamname, string country)
        {
            //await _context.FootballPlayers
            //    .Where(x => x.Id == id)
            //    .ExecuteUpdateAsync(x => x
            //        .SetProperty(y => y.FirstName, y => firstname)
            //        .SetProperty(y => y.LastName, y => lastname)
            //        .SetProperty(y => y.Gender, y => gender)
            //        .SetProperty(y => y.DateOfBirth, y => dateofbith)
            //        .SetProperty(y => y.TeamName, y => teamname)
            //        .SetProperty(y => y.Country, y => country));

            var player = await _context.FootballPlayers.FirstOrDefaultAsync(x => x.Id == id);
            if (player is null)
            {

            }

            player.FirstName = firstname;
            player.LastName = lastname;
            player.Gender = gender;
            player.DateOfBirth = dateofbith;
            player.TeamName = teamname;
            player.Country = country;

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var player = await _context.FootballPlayers.FirstOrDefaultAsync(x => x.Id == id);
            _context.FootballPlayers.Remove(player);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
