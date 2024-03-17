namespace Football.Core.Models
{
    public class FootballPlayer
    {
        private FootballPlayer(Guid id, string firstName, string lastName, string gender, DateTime dateOfBith, string teamName, string country) 
        { 
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBith;
            TeamName = teamName;
            Country = country;
            
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TeamName { get; set; }
        public string Country { get; set; }

        public static (FootballPlayer player, string Error) Create(Guid id, string firstName, string lastName, string gender, DateTime dateOfBith, string teamName, string country)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(firstName))
            {
                error = "Name is required";
            }
            else if (string.IsNullOrEmpty(lastName))
            {
                error = "LastName is required";
            }
            else if(string.IsNullOrEmpty(gender))
            {
                error = "Gender is required";
            }
            else if(string.IsNullOrEmpty(teamName))
            {
                error = "TeamName is required";
            }
            else if(string.IsNullOrEmpty(country))
            {
                error = "Country is required";
            }


            var player = new FootballPlayer(id,firstName, lastName, gender, dateOfBith, teamName, country);
            return (player, error);
        }
    }
}
