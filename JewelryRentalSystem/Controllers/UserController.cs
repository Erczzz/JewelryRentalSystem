using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JewelryRentalSystem.Controllers
{
    public class UserController : Controller
    {
        IUserDBRepository _repo;
        public UserController(IUserDBRepository repo)
        {
            this._repo = repo;
        }
        public IActionResult GetAllUsers()
        {
            var userList = _repo.GetAllUsers();
            return View(userList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User newUser)
        {
            //if (ModelState.IsValid)
            {
                var user = _repo.AddUser(newUser);
                return RedirectToAction("GetAllUsers");
            }
            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();
        }

        public IActionResult Delete(int userId)
        {
            var userList = _repo.DeleteUser(userId);
            return RedirectToAction(controllerName: "User", actionName: "GetAllUsers");
        }

        [HttpGet]
        public IActionResult Update(int userId)
        {
            var oldUser = _repo.GetUserById(userId);
            return View(oldUser);
        }
        [HttpPost]
        public IActionResult Update(User newUser)
        {
            var user = _repo.UpdateUser(newUser.UserId, newUser);
            return RedirectToAction("GetAllUsers");
        }
    }
}
