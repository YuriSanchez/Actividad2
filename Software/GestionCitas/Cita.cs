using System;

public class Cita
{
    public int Id { get; set; }
    public string Paciente { get; set; }
    public string Medico { get; set; }
    public DateTime Fecha { get; set; }

    public Cita(int id, string paciente, string medico, DateTime fecha)
    {
        Id = id;
        Paciente = paciente;
        Medico = medico;
        Fecha = fecha;
    }
}
