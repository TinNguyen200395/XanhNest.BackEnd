using System;
using System.ComponentModel.DataAnnotations;

namespace XanhNest.BackEndServer.Data.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid(); // Khởi tạo GUID mặc định
        }

        [Required]
        [Key]
        public Guid Id { get; set; }  // Đổi kiểu dữ liệu thành GUID

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(255)]
        public string CreatedBy { get; set; }

        [MaxLength(255)]
        public string UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        public virtual Guid GetNewId()
        {
            return Guid.NewGuid();
        }
    }
}
