using System;
namespace Tp_PreguntadOrt;
public class Juego
{
    private string _username;
    private int _puntajeActual;
    private int _cantidadPreguntasCorrectas;
    private List<Pregunta> _preguntas;
    private List<Respuesta> _respuestas;

    public Juego(string username, int puntajeActual, int cantidadPreguntasCorrectas, List <Pregunta> preguntas, List <Respuesta> respuestas )
    {
        _username=username;
        _puntajeActual=puntajeActual;
        _cantidadPreguntasCorrectas=cantidadPreguntasCorrectas;
        _preguntas=preguntas;
        _respuestas=respuestas;
    }

     public static void InicializarJuego()
    {
        _username="";
        _puntajeActual=0;
        _cantidadPreguntasCorrectas=0;
        
    }

    public static void ObtenerCategorias {
        
    }

    public string username 
        {
            get { return _username; }
            set { _username=value; }
        }
    
    public int puntajeActual 
        {
            get { return _puntajeActual; }
            set { _puntajeActual=value; }
        }
    
    public int cantidadPreguntasCorrectas 
        {
            get { return _cantidadPreguntasCorrectas; }
            set { _cantidadPreguntasCorrectas=value; }
        }

    
    public List <Pregunta> preguntas
    {
        get { return _preguntas; }
        set { _preguntas=value; }
    }

    public List <Respuesta> respuestas
    {
        get { return _respuestas; }
        set { _respuestas=value; }
    }



}
