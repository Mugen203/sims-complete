using Microsoft.AspNetCore.Identity;

namespace ischool_backend.Core.Entities;

public class User : IdentityUser
{
    public string StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}