using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCNRecScheduler.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsApproved { get; set; } // Indicates whether the user is approved by admins
                                             // Add any additional user properties here

        public ICollection<RecordingSession> RecordingSessions { get; set; } // User's recording sessions
    }
}
