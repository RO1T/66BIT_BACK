using Football.Data.Access.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.Data.Access.Configurations
{
    internal class FootballPlayerConfig : IEntityTypeConfiguration<FootballPlayerEntity>
    {
        public void Configure(EntityTypeBuilder<FootballPlayerEntity> builder)
        {
        }
    }
}
