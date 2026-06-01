using CoffeShop.Data;
using CoffeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class ContactController : Controller
    {
        private readonly CoffeeshopDbContext _context;

        // Gọi DBContext để có thể lưu dữ liệu
        public ContactController(CoffeeshopDbContext context)
        {
            _context = context;
        }

        // Hiển thị giao diện Form Contact
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Xử lý khi người dùng bấm nút Send
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                // Lưu vào database
                _context.Contacts.Add(contact);
                _context.SaveChanges();

                // Gửi thông báo thành công ra ngoài View
                TempData["SuccessMessage"] = "Cảm ơn bạn! Tin nhắn của bạn đã được gửi thành công.";

                // Tải lại trang trắng
                return RedirectToAction("Index");
            }

            // Nếu nhập sai (ví dụ thiếu email), trả lại form kèm báo lỗi
            return View(contact);
        }
    }
}