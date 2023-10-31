using System.ComponentModel;

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

    [DefaultValue("1 rue des templiers")]
    public string? Street { get; set; } = string.Empty;

    [DefaultValue("92220")]
    public string? PostalCode { get; set; } = string.Empty;

    [DefaultValue("Levallois")]
    public string? City { get; set; } = string.Empty;

    [DefaultValue("Au fond de la cour à droite")]
    public string? Additional { get; set; } = string.Empty;
}
