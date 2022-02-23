using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FamilyFinancesApp.Controllers
{
    public class IncomeTypeController : Controller
    {
        private readonly ILogger<IncomeTypeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public IncomeTypeController(ILogger<IncomeTypeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var incomeType = await _unitOfWork.IncomeType.GetIncomeTypes(userInfo.Id);

            return View(incomeType);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncomeType incomeType)
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var incomeTypeToReturn = await _unitOfWork.IncomeType.CreateIncomeTypeAsync(incomeType, userInfo.Id);

            if (incomeTypeToReturn is null)
            {
                return View("Index");
            }

            return RedirectToAction("Details", new { id = incomeTypeToReturn.Id });
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var incomeType = await _unitOfWork.IncomeType.GetIncomeType(id);

            if (incomeType is null)
            {
                return View("Index");
            }

            return View(incomeType);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var incomeType = await _unitOfWork.IncomeType.GetIncomeType(id);

            return View(incomeType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IncomeType incomeType)
        {
            var incomeTypeToReturn = await _unitOfWork.IncomeType.UpdateIncomeTypeAsync(incomeType);

            if (incomeTypeToReturn is null)
            {
                return View("Index");
            }

            return RedirectToAction("Details", new { id = incomeTypeToReturn.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var incomeType = await _unitOfWork.IncomeType.GetIncomeType(id);

            return View(incomeType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.IncomeType.DeleteIncomeTypeAsync(id);

            return RedirectToAction("Index");
        }
    }
}
