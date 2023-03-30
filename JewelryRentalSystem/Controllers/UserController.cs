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
    }
}
