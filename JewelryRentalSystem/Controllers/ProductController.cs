using JewelryRentalSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JewelryRentalSystem.Controllers
{
    public class ProductController : Controller
    {
        IProductDBRepository _repo;
        public ProductController(IProductDBRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult GetAllProducts()
        {
            var productList = _repo.GetAllProducts();
            return View(productList);
        }
    }
}
