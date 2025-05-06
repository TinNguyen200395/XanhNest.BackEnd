using System;
using System.ComponentModel.DataAnnotations.Schema;
using XanhNest.BackEndServer.Data.Entities.Common;

namespace XanhNest.BackEndServer.Data.Entities
{
	public class Room:BaseEntity
	{
        public Guid HostelId { get; set; }  
        public string RoomNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }

        public Hostel Hostel { get; set; }
    }
}

