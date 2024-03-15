namespace _66bitTest.Contracts
{
    public record FootballResponse(
        Guid id,
        string FirstName,
        string LastName,
        string Gender,
        DateTime DateOfBirth,
        string TeamName,
        string Country);
}