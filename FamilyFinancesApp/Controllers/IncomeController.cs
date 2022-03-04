using FamilyFinancesApp.Data.Models;
using FamilyFinancesApp.UnitOfWorkFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace FamilyFinancesApp.Controllers
{
    [Authorize]
    public class IncomeController : Controller
    {
        private readonly ILogger<IncomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public IncomeController(ILogger<IncomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var income = await _unitOfWork.Income.GetIncomesByUserInfoID(userInfo.Id);

            return View(income);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userInfo = await _unitOfWork.UserInfo.GetUserInfoAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var incomeTypes = await _unitOfWork.IncomeType.GetIncomeTypes(userInfo.Id);

            ViewBag.IncomeTypes = new SelectList(incomeTypes, "Id", "TypeName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Income income)
        {
            if (ModelState.IsValid)
            {
                income.IncomeType = await _unitOfWork.IncomeType.GetIncomeType(income.IncomeTypeId);

                var incomeTypeToReturn = await _unitOfWork.Income.CreateIncomes(income);

                if (incomeTypeToReturn is null)
                {
                    return View("Index");
                }

                return RedirectToAction("Details", new { id = incomeTypeToReturn.Id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var income = await _unitOfWork.Income.GetIncomeByID(id);

            if (income is null)
            {
                return View("Index");
            }

            return View(income);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var income = await _unitOfWork.Income.GetIncomeByID(id);

            return View(income);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Income income)
        {
            var incomeTypeToReturn = await _unitOfWork.Income.UpdateIncome(income);

            if (incomeTypeToReturn is null)
            {
                return View("Index");
            }

            return RedirectToAction("Details", new { id = incomeTypeToReturn.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var income = await _unitOfWork.Income.GetIncomeByID(id);

            return View(income);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Income.DeleteIncome(id);

            return RedirectToAction("Index");
        }

        
    }
}
