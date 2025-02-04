using MySql.Data.MySqlClient;
using System;

class ConexionBD
{
    private static string connectionString = "Server=localhost; Port=3306; Database=clinica; Uid=root; Pwd=Gaby0455*;";

    public static MySqlConnection ObtenerConexion()
    {
        MySqlConnection conn = new MySqlConnection(connectionString);

        try
        {
            conn.Open();
            Console.WriteLine("✅ Conexión exitosa a la base de datos.");
            return conn;
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error de conexión: " + ex.Message);
            return null;
        }
    }
}
