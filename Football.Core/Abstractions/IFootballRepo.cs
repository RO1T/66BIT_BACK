using Football.Core.Models;

namespace Football.Data.Access.Repositories
{
    public interface IFootballRepo
    {
        Task<Guid> Create(FootballPlayer player);
        Task<Guid> Delete(Guid id);
        Task<List<FootballPlayer>> Get();
        Task<Guid> Update(Guid id, string firstname, string lastname, string gender, DateTime dateofbith, string teamname, string country);
    }
}