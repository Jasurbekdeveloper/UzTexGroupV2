﻿using UzTexGroupV2.Domain.Enums;

namespace UzTexGroupV2.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role UserRole { get; set; }

}