﻿using System.ComponentModel;
using System.Text.Json.Serialization;
using Jerkoder.Common.Domain.EntityFramework;

namespace ShareMyEvents.Domain.Entities;

public class Address: TrackedEntity<AddressId>
{
    [DefaultValue("1 rue des templiers")]
    public string? Street { get; set; } = string.Empty;

    [DefaultValue("92220")]
    public string? PostalCode { get; set; } = string.Empty;

    [DefaultValue("Levallois")]
    public string? City { get; set; } = string.Empty;

    [DefaultValue("Au fond de la cour à droite")]
    public string? Additional { get; set; } = string.Empty;

    [JsonIgnore]
    public required Event Event { get; set; }
}

public record AddressId (int Value): StronglyTypeId;
