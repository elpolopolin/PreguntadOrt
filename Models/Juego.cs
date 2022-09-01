using System.Collections.Generic;
using System;
namespace Tp_PreguntadOrt.Models
{
public class Juego
{
    private static string _username;
    private static int _puntajeActual;
    private static int _cantidadPreguntasCorrectas;
    private static List<Pregunta> _preguntas;
    private static List<Respuesta> _respuestas;

    public Juego(string username, int puntajeActual, int cantidadPreguntasCorrectas, List <Pregunta> preguntas, List <Respuesta> respuestas )
    {
        _username=username;
        _puntajeActual=puntajeActual;
        _cantidadPreguntasCorrectas=cantidadPreguntasCorrectas;
        _preguntas=preguntas;
        _respuestas=respuestas;
    }
    
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

    public static List<Dificultad> ObtenerDificultad()
    {
        return BD.ObtenerDificultades();
    }

     public static List<Categoria> ObtenerCategoria()
    {
        return BD.ObtenerCategorias();
    }



    public static void CargarPartida(string username, int dificultad, int categoria, int idRespuesta)
    {
        ViewBag._preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        ViewBag._respuestas = BD.ObtenerRespuestas(_preguntas, idRespuesta);
    }


    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        foreach(Respuesta resp in _respuestas){
            if(resp.IdRespuesta == idRespuesta){
                if (resp.Correcta == true){

                    _puntajeActual += 5;
                    _cantidadPreguntasCorrectas++;

                    return true;
                }
            }
        }

        foreach(Pregunta preg in _preguntas){
            if(preg.IdPregunta == idPregunta){
                int indicePreguntaContestada = _preguntas.IndexOf(preg);
                _preguntas.RemoveAt(indicePreguntaContestada);
            }
        }
    }

    /*
    public static List<Pregunta> ObtenerPreguntas(int IdDificultad, int IdCategoria)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Preguntas";
        string connector = " WHERE ";

        if(idCategoria != -1)
        {
            SQL = SQL + connector + "IdCategoria = @pIdCategoria";
            connector = " AND ";
        }
        if (idDificultad != -1)
        {
            SQL = SQL + connector + "IdDificultad = @pIdDificultad";
        }
        SQL = SQL + " order by NEWID() ";
        _ListaPreguntas = db.Query<pregunta>(SQL, new{pIdCategoria = IdCategoria, pIdDificultad = IdDificultad}).ToList;

        }
        return _ListaPreguntas;
        
    }
    */

    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();
       //"va a la base(BD) de datos y trae las categorias de las listas y lo asigna en categorias (lo mismo con preguntas)"
    }
    

}
}
