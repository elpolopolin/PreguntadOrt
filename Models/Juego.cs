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
    
    public static int PuntajeActual 
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
       // Random random = new Random();
       // int rnd;

        _preguntas = BD.ObtenerPreguntas(categoria, dificultad);
        //int cant = _preguntas.Count();

       /* for (int i = 0; i<cant; i++){
            rnd = random.Next(0,cant);
            Pregunta temporal = _preguntas[rnd];
            _preguntas[rnd] = _preguntas[i];
            _preguntas[i] = temporal;
        }
        */
        _respuestas = BD.ObtenerRespuestas(_preguntas);
        _username = username;
    }

    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }


    //ObtenerProximaPregunta
    public static Pregunta ObtenerProximaPregunta()
    {
        if(_preguntas.Count() > 0)
        {
            return _preguntas[0];
        }
        else
        {
            return null;
        }

    }

     public static string UserNameView()
    {
        return username;
    }

    

    //ObtenerProximasRespuestas
    public static List<Respuesta> ObtenerProximaRespuesta(int idPregunta)
    {
       /*aca las repuestas las obtenes de la lista*/
      
       if (_preguntas.Count > 0)
       {
        return BD.ObtenerProximasRespuestas(idPregunta);
       }
       else {
        return null;
       }
    
      
    }

    public static bool VerificarRespuesta(int IdPregunta, int IdRespuesta, int IdDificultad )
    {
       
       for (int i = 0; i<_preguntas.Count(); i++)
       {
        if (_preguntas[i].IdPregunta == IdPregunta)
        {
            _preguntas.RemoveAt(i);
        }
       }

       foreach(Respuesta resp in _respuestas){
            if(resp.IdRespuesta == IdRespuesta){
                if (resp.Correcta == true){
                     _puntajeActual += 9;
                    switch(IdDificultad){

                        case 1:
                        _puntajeActual += 5;
                        break;
                        case 2:
                        _puntajeActual += 10;
                        break;
                        case 3:
                        _puntajeActual += 15;
                        break;

                    }
                    _cantidadPreguntasCorrectas++;

                    return true;
                }
            }
        }

        
        
        return false;
    }
}

}

    
    


    



