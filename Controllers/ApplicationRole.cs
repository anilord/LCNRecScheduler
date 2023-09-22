using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCNRecScheduler.Controllers
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; } // Add a description property for the role

        // Constructor to set the role name
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
    

}
