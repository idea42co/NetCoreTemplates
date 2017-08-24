using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplicationBasic.Models.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
