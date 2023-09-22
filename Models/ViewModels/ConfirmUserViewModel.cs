using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCNRecScheduler.Models.ViewModels
{
    public class ConfirmUserViewModel
    {
        public List<UserDetailsViewModel> UnconfirmedUsers { get; set; }
        public string UserId { get; set; }
    }

    public class UserDetailsViewModel
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string UserFullName { get; set; }
        // Add more user details properties here as needed
    }
    
}
