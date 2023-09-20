using Microsoft.AspNetCore.Mvc;

namespace DazzlingStore.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class DashboardController : Controller
{
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
}
