using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Dapper;

namespace Tp_PreguntadOrt.Models
    public static class BD
    {

        private static string _connectionString = 
        @"Server=DESKTOP-885T6PK\SQLEXPRESS;DataBase=Qatar2022;Trusted_Connection=True";

        public static void AgregarEquipo(Equipo Eq)
        {
            string sql = "INSERT INTO Equipos VALUES (@pNombre, @pEscudo, @pCamiseta, @pContinente, @pCopasGanadas)";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, new { pNombre = Eq.Nombre, pEscudo = Eq.Escudo, pCamiseta = Eq.Camiseta, pContinente = Eq.Continente, pCopasGanadas = Eq.CopasGanadas});
            }
        }
    }

        