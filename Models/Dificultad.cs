using System;
namespace Tp_PreguntadOrt;
public class Dificultad
{
    private  int _IdDificultad;
    private  string _Nombre;  

    public Dificultad (int idDificultad, string nombre)
    {
        _IdDificultad=idDificultad;
        _Nombre=nombre;
    }

    public Dificultad ()
    {
        _Nombre="";
        _IdDificultad=0;
    }
    public int IdDificultad 
        {
            get { return _IdDificultad; }
            set { _IdDificultad=value; }
        }

    public string nombre 
        {
            get { return _Nombre; }
            set { _Nombre=value; }
        }
}
