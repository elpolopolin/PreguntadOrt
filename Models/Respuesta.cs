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
    
    
    public string Foto 
        {
            get { return _Foto; }
            set { _Foto=value; }
        }

        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion=value; }
        }


         public string Contenido
        {
            get { return _Contenido; }
            set { _Contenido=value; }
        }

          public bool Correcta
        {
            get { return _Correcta; }
            set { _Correcta=value; }
        }
}
