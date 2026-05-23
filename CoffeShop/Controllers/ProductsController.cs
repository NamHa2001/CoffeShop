using CoffeShop.Models.Interfaces;
using CoffeShop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: /Products/Shop  – trang công khai hiển thị sản phẩm nổi bật
        [AllowAnonymous]
        public IActionResult Shop()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        // GET: /Products/GetAll?searchString=...&type=...  – trang quản lý (cần đăng nhập)
        public IActionResult GetAll(string? searchString, string? type)
        {
            var products = _productRepository.GetAll(searchString, type);
            return View(products);
        }

        // GET: /Products/Detail/id
        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return View("NotFound");
            return View(product);
        }

        // GET: /Products/Add
        [Authorize(Roles = "Admin,Editor")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Products/Add
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public IActionResult Add(VMProduct productData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepository.AddProduct(productData);
                    TempData["successMessage"] = "Thêm sản phẩm thành công!";
                    return RedirectToAction("GetAll");
                }
                TempData["errorMessage"] = "Dữ liệu không hợp lệ.";
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: /Products/Edit/id
        [Authorize(Roles = "Admin,Editor")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return View("NotFound");

            var vm = new VMProduct
            {
                Id = product.Id,
                Name = product.Name,
                Detail = product.Detail,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                IsTrendingProduct = product.IsTrendingProduct ? "true" : "false"
            };
            return View(vm);
        }

        // POST: /Products/Edit/id
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, VMProduct productData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existing = _productRepository.GetProductById(id);
                    if (existing == null)
                        return View("NotFound");

                    _productRepository.UpdateProduct(id, productData);
                    TempData["successMessage"] = "Cập nhật thành công!";
                    return RedirectToAction("GetAll");
                }
                TempData["errorMessage"] = "Dữ liệu không hợp lệ.";
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: /Products/Delete/id
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return View("NotFound");

            _productRepository.DeleteProduct(id);
            TempData["successMessage"] = "Đã xóa sản phẩm!";
            return RedirectToAction("GetAll");
        }
    }
}
