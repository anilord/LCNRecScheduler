using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCNRecScheduler.Controllers
{
    public class RecordingSessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
