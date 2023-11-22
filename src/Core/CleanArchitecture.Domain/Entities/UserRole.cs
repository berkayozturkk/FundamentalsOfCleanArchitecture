﻿using CleanArchitecture.Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public sealed class UserRole : Entity
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public AppUser User { get; set; }
    public Role Role { get; set; }
}
