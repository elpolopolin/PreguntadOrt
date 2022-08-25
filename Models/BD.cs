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

           public static List<Pregunta> ObtenerPreguntas()
        {
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            string sql = "SELECT * FROM Preguntas";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            return listaPreguntas;
        }

          public static List<Respuesta> ObtenerRespuestas()
        {
            List<Respuesta> listaRespuestas = new List<Respuesta>();
            string sql = "SELECT * FROM Respuestas";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaRespuestas = db.Query<Respuesta>(sql).ToList();
            }
            return listaRespuestas;
        }

    }
}


        