using System;
using System.ComponentModel.DataAnnotations.Schema;
using XanhNest.BackEndServer.Data.Entities.Common;

namespace XanhNest.BackEndServer.Data.Entities
{
    [Table("Hotels")]
    public class Hostel : BaseEntity
	{
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? OwnerName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Status { get; set; }
        public int TotalRooms { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}

