using System;

namespace XanhNest.BackEndServer.Data.Entities.Common
{
    public interface IBaseEntity : IIdentity, IActiveEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        // Đổi kiểu trả về từ string sang Guid
        Guid GetNewId();
    }
}
