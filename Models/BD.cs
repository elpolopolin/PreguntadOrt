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

        private static string _connectionString =  @"Server=DESKTOP-885T6PK\SQLEXPRESS;DataBase=Qatar2022;Trusted_Connection=True";
       

        public static List<Juego> ListarEquipos()
        {
            List<Equipo> lista = new List<Equipo>();
            string sql = "SELECT * FROM Equipos";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                lista = db.Query<Equipo>(sql).ToList();
            }
            return lista;
        }
    }

        