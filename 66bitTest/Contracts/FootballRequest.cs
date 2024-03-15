using Newtonsoft.Json;

namespace _66bitTest.Contracts
{
    public record FootballRequest(
    string FirstName,
    string LastName,
    string Gender,
    DateTime DateOfBirth,
    string TeamName,
    string Country);
}