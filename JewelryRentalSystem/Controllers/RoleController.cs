using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JewelryRentalSystem.Controllers
{
    public class RoleController : Controller
    {
        IRoleDBRepository _repo;
        public RoleController(IRoleDBRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult GetAllRoles()
        {
            var roleList = _repo.GetAllRoles();
            return View(roleList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role newRole)
        {
            // if (ModelState.IsValid)
            {
                var role = _repo.AddRole(newRole);
                return RedirectToAction("GetAllRoles");
            }
            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();
        }
    }
}
