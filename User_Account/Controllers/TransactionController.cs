using Microsoft.AspNetCore.Mvc;

namespace User_Account.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
