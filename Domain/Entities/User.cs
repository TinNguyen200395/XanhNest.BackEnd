using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using XanhNest.BackEndServer.Data.Entities.Common;

namespace XanhNest.BackEndServer.Data.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int NumberOfKnowledgeBases { get; set; } = 0;

        [Column(TypeName = "int")]
        [Required]
        public int NumberOfVotes { get; set; } = 0;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(255)]
        public string? CreatedBy { get; set; }  // Cho phép nullable

        [MaxLength(255)]
        public string? UpdatedBy { get; set; }  // Cho phép nullable

        public bool IsActive { get; set; }

        public override Guid Id { get; set; } = Guid.NewGuid();

        public virtual Guid GetNewId()
        {
            return Guid.NewGuid();
        }
    }
}
