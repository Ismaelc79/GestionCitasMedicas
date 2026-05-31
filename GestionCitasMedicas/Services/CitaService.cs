using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCitasMedicas.Services
{
    public class CitaService
    {
        private IRepository<Cita> repository;
        public CitaService(IRepository<Cita> repository)
        {
            this.repository = repository;
        }

        public void AgendarCita(
           Paciente paciente,
           Medico medico, 
           DateTime fechaHora,
           String idCita)
        {
            Cita cita = new Cita();

            cita.Paciente = paciente;
            cita.Medico = medico;
            cita.FechaHoraCita = fechaHora;
            cita.IdCita = idCita;
            repository.Agregar(cita);
            Console.WriteLine("Cita médica agendada con éxito!"); 
           
        }
        public void ConsultarCitasPorPaciente(Paciente paciente)
        {
           Console.WriteLine("Consultando citas médicas...");

            repository.ObtenerTodos().ForEach(c =>
            {
                if (c.Paciente.IdPaciente == paciente.IdPaciente)
                {
                    Console.WriteLine($"Cita ID: {c.IdCita}, Médico: {c.Medico.Nombre}, Fecha y Hora: {c.FechaHoraCita}");
                }
            });

        }

        public void ConsultarCitasPorMedico(Medico medico)
        {
            Console.WriteLine("Consultando citas médicas...");

            repository.ObtenerTodos().ForEach(c =>
            {
                if (c.Medico.IdMedico == medico.IdMedico)
                {
                    Console.WriteLine($"Cita ID: {c.IdCita}, Paciente: {c.Paciente.Nombre}, Fecha y Hora: {c.FechaHoraCita}");
                }
            });
        }

        public void cancelarCita(Paciente paciente, Medico medico, Cita cita)
        {
            Console.WriteLine("Cancelando cita médica...");
            repository.ObtenerTodos().ForEach(c =>
            {
                if (c.Paciente.IdPaciente == paciente.IdPaciente && 
                c.Medico.IdMedico == medico.IdMedico && 
                c.IdCita == cita.IdCita)
                {
                  repository.Eliminar(c);
                }
            });

        }
        public void ReprogramarCita(Paciente paciente, Medico medico, Cita cita)
        {
            Console.WriteLine("Reprogramando cita médica...");
            repository.ObtenerTodos().ForEach(c =>
            {
                if (c.Paciente.IdPaciente == paciente.IdPaciente &&
                c.Medico.IdMedico == medico.IdMedico &&
                c.IdCita == cita.IdCita)
                {
                    Console.WriteLine("Ingrese la nueva fecha y hora para la cita:");
                    DateTime nuevaFechaHora = DateTime.Parse(Console.ReadLine());
                    c.FechaHoraCita = nuevaFechaHora;
                    Console.WriteLine("Cita médica reprogramada con éxito!");
                }
            });
        }
    }
}
