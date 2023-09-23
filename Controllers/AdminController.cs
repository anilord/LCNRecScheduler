using LCNRecScheduler.Data;
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
        private readonly ApplicationDbContext _db;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, UserService userService, ApplicationDbContext db)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
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

        public IActionResult ConfirmBeforeConfirmUser(string UserID, string UserFullName)
        {
            ViewBag.id = UserID;
            ViewBag.fullname = UserFullName;
            return View();
        }

        public async Task<IActionResult> DoConfirm(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsApproved = true;
            _db.SaveChanges();
            return RedirectToAction("ConfirmUser");
        }

        // Display the password change form for another user
        [HttpGet]
        public IActionResult ChangeUserPassword(string userId, string FullName)
        {
            var model = new AdminChangePasswordViewModel { UserId = userId };
            return View(model);
        }

        public IActionResult DisplayUsers()
        {
            // Replace this with your logic to retrieve unconfirmed users from the database
            var confirmedUsers = _userService.GetConfirmedUsers(); // You should implement this method

            var viewModel = new ConfirmUserViewModel
            {
                UnconfirmedUsers = confirmedUsers.Select(user => new UserDetailsViewModel
                {
                    Id = user.Id,
                    UserEmail = user.Email,
                    UserFullName = $"{user.FirstName} {user.LastName}",
                    // Add more user details properties here as needed
                }).ToList()
            };

            return View(viewModel);
        }

        // Handle the password change request for another user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserPassword(AdminChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user != null)
                {
                    var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);

                    if (result.Succeeded)
                    {
                        // You can add a success message here if needed.
                        return RedirectToAction("Index", "Home"); // Redirect to a success page.
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }

            return View(model);
        }
    }

}
