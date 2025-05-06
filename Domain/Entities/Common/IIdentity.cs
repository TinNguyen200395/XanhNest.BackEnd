
namespace XanhNest.BackEndServer.Data.Entities.Common
{
    public interface IIdentity
    {
        Guid Id { get; set; }  // Đổi từ string sang Guid
    }
}
