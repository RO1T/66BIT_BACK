using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _66bitTest.Contracts;

public record FootballRequest
{
    [Required]
    [JsonPropertyName("firstName")]
    public string FirstName { get; init; } = null!;
    [Required]
    [JsonPropertyName("lastName")]
    public string LastName { get; init; } = null!;
    [Required]
    [JsonPropertyName("gender")]
    public string Gender { get; init; } = null!;
    [Required]
    [JsonPropertyName("dateOfBirth")]
    public DateTime DateOfBirth { get; init; }
    [Required]
    [JsonPropertyName("teamName")]
    public string TeamName { get; init; } = null!;
    [Required]
    [JsonPropertyName("country")]
    public string Country { get; init; } = null!;
}