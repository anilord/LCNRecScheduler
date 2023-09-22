using LCNRecScheduler.Data;
using LCNRecScheduler.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCNRecScheduler.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public List<ApplicationUser> GetUnconfirmedUsers()
        {
            var unconfirmedUsers = _context.Users
                .Where(user => !user.IsApproved) // Adjust this condition based on your schema
                .ToList();

            return unconfirmedUsers;
        }
    }
}
