using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationBasic.Models.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
