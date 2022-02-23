using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FamilyFinancesApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index()
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(userInfo);
        }

        public async Task<IActionResult> ManageSpendings()
        {
            ViewBag.UserId = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }

        public async Task<IActionResult> ManageIncomes()
        {
            ViewBag.UserId = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}