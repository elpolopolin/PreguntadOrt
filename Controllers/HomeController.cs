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

      public IActionResult tutorial()
    {
        return View();
    }

    public IActionResult historia()
    {
        return View();
    }

     public IActionResult historia2()
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
    
        ViewBag.Username = Juego.username;
        ViewBag.PuntajeActual = Juego.PuntajeActual;
        ViewBag.RespuestasCorrectas = Juego.cantidadPreguntasCorrectas ;

        if(Juego.ObtenerProximaPregunta() != null)
        {
            ViewBag.Foto = Juego.ObtenerProximaPregunta().Foto;
            ViewBag.Dificultad = Juego.ObtenerProximaPregunta().IdDificultad;
            ViewBag.Enunciado = Juego.ObtenerProximaPregunta().Enunciado;
           ViewBag.Respuestas = Juego.ObtenerProximaRespuesta(Juego.ObtenerProximaPregunta().IdPregunta);
           ViewBag.IdPregunta = Juego.ObtenerProximaPregunta().IdPregunta;
          
            return View("Jugar");   
        }
        else
        {
           // DateTime dia = DateTime.Now;
           // ScoreBoard puntaje = new ScoreBoard(Juego.Username, Juego.PuntajeActual, dia);
           // BD.IsertarScoreboard(puntaje);
            return View("Fin");
        }
    }


    public IActionResult VerificarRespuesta(int IdPregunta,int IdRespuesta, int IdDificultad)
    {
        string opcionCorrecta = "aaaa";
        foreach(Respuesta item in BD.ObtenerProximasRespuestas(IdPregunta)){
            if (item.Correcta == true)
            {
                
                opcionCorrecta = item.Contenido;
            }
            
        }

        bool resultado = Juego.VerificarRespuesta(IdPregunta, IdRespuesta, IdDificultad);

        if(resultado == true)
        {
            ViewBag.Resultado=true;
            ViewBag.Mensaje = "Respuesta correcta";
            
        }
        else
        {
            ViewBag.Resultado = false;
            ViewBag.Mensaje="Respuesta incorrecta";
            ViewBag.opcionCorrecta = opcionCorrecta;
        }
        return View("Respuesta");
    }
 
 

}
