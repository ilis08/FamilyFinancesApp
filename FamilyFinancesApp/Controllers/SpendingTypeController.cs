using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FamilyFinancesApp.Controllers
{
    [Authorize]
    public class SpendingTypeController : Controller
    {
        private readonly ILogger<SpendingTypeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SpendingTypeController(ILogger<SpendingTypeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)); 

            var spendingTypes = await _unitOfWork.SpendingType.GetIncomeTypesAsync(userInfo.Id);

            return View(spendingTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpendingType spendingType)
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var spendingTypeToReturn = await _unitOfWork.SpendingType.CreateSpendingTypeAsync(spendingType, userInfo.Id);

            if (spendingTypeToReturn is null)
            {
                return View("Index");
            }

            return RedirectToAction("Details", new { id = spendingTypeToReturn.Id });
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var spendingType = await _unitOfWork.SpendingType.GetSpendingTypeAsync(id);

            if (spendingType is null)
            {
                return View("Index");
            }

            return View(spendingType);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var spendingType = await _unitOfWork.SpendingType.GetSpendingTypeAsync(id);

            return View(spendingType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpendingType spendingType)
        {
            var spendingTypeToReturn = await _unitOfWork.SpendingType.UpdateSpendingTypeAsync(spendingType);

            if (spendingTypeToReturn is null)
            {
                return View("Index");
            }

            return RedirectToAction("Details", new { id = spendingTypeToReturn.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var spendingType = await _unitOfWork.SpendingType.GetSpendingTypeAsync(id);

            return View(spendingType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.SpendingType.DeleteSpendingType(id);

            return RedirectToAction("Index");
        }
    }
}
