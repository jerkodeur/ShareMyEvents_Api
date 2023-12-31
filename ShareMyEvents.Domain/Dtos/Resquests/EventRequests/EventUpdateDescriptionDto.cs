﻿using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateDescriptionDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Description { get; set; }
}
