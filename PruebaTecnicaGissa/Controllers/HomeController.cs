using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGissa.Models;
using System.Diagnostics;
using PruebaTecnicaGissa.Permisos;
namespace PruebaTecnicaGissa.Controllers
{
	[ValidarSesion]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult CerrarSesion()
		{
			HttpContext.Session.GetString("usuario");

            HttpContext.Session.SetString("usuario", "");

			return RedirectToAction("Login", "Acceso");
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


	}
}