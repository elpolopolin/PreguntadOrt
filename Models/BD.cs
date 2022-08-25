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
    
        private static string server = Dns.GetHostName();
        private static string _connectionString =  @$"Server={server};DataBase=PreguntadOrt;Trusted_Connection=True";
       
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

    }

        