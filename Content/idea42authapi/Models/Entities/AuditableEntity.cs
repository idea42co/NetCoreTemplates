using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBasic.Models.Entities
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Guid? UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        

        [ForeignKey("UpdatedById")]
        public virtual ApplicationUser UpdatedBy { get; set; }
    }
}
