using System;
namespace Tp_PreguntadOrt;
public class Respuesta
{
    private  int _IdRespuesta;
    private  int _IdPregunta;
    private  int _Opcion;
    private  string _Contenido;
    private  bool _Correcta;
    private  string _Foto;

    
    

    public Respuesta (int idRespuesta, int idPregunta, int opcion, string contenido, bool correcta,string foto)
    {
        _IdRespuesta=idRespuesta;
        _IdPregunta=idPregunta;
        _Opcion=opcion;
        _Contenido=contenido;
        _Correcta=correcta;
        _Foto=foto;
    }

    public Respuesta ()
    {
        _IdPregunta=0;
        _Opcion=0;
        _Contenido="";
        _Foto="";
    }

    public int IdPregunta 
        {
            get { return _IdPregunta; }
            set { _IdPregunta=value; }
        }
    
    public int IdCategoria 
        {
            get { return _IdCategoria; }
            set { _IdCategoria=value; }
        }
    
    public int IdDificultad 
        {
            get { return _IdDificultad; }
            set { _IdDificultad=value; }
        }
    
    public string Enunciado 
        {
            get { return _Enunciado; }
            set { _Enunciado=value; }
        }
    
    public string Foto 
        {
            get { return _Foto; }
            set { _Foto=value; }
        }

}
