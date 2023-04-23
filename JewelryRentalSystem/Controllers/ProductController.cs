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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
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



        public async Task<IActionResult> GetAllProducts(string SearchString, int? page)
        {
            var count = _JRSDBContext.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

           
            var isLoggedIn = _userService.IsAuthenticated();

            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                var userClass = user.CustClassId;
                ViewData["CurrentFilter"] = SearchString;
                if (userClass == 1)
                {
                    var prodClass1 = from p in _JRSDBContext.Products where p.CustClassId == 1 select p;
                    if (!String.IsNullOrEmpty(SearchString))
                    {                        
                        prodClass1 = prodClass1.Where(p => p.ProductName.Contains(SearchString) && p.CustClassId <= 1);
                    }
                    // var productList = await _repo.GetAllProducts();
                    return View(prodClass1);
                }
                else if (userClass == 2)
                {
                    var prodClass2 = from p in _JRSDBContext.Products where p.CustClassId <= 2 select p;
                    if (!String.IsNullOrEmpty(SearchString))
                    {
                        prodClass2 = prodClass2.Where(p => p.ProductName.Contains(SearchString) && p.CustClassId <= 2);
                    }
                    return View(prodClass2);
                }
                else if (userClass == 3)
                {
                    var prodClass3 = from p in _JRSDBContext.Products where p.CustClassId <= 3 select p;
                    if (!String.IsNullOrEmpty(SearchString))
                    {
                        prodClass3 = prodClass3.Where(p => p.ProductName.Contains(SearchString) && p.CustClassId <= 3);
                    }
                    return View(prodClass3);
                }

/*                var prod = from p in _JRSDBContext.Products where p.CustomerClassId >= userClass select p;
                if (!String.IsNullOrEmpty(SearchString))
                {
                    prod = prod.Where(p => p.ProductName.Contains(SearchString) && p.CustomerClassId == userClass);
                }
                // var productList = await _repo.GetAllProducts();
                return View(prod);*/
            }


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
            ViewData["CustomerClassId"] = new SelectList(_JRSDBContext.CustomerClassifications.Where(x => x.CustomerClassId <= 4), "CustomerClassId", "CustomerClassName");
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
                ViewData["CustomerClassId"] = new SelectList(_JRSDBContext.CustomerClassifications.Where(x => x.CustomerClassId <= 4), "CustomerClassId", "CustomerClassName");
                    string folder = "products/productImgs/";
                folder += Guid.NewGuid().ToString() + "_" + newProduct.ProductImage.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                newProduct.ProductImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    if(newProduct.ProductPrice < 0)
                    {
                        TempData["priceError"] = "Product Price must be equal or greater than 0.";
                        return View();
                    }
                    else
                    {
                        Product product = new Product()
                        {
                            ProductName = newProduct.ProductName,
                            CategoryId = newProduct.CategoryId,
                            CustClassId = newProduct.CustomerClassId,
                            ProductPrice = newProduct.ProductPrice,
                            ProductStock = newProduct.ProductStock,
                            ProductDescription = newProduct.ProductDescription,
                            ProductImage = "/" + folder
                        };
                        await _repo.AddProduct(product);
                        TempData["Message"] = "Product has been added successfully!";
                    }
                

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
            ViewData["CategoryId"] = new SelectList(_JRSDBContext.Categories, "CategoryId", "CategoryName");
            ViewData["CustomerClassId"] = new SelectList(_JRSDBContext.CustomerClassifications.Where(x => x.CustomerClassId <= 4), "CustomerClassId", "CustomerClassName");
            if (ProductId == null)
            {
                return View("NotFound", "Home");
            }

            var prod = await _repo.GetProductById(ProductId);

            if (prod == null)
            {
                return View("NotFound", "Home");
            }

            var model = new ProductViewModel
            {
                ProductId = prod.ProductId,
                ProductName = prod.ProductName,
                ProductDescription = prod.ProductDescription,
                ProductPrice = prod.ProductPrice,
                ProductStock = prod.ProductStock,
                ProductImage = null, // Set to null because we're not editing the image here
                CategoryId = prod.CategoryId,
                CustomerClassification = prod.CustomerClassification
            };

            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Update(ProductViewModel model)
        {
            ViewData["CategoryId"] = new SelectList(_JRSDBContext.Categories, "CategoryId", "CategoryName");
            ViewData["CustomerClassId"] = new SelectList(_JRSDBContext.CustomerClassifications.Where(x => x.CustomerClassId <= 4), "CustomerClassId", "CustomerClassName");
            //if (ModelState.IsValid)
            {
                var prod = await _repo.GetProductById(model.ProductId);

                if (prod == null)
                {
                    return View("NotFound", "Home");
                }
                if (model.ProductPrice < 0)
                {
                    TempData["priceError"] = "Product Price must be equal or greater than 0.";
                    return View();
                }
                else
                {
                    var updatedProduct = new Product
                    {
                        ProductId = model.ProductId,
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        ProductPrice = model.ProductPrice,
                        ProductStock = model.ProductStock,
                        CategoryId = model.CategoryId,
                        CustClassId = model.CustomerClassId
                    };

                    var result = await _repo.UpdateProduct(updatedProduct, model.ProductImage);
                    if (result != null)
                    {
                        await _JRSDBContext.SaveChangesAsync();
                        TempData["UpdateProduct"] = "Product has been updated successfully!";
                        return RedirectToAction("ProductManagement");
                    }
                }

                
            }
            return View(model);
        }








        /*
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
                }*/
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