using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Data.Access.Entites
{
    public class FootballPlayerEntity
    {
        [Key]
        [Column(nameof(Id))]
        public Guid Id { get; set; }

        [Column(nameof(FirstName))]
        public string FirstName { get; set; } = null!;

        [Column(nameof(LastName))]
        public string LastName { get; set; } = null!;

        [Column(nameof(Gender))]
        public string Gender { get; set; } = null!;

        [Column(nameof(DateOfBirth))]
        public DateTime DateOfBirth { get; set; }

        [Column(nameof(TeamName))]
        public string TeamName { get; set; } = null!;

        [Column(nameof(Country))]
        public string Country { get; set; } = null!;
    }
}
