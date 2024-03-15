using System.Globalization;
using System.Reflection;

namespace Football.Core.Models
{
    public class FootballPlayer
    {
        // to do enum in Gender
        private FootballPlayer(Guid id, string firstname, string lastname, string gender, DateTime dateofbith, string teamname, string country) 
        { 
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            DateOfBirth = dateofbith;
            TeamName = teamname;
            Country = country;
            
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TeamName { get; set; }
        // 
        public string Country { get; set; }

        public static (FootballPlayer player, string Error) Create(Guid id, string firstname, string lastname, string gender, DateTime dateofbith, string teamname, string country)
        {
            // to do validation for creating model
            var error = string.Empty;
            if (string.IsNullOrEmpty(firstname))
            {
                error = "Name is required";
            }
           

            var player = new FootballPlayer(id,firstname, lastname, gender, dateofbith, teamname, country);
            return (player, error);
        }
    }
}
