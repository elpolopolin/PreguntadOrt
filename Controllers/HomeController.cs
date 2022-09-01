using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp_PreguntadOrt.Models;

namespace Tp_PreguntadOrt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Index()
    {
        ViewBag.Lista = BD.ObtenerPreguntas();
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        ViewBag.Juego.InicializarJuego();
        ViewBag.Categoria = BD.ObtenerCategorias();
        ViewBag.Dificultad = BD.ObtenerDificultades();
        return View();
        

    }

}
