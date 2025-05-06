using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XanhNest.BackEndServer.Data.Entities;

namespace XanhNest.BackEndServer.Data
{
    // Định nghĩa ApplicationDbContext kế thừa từ IdentityDbContext để quản lý người dùng và các thực thể liên quan đến Identity.
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        // Constructor nhận DbContextOptions và truyền cho lớp cơ sở IdentityDbContext.
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Override phương thức OnModelCreating để cấu hình thêm cho các thực thể và mối quan hệ.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Gọi phương thức base.OnModelCreating để thực hiện cấu hình mặc định từ lớp cơ sở.
            base.OnModelCreating(builder);

            // Cấu hình các bảng Identity dùng GUID làm kiểu dữ liệu cho ID thay vì int.
            builder.Entity<IdentityUserClaim<Guid>>().Property(x => x.UserId).HasColumnType("uuid");
            builder.Entity<IdentityUserLogin<Guid>>().Property(x => x.UserId).HasColumnType("uuid");
            builder.Entity<IdentityUserRole<Guid>>().Property(x => x.UserId).HasColumnType("uuid");
            builder.Entity<IdentityUserRole<Guid>>().Property(x => x.RoleId).HasColumnType("uuid");
            builder.Entity<IdentityRole<Guid>>().Property(x => x.Id).HasColumnType("uuid");
            builder.Entity<User>().Property(x => x.Id).HasColumnType("uuid");

            // Cấu hình quan hệ giữa Room và Hostel, với khóa ngoại trên HostelId.
            builder.Entity<Room>()
                .HasOne(r => r.Hostel)  // Mỗi phòng (Room) có một nhà trọ (Hostel) duy nhất.
                .WithMany(h => h.Rooms) // Mỗi nhà trọ có thể có nhiều phòng.
                .HasForeignKey(r => r.HostelId)  // Đặt khóa ngoại cho trường HostelId.
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa nhà trọ, tất cả các phòng liên quan cũng bị xóa (Cascade Delete).
        }

        // Định nghĩa các DbSet cho các thực thể trong ứng dụng (Hostel, Room).
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
