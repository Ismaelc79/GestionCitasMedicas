using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Repositories;
using GestionCitasMedicas.Validators;
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
         string idCita,
         Paciente paciente,
         Medico medico,
         DateTime fechaHora)
        {
            if(!CitaValidacion.ValidarFechaHora(fechaHora))
            {
                Console.WriteLine("La fecha y hora de la cita no pueden ser en el pasado.");
                return;
            }

            Cita cita = new Cita
            {
                IdCita = idCita,
                Paciente = paciente,
                Medico = medico,
                FechaHora = fechaHora,
                EstadoCita = "Activa"
            };

            repository.Agregar(cita);
            Console.WriteLine("Cita agendada con éxito");
        }

        public void ConsultarCitasPorPaciente(string idPaciente )
        {
           List<Cita> citas = repository.ObtenerTodos();
           bool encontrado = false;

            foreach( Cita cita in citas )
            {
                if (cita.Paciente.IdPaciente == idPaciente)
                {
                    Console.WriteLine($"Cita ID: {cita.IdCita}, Médico: {cita.Medico.Nombre}, Fecha y Hora: {cita.FechaHora} {cita.EstadoCita}");
                    encontrado = true;
                }
            }
            if(!encontrado)
           Console.WriteLine("No hay citas disponibles para este paciente");
        }

        public void ConsultarCitasPorMedico(string idMedico)
        {
            List<Cita> citas = repository.ObtenerTodos();
            bool encontrado = false;
             foreach( Cita cita in citas )
             {
                 if (cita.Medico.IdMedico == idMedico)
                 {
                     Console.WriteLine($"Cita ID: {cita.IdCita}, Paciente: {cita.Paciente.Nombre}, Fecha y Hora: {cita.FechaHora} {cita.EstadoCita}");
                     encontrado = true;
                 }
             }
             if(!encontrado)
                Console.WriteLine("No hay citas disponibles para este médico");
          
        }

        public void CancelarCita(string idCita)
        {
            List<Cita> citas = repository.ObtenerTodos();
            foreach( Cita cita in citas)
            {
                if (cita.IdCita == idCita)
                {
                    cita.EstadoCita = "Cancelada";
                    Console.WriteLine("Cita cancelada con éxito!");
                    return;
                }
            }
            Console.WriteLine("Cita no encontrada");
        }
        public void ReprogramarCita(string idCita, DateTime nuevaFecha)
        {
            if (!CitaValidacion.ValidarFechaHora(nuevaFecha))
            {
                Console.WriteLine("La nueva fecha debe ser posterior a la fecha actual");
                return;
            }

            List<Cita> citas = repository.ObtenerTodos();

            foreach( Cita cita in citas)
            {
               if(cita.IdCita == idCita)
                {
                    cita.FechaHora = nuevaFecha;
                    Console.WriteLine("Cita reprogramada con éxito!");
                    return;
                }
            }
            Console.WriteLine("Cita no encontrada");
           
        }

        public List<Cita> ObtenerTodasCitas()
        {
            return repository.ObtenerTodos();
        }
    }
}
