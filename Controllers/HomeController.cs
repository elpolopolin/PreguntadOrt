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


    //!
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult historia()
    {
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Categoria = Juego.ObtenerCategorias();
        ViewBag.Dificultad = Juego.ObtenerDificultades();
        return View();
        

    }

    public IActionResult Comenzar(string Username, int IdDificultad, int IdCategoria)
    {
        Juego.CargarPartida(Username,IdDificultad,IdCategoria);
        //return RedirectToAction("Jugar","Home",new{Username=Username, IdDificultad=IdDificultad, IdCategoria=IdCategoria});
        return RedirectToAction("Jugar","Home");
    }

    /*jugar
    Carga en ViewBag todo lo necesario para mostrar la pregunta
actual con sus respectivas respuestas (que proviene del método ObtenerProximaPregunta.
Si ya no hay más preguntas disponibles, retorna la view Fin. Si el método retorna una
pregunta, invoca a ObtenerProximasRespuestas de la clase Juego guardando estos datos
en ViewBag y retorna la view Juego.
*/

//public IActionResult Jugar(List <Pregunta> _preguntas)
public IActionResult Jugar()
    {
        ViewBag.preguntas=Juego.ObtenerProximaPregunta();
       ViewBag.respuestas=Juego.ObtenerProximaRespuesta(ViewBag.preguntas);

        if(ViewBag.preguntas != null)
        {
            return View("FIN");
        }

        
            return View("Jugar");
        
    }


    public IActionResult VerificarRespuesta(int idPregunta,int idRespuesta)
    {
        if(Juego.VerificarRespuesta(idPregunta,idRespuesta)==true)
        {
            ViewBag.Mensaje="Respuesta correcta";
        }
        else
        {
            ViewBag.Mensaje="Respuesta incorrecta";
        }
        return View("Respuesta");
    }
 
 

}
