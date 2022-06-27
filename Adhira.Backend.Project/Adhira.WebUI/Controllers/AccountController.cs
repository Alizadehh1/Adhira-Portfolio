using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adhira.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Profile()
        {
            return View();
        }
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
    }
}
