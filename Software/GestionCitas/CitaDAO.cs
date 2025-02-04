using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class CitaDAO
{
    public static List<Cita> ObtenerCitas()
    {
        List<Cita> listaCitas = new List<Cita>();
        using (MySqlConnection conn = ConexionBD.ObtenerConexion())
        {
            string query = "SELECT * FROM citas";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cita cita = new Cita(
                    reader.GetInt32("id"),
                    reader.GetString("paciente"),
                    reader.GetString("medico"),
                    reader.GetDateTime("fecha")
                );
                listaCitas.Add(cita);
            }
        }
        return listaCitas;
    }

    public static void AgregarCita(string paciente, string medico, DateTime fecha)
    {
        using (MySqlConnection conn = ConexionBD.ObtenerConexion())
        {
            string query = "INSERT INTO citas (paciente, medico, fecha) VALUES (@paciente, @medico, @fecha)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@paciente", paciente);
            cmd.Parameters.AddWithValue("@medico", medico);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Cita agregada correctamente.");
    }
}
