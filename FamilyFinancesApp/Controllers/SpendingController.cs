using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

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

        public async Task<IActionResult> Index()
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var spendings = await _unitOfWork.Spending.GetAllSpendingsAsync(userInfo.Id);

            return View(spendings);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var spendingTypes = await _unitOfWork.SpendingType.GetAllSpendingTypesAsync(userInfo.Id);

            ViewBag.SpendingTypes = new SelectList(spendingTypes, "Id", "TypeName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Spending spending)
        {
            if (ModelState.IsValid)
            {
                spending.SpendingType = await _unitOfWork.SpendingType.GetSpendingTypeAsync(spending.SpendingTypeId);

                var spendingTypeToReturn = await _unitOfWork.Spending.CreateSpendingAsync(spending);

                if (spendingTypeToReturn is null)
                {
                    return View("Index");
                }

                return RedirectToAction("Details", new { id = spendingTypeToReturn.Id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var spending = await _unitOfWork.Spending.GetSpendingAsync(id);

            if (spending is null)
            {
                return View("Index");
            }

            return View(spending);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var spending = await _unitOfWork.Spending.GetSpendingAsync(id);

            return View(spending);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Spending spending)
        {
            var spendingTypeToReturn = await _unitOfWork.Spending.UpdateSpendingAsync(spending);

            if (spendingTypeToReturn is null)
            {
                return View("Index");
            }

            return RedirectToAction("Details", new { id = spendingTypeToReturn.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var spending = await _unitOfWork.Spending.GetSpendingAsync(id);

            return View(spending);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Spending.DeleteSpending(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> IsSpendingAmountValid(decimal amount)
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (amount > userInfo.Money)
            {
                return Json(false);
            }

            return Json(true); 
        }
    }
}
