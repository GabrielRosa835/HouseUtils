using HouseUtils.Presentation.Res;
using HouseUtils.Presentation.Views.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseUtils.Presentation.Controllers;

public class HomeController : Controller
{
   public IActionResult Index () => View();

   [HttpGet(Routes.C.REGISTRY)]
   public IActionResult Registry () => View();

   [HttpGet(Routes.C.SERVICES)]
   public IActionResult Services () => View();

   [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
   public IActionResult Error () => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
