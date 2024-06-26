using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;

namespace Tp_PreguntadOrt.Models{
    public static class BD
    {
    
    private static List<Pregunta> _ListaPreguntas = new List<Pregunta>();
        private static List<Respuesta> _ListaRespuestas = new List<Respuesta>();
        private static List<Categoria> _ListaCategorias = new List<Categoria>();
        private static List<Dificultad> _ListaDificultades = new List<Dificultad>();

        
        private static string _connectionString =  @$"Server=127.0.0.1;DataBase=PreguntadOrt;Trusted_Connection=True";
       
           public static List<Dificultad> ObtenerDificultades()
        {

            List<Dificultad> listaDificultades = new List<Dificultad>();
            string sql = "SELECT * FROM Dificultades";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaDificultades = db.Query<Dificultad>(sql).ToList();
            }
            return listaDificultades;
        }


        public static List<Categoria> ObtenerCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            string sql = "SELECT * FROM Categorias";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaCategorias = db.Query<Categoria>(sql).ToList();
            }
            return listaCategorias;
        }




           public static List<Pregunta> ObtenerPreguntas(int idDificultad, int idCategoria)
        {
            string p = " ORDER BY NEWID()";
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            string sql = "SELECT * FROM Preguntas WHERE idCategoria = @pidCategoria AND idCategoria = @pidCategoria";
            if (idDificultad == -1  && idCategoria == -1)
            {
                sql = "SELECT * FROM Preguntas";
            }
            if (idDificultad == -1)
            {
                sql = "SELECT * FROM Preguntas WHERE idCategoria = @pidCategoria";
            }
            if (idCategoria == -1)
            {
            sql = "SELECT * FROM Preguntas WHERE idDificultad = @pidDificultad";
            }
            sql += p;
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaPreguntas = db.Query<Pregunta>(sql, new{pidCategoria = idCategoria, pidDificultad=idDificultad}).ToList();

            }
            return listaPreguntas;
        }
        

          public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
        {
            List<Respuesta> listaRespuestas = new List<Respuesta>();
            foreach(Pregunta preg in preguntas)
            {
                 string sql = "SELECT * FROM Respuesta WHERE idPregunta=@pidPregunta";
                  using(SqlConnection db = new SqlConnection(_connectionString))
                  {
                    listaRespuestas.AddRange(db.Query<Respuesta>(sql, new{pidPregunta = preg.IdPregunta}));
                  }

            }
       
            return listaRespuestas;
        }

             public static List<Respuesta> ObtenerProximasRespuestas(int IdPregunta)
        {
            using(SqlConnection db = new SqlConnection(_connectionString)){
            
                string SQL = "SELECT * FROM Respuesta WHERE IdPregunta = @pIdPregunta";
                _ListaRespuestas = db.Query<Respuesta>(SQL, new{pIdPregunta = IdPregunta}).ToList();
            }
            return _ListaRespuestas;
        }

    }
}


        