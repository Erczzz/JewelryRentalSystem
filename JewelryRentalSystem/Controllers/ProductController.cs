using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using JewelryRentalSystem.Services;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace JewelryRentalSystem.Controllers
{
    public class ProductController : Controller
    {
        IProductDBRepository _repo;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly JRSDBContext _JRSDBContext;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IProductDBRepository repo,
            IWebHostEnvironment webHostEnvironment, JRSDBContext JRSDBContext,
            IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
            _JRSDBContext = JRSDBContext;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllProducts(string SearchString)
        {
            var count = _JRSDBContext.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();

            ViewData["CurrentFilter"] = SearchString;
            var products = from p in _JRSDBContext.Products select p;
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(p => p.ProductName.Contains(SearchString));
            }
            // var productList = await _repo.GetAllProducts();
            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> ProductManagement()
        {
            var productList = await _repo.GetAllProducts();
            return View(productList);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(_JRSDBContext.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel newProduct)
        {
            //if (ModelState.IsValid)
            {
            if (newProduct.ProductImage != null)
            {
                ViewData["CategoryId"] = new SelectList(_JRSDBContext.Categories, "CategoryId", "CategoryName", newProduct);
                string folder = "products/productImgs/";
                folder += Guid.NewGuid().ToString() + "_" + newProduct.ProductImage.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                newProduct.ProductImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                Product product = new Product()
                {
                    ProductName = newProduct.ProductName,
                    CategoryId = newProduct.CategoryId,
                    ProductPrice = newProduct.ProductPrice,
                    ProductStock = newProduct.ProductStock,
                    ProductDescription = newProduct.ProductDescription,
                    ProductImage = "/" + folder
                };
                await _repo.AddProduct(product);

            }


            return RedirectToAction("ProductManagement");
            }
/*            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();*/
        }

        public async Task<IActionResult> Details(int ProductId)
        {
            var product = await _repo.GetProductById(ProductId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int ProductId)
        {
            var productList = await _repo.DeleteProduct(ProductId);
            return RedirectToAction(controllerName: "Product", actionName: "ProductManagement");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int ProductId)
        {
            if (ProductId == null)
            {
                return View("NotFound", "Home");
            }
            var prod = await _repo.GetProductById(ProductId);
            if (prod == null)
            {
                return View("NotFound", "Home");
            }
            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel newProduct)
        {
            if (newProduct.ProductImage != null)
            {
                string folder = "products/productImgs/";
                folder += Guid.NewGuid().ToString() + "_" + newProduct.ProductImage.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                newProduct.ProductImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                Product product = new Product()
                {
                    ProductName = newProduct.ProductName,
                    ProductPrice = newProduct.ProductPrice,
                    ProductStock = newProduct.ProductStock,
                    ProductDescription = newProduct.ProductDescription,
                    ProductImage = "/" + folder
                };
                var updatedProduct = await _repo.UpdateProduct(newProduct.ProductId, product);
            }
            return RedirectToAction("ProductManagement");
        }
        public IActionResult AppointmentSchedule()
        {
            return View("AppointmentSchedule");
        }

        public async Task<IActionResult> AddToCart(int Id)
        {
            var product = await _repo.GetProductById(Id);
            var cart = new CartViewModel()
            {

                CustomerId = _userManager.GetUserId(HttpContext.User),
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductQty = 1,
                RentDuration = 1,
                Total = product.ProductPrice,
                ProductImage = product.ProductImage

            };

            return View(cart);
        }
    }
}