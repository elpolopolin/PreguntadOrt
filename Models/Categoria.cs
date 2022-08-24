using System;
namespace Tp_PreguntadOrt;
public class Categoria
{
    private  int _IdCategoria;
    private  string _Nombre;
    private  string _Foto;

    
    

    public Categoria (int idCategoria, string nombre, string foto)
    {
        _IdCategoria=idCategoria;
        _Nombre=nombre;
        _Foto=foto;
    }

    public Categoria ()
    {
        _IdCategoria=0;
        _Nombre="";
        _Foto="";
    }
    public int IdCategoria 
        {
            get { return _IdCategoria; }
            set { _IdCategoria=value; }
        }
    
    public string nombre 
        {
            get { return _Nombre; }
            set { _Nombre=value; }
        }
    
    public string Foto 
        {
            get { return _Foto; }
            set { _Foto=value; }
        }

}
