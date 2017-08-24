using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplicationBasic.Models.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
