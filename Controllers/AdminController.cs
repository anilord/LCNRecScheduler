using LCNRecScheduler.Models;
using LCNRecScheduler.Models.ViewModels;
using LCNRecScheduler.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCNRecScheduler.Controllers
{

    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserService _userService;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, UserService userService)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ConfirmUser()
        {
            // Replace this with your logic to retrieve unconfirmed users from the database
            var unconfirmedUsers = _userService.GetUnconfirmedUsers(); // You should implement this method

            var viewModel = new ConfirmUserViewModel
            {
                UnconfirmedUsers = unconfirmedUsers.Select(user => new UserDetailsViewModel
                {
                    Id = user.Id,
                    UserEmail = user.Email,
                    UserFullName = $"{user.FirstName} {user.LastName}",
                    // Add more user details properties here as needed
                }).ToList()
            };

            return View(viewModel);
        }
    }

}
