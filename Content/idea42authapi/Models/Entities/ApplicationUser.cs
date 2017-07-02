using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplicationBasic.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Add any new properties below this line.
    }
}
