using System;
namespace Tp_PreguntadOrt;
public class Pregunta
{
    private  int _IdPregunta;
    private  int _IdCategoria;
    private  int _IdDificultad;
    private  string _Enunciado;
    private  string _Foto;

    
    

    public Pregunta (int idPregunta, int idCategoria, int idDificultad, string enunciado, string foto)
    {
        _IdPregunta=idPregunta;
        _IdCategoria=idCategoria;
        _IdDificultad=idDificultad;
        _Enunciado=enunciado;
        _Foto=foto;
    }

    public Pregunta ()
    {
        _IdCategoria=0;
        _IdDificultad=0;
        _Enunciado="";
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
