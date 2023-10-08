namespace ShareMyEvents.Domain.Models;

public class Address: AbstractEntity
{
    public Address (string street, string postalCode, string city, string additional)
    {
        Street = street;
        PostalCode = postalCode;
        City = city;
        Additional = additional;
    }

    public string? Street { get; set; } = string.Empty;
    public string? PostalCode { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    public string? Additional { get; set; } = string.Empty;
}
