using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyFinancesApp.Controllers
{
    public class IncomeController : Controller
    {
        [Authorize]
        public IActionResult Index(int userInfoId)
        {
            return View();
        }
    }
}
