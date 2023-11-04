using System.ComponentModel;
using Jerkoder.Common.Domain.EntityFramework.Interfaces;

namespace ShareMyEvents.Domain.Entities;

public class Address: BaseEntity
{
    public AddressId Id { get; set; }

    [DefaultValue("1 rue des templiers")]
    public string? Street { get; set; } = string.Empty;

    [DefaultValue("92220")]
    public string? PostalCode { get; set; } = string.Empty;

    [DefaultValue("Levallois")]
    public string? City { get; set; } = string.Empty;

    [DefaultValue("Au fond de la cour à droite")]
    public string? Additional { get; set; } = string.Empty;

    public required Event Event { get; set; }
}

public record AddressId (int Value);
