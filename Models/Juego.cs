using System.Collections.Generic;
using System;
namespace Tp_PreguntadOrt.Models
{
public class Juego
{
    private static string _username;
    private static int _puntajeActual;
    private static int _cantidadPreguntasCorrectas;
    private static List <Pregunta>_preguntas=new List<Pregunta>();
    private static List <Respuesta>_respuestas=new List<Respuesta>();
    private static List <Categoria>_categorias=new List<Categoria>();
    private static List <Dificultad>_dificultad=new List<Dificultad>();


    private static string _connectionString =  @$"Server=127.0.0.1;DataBase=PreguntadOrt;Trusted_Connection=True";

    public static string username 
        {
            get { return _username; }
            set { _username=value; }
        }
    
    public static int puntajeActual 
        {
            get { return _puntajeActual; }
            set { _puntajeActual=value; }
        }
    
    public static int cantidadPreguntasCorrectas 
        {
            get { return _cantidadPreguntasCorrectas; }
            set { _cantidadPreguntasCorrectas=value; }
        }

    
    public static List <Pregunta> preguntas
    {
        get { return _preguntas; }
        set { _preguntas=value; }
    }

    public static List <Respuesta> respuestas
    {
        get { return _respuestas; }
        set { _respuestas=value; }
    }

    public static void InicializarJuego()
    {
        _username="";
        _puntajeActual=0;
        _cantidadPreguntasCorrectas=0;
        _preguntas=null;
        _respuestas=null;
        
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        _dificultad= BD.ObtenerDificultades();
        return _dificultad;
        
    }

     public static List<Categoria> ObtenerCategoria()
    {
        _categorias= BD.ObtenerCategorias();
        return _categorias;
    }



    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        _username=username;
        _preguntas = BD.ObtenerPreguntas(categoria, dificultad);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
    }

    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }


    //ObtenerProximaPregunta
    public static Pregunta ObtenerProximaPregunta()
    {
        var random=new Random();
        int pos=random.Next(_preguntas.Count);
        return pos[_preguntas];
    }

    //ObtenerProximasRespuestas
    public static List<Respuesta> ObtenerProximaRespuesta(int idPregunta)
    {
        if(_preguntas.Count()>0)
        {
            return BD.ObtenerRespuestas(preguntas, idPregunta);
        }

        else{
            return null;
        }

    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool Correcta = false;

       foreach(Respuesta resp in _respuestas){
            if(resp.IdRespuesta == idRespuesta){
                if (resp.Correcta == true){

                    _puntajeActual += 5;
                    _cantidadPreguntasCorrectas++;

                    return Correcta;
                }
            }
        }
        
        foreach(Pregunta preg in _preguntas){
            if(preg.IdPregunta == idPregunta){
                int indicePreguntaContestada = _preguntas.IndexOf(preg);
                _preguntas.RemoveAt(indicePreguntaContestada);
            }
        }
        return Correcta;
    }
    
    }

   

   
 
    

}


