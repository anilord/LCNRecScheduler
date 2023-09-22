using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCNRecScheduler.Models
{
    public class RecordingSession
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SessionDetails { get; set; } // Additional session details
        public bool IsApproved { get; set; } // Indicates whether the session is approved by admins
    }
}
