using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyFinancesApp.Controllers
{
    [Authorize]
    public class SpendingController : Controller
    {
        private readonly ILogger<SpendingController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SpendingController(ILogger<SpendingController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int userInfoId)
        {
            ViewBag.UserInfoId = userInfoId;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSpending(int userInfoId)
        {
            /*var incomeTypes = await _unitOfWork.SpendingType.GetAllSpendingTypesAsync(userInfoId);

            return View(incomeTypes);*/

            throw new NotImplementedException();
        }

        public async Task<IActionResult> CreateSpending()
        {
            throw new NotImplementedException();
        }

    }
}
