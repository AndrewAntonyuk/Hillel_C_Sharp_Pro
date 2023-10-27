using InternetShop.Data;
using InternetShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly ICartRepository cartRepository;
        private const int UserId = 1;

        public OrdersController(IOrdersRepository ordersRepository, ICartRepository cartRepository)
        {
            this.ordersRepository = ordersRepository;
            this.cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(ordersRepository.GetUserOrdersWithDetails(UserId));
        }

        public IActionResult Details(int id)
        {
            var order = ordersRepository.GetOrderWithDetails(id);

            if (order != null)
            {
                return View(order);
            }

            return View("DoesNotExist");
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            var cartItems = cartRepository.GetUserCartItems(UserId);

            ViewData["total"] = cartItems.Select(c => c.Product.Price * c.Quantity).Sum() + 10;

            return View(cartItems);
        }

        public async Task<IActionResult> PlaceOrderConfirmed()
        {
            ordersRepository.ConfirmOrder(UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Manage()
        {
            var orders = ordersRepository.GetAllOrders();

            return View(orders);
        }
	}
}
