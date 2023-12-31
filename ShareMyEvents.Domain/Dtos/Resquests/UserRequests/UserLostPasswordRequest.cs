﻿using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
public class UserLostPasswordRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Email { get; set; }
}
