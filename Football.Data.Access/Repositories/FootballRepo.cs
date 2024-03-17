using Football.Core.Abstractions;
using Football.Core.Models;
using Football.Data.Access.Entites;
using Microsoft.EntityFrameworkCore;

namespace Football.Data.Access.Repositories
{
    public class FootballRepo(FootballDbContext context) : IFootballRepo
    {
        private readonly FootballDbContext _context = context;

        public async Task<List<FootballPlayer>> AsyncGet()
        {
            var footballEntities = await _context.FootballPlayers.AsNoTracking().ToListAsync();
            var footballPlayers = footballEntities
                .Select(x => FootballPlayer.Create(x.Id, x.FirstName, x.LastName, x.Gender, x.DateOfBirth, x.TeamName, x.Country).player)
                .ToList();
            return footballPlayers;
        }

        public async Task<Guid> AsyncCreate(FootballPlayer player)
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

        public async Task<Guid> AsyncUpdate(Guid id, string firstName, string lastName, string gender, DateTime dateOfBith, string teamName, string country)
        {

            var player = await _context.FootballPlayers.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentNullException("player");
            player.FirstName = firstName;
            player.LastName = lastName;
            player.Gender = gender;
            player.DateOfBirth = dateOfBith;
            player.TeamName = teamName;
            player.Country = country;

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> AsyncDelete(Guid id)
        {
            var player = await _context.FootballPlayers.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentNullException("player");
            _context.FootballPlayers.Remove(player);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
