using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using Microsoft.AspNetCore.Identity;
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

        //READ EMPLOYEE

        public IActionResult Details(int UserId)
        {
            var user = _repo.GetUserById(UserId);
            return View(user);
        }

        //CREATE EMPLOYEE

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                var user = _repo.AddUser(newUser);
                return RedirectToAction("GetAllUsers");
            }
            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();
        }

        //DELETE EMPLOYEE

        public IActionResult Delete(int userID)
        {
            var userList = _repo.DeleteUser(userID);
            return RedirectToAction(controllerName: "User", actionName: "GetAllUsers");
        }

        //UPDATE EMPLOYEE

        [HttpGet]
        public IActionResult Update(int userID)
        {
            var oldUser = _repo.GetUserById(userID);
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
