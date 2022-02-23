using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyFinancesApp.Controllers
{
    public class SpendingController : Controller
    {
        [Authorize]
        public IActionResult Index(int userInfoId)
        {
            return View();
        }
    }
}
