using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Notifications;
using GestionCitasMedicas.Repositories;
using GestionCitasMedicas.Services;
using System.Security.Cryptography.X509Certificates;

IRepository<Paciente> pacienteRepository = new PacienteRepository();
IRepository<Medico> medicoRepository = new MedicoRepository();
IRepository<Especialidad> especialidadRepository = new EspecialidadRepository();
IRepository<Cita> citaRepository = new CitaRepository();
INotificacionService notificacionService = new EmailNotificationService();

PacienteService pacienteService = new PacienteService(pacienteRepository);
MedicoService medicoService = new MedicoService(medicoRepository);
CitaService citaService = new CitaService(citaRepository);
EspecialidadService especialidadService = new EspecialidadService(especialidadRepository);
RecordatorioService recordatorioService = new RecordatorioService(notificacionService);

bool salir = false; 

while (!salir) {

    Console.Clear();

    Console.WriteLine("+----------Sistema de Gestión de Citas Médicas----------+");
    Console.WriteLine("1. Registrar pacientes");
    Console.WriteLine("2. Registrar médicos");
    Console.WriteLine("3. Registrar especialidades médicas");
    Console.WriteLine("4. Asignar médicos a una especialidad");
    Console.WriteLine("5. Agendar citas médicas");
    Console.WriteLine("6. Consultar citas por paciente");
    Console.WriteLine("7. Consultar citas por médico");
    Console.WriteLine("8. Cancelar citas");
    Console.WriteLine("9. Reprogramar citas");
    Console.WriteLine("10. Enviar recordatorio de citas");
    Console.WriteLine("0. Salir del sistema");

    Console.Write("Ingrese su opción: ");
    String? opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
        Console.WriteLine("== Registrar pacientes ==");
            string id = LeerTexto("ID del paciente:");
            string nombre = LeerTexto("Nombre:");
            string apellido = LeerTexto("Apellido:");
            string cedula = LeerTexto("Cédula (10 dígitos):");
            string telefono = LeerTexto("Teléfono:");
            string correo = LeerTexto("Correo:");

            pacienteService.RegistrarPaciente(
            id,nombre,apellido,cedula, telefono, correo);
            break;

        case "2":
            Console.WriteLine("== Registrar médicos ==");
            string idMedico = LeerTexto("ID Médico: ");
            string nombreMedico = LeerTexto("Nombre:");
            string apellidoMedico = LeerTexto("Apellido:");
            string cedulaMedico = LeerTexto("Cédula (10 dígitos):");
            string telefonoMedico = LeerTexto("Teléfono:");
            string correoMedico = LeerTexto("Correo:");

            medicoService.RegistrarMedico(idMedico,nombreMedico, apellidoMedico,cedulaMedico,
            telefonoMedico, correoMedico);
            break;

        case "3":
            Console.WriteLine("== Registrar Especialidad ==");
                string idEspecialidad = LeerTexto("ID Especialidad:");
                string nombreEspecialidad = LeerTexto("Nombre de la especialidad:");
            especialidadService.RegistrarEspecialidad(idEspecialidad, nombreEspecialidad);
            break;

        case "4":
            Console.WriteLine("==Asignar Especialidad a Médico==");
            MostrarMedicos(medicoRepository);
            MostrarEspecialidades(especialidadRepository);

            string idMedAsignar = LeerTexto("Ingrese el ID del médico:");
            string idEspAsignar = LeerTexto("Ingrese el ID de la especialidad:");

            Medico medicoAsignar = BuscarMedico(medicoRepository, idMedAsignar);
            Especialidad espAsignar = BuscarEspecialidad(especialidadRepository, idEspAsignar);

            if(medicoAsignar != null && espAsignar != null)
                especialidadService.AsignarMedicoEspecialidad(medicoAsignar, espAsignar);
            else
                Console.WriteLine("Médico o especialidad no encontrado");  
            break;

        case "5":
            Console.WriteLine("\n== Agendar Cita ==");
            MostrarPacientes(pacienteRepository);
            MostrarMedicos(medicoRepository);

            string idPacCita = LeerTexto("ID del paciente: ");
            string idMedCita = LeerTexto("ID del médico: ");

            Paciente pacienteCita = BuscarPaciente(pacienteRepository, idPacCita);
            Medico medicoCita = BuscarMedico(medicoRepository, idMedCita);

            if (pacienteCita == null || medicoCita == null)
            {
                Console.WriteLine("Paciente o médico no encontrado.");
                break;
            }

            string idCita = LeerTexto("ID de la cita: ");
            DateTime fechaCita = LeerFecha("Fecha y hora (dd/MM/yyyy HH:mm): ");
            citaService.AgendarCita(idCita, pacienteCita, medicoCita, fechaCita);
            break;

        case "6":
            Console.WriteLine("\n== Consultar Citas por Paciente ==");
            MostrarPacientes(pacienteRepository);
            string idPacConsulta = LeerTexto("ID del paciente: ");
            citaService.ConsultarCitasPorPaciente(idPacConsulta);
            break;

        case "7":
            Console.WriteLine("\n== Consultar Citas por Médico ==");
            MostrarMedicos(medicoRepository);
            string idMedConsulta = LeerTexto("ID del médico: ");
            citaService.ConsultarCitasPorMedico(idMedConsulta);
            break;

        case "8":
            Console.WriteLine("\n== Cancelar Cita ==");
            MostrarCitas(citaRepository);
            string idCitaCancelar = LeerTexto("ID de la cita a cancelar: ");
            citaService.CancelarCita(idCitaCancelar);
            break;

        case "9":
            Console.WriteLine("\n== Reprogramar Cita ==");
            MostrarCitas(citaRepository);
            string idCitaReprog = LeerTexto("ID de la cita a reprogramar: ");
            DateTime nuevaFecha = LeerFecha("Nueva fecha y hora (dd/MM/yyyy HH:mm): ");
            citaService.ReprogramarCita(idCitaReprog, nuevaFecha);
            break;

        case "10":
            Console.WriteLine("\n== Enviar Recordatorio ==");
            MostrarCitas(citaRepository);
            string idCitaRecord = LeerTexto("ID de la cita: ");
            Cita citaRecord = BuscarCita(citaRepository, idCitaRecord);
            if (citaRecord != null)
                recordatorioService.EnviarRecordatorio(citaRecord);
            else
                Console.WriteLine("Cita no encontrada.");
            break;

        case "0":
            Console.WriteLine("Saliendo del sistema... ¡Hasta pronto!");
            salir = true;
            break;

        default:
            Console.WriteLine("Opción no válida. Ingrese un número del 0 al 10.");
            break;
    }

    if (!salir)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
static string LeerTexto(string mensaje)
{
    Console.Write(mensaje);
    return Console.ReadLine() ?? string.Empty;
}

static DateTime LeerFecha(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "";

        if (DateTime.TryParse(entrada, out DateTime fecha))
            return fecha;

        Console.WriteLine("Fecha inválida. Ejemplo: 15/06/2026 10:30");
    }
}

static Paciente BuscarPaciente(IRepository<Paciente> repo, string id)
{
    foreach (Paciente p in repo.ObtenerTodos())
    {
        if (p.IdPaciente == id)
            return p;
    }
    return null;
}

static Medico BuscarMedico(IRepository<Medico> repo, string id)
{
    foreach (Medico m in repo.ObtenerTodos())
    {
        if (m.IdMedico == id)
            return m;
    }
    return null;
}

static Especialidad BuscarEspecialidad(IRepository<Especialidad> repo, string id)
{
    foreach (Especialidad e in repo.ObtenerTodos())
    {
        if (e.IdEspecialidad == id)
            return e;
    }
    return null;
}

static Cita BuscarCita(IRepository<Cita> repo, string id)
{
    foreach (Cita c in repo.ObtenerTodos())
    {
        if (c.IdCita == id)
            return c;
    }
    return null;
}
static void MostrarPacientes(IRepository<Paciente> repo)
{
    List<Paciente> lista = repo.ObtenerTodos();
    if (lista.Count == 0) { Console.WriteLine("No hay pacientes registrados."); return; }

    Console.WriteLine("Pacientes registrados:");
    lista.ForEach(p => Console.WriteLine($"  ID: {p.IdPaciente} | {p.Nombre} {p.Apellido}"));
}

static void MostrarMedicos(IRepository<Medico> repo)
{
    List<Medico> lista = repo.ObtenerTodos();
    if (lista.Count == 0) { Console.WriteLine("No hay médicos registrados."); return; }

    Console.WriteLine("Médicos registrados:");
    lista.ForEach(m =>
    {
        string especialidad = m.Especialidad != null ? m.Especialidad.NombreEspecialidad : "Sin asignar";
        Console.WriteLine($"  ID: {m.IdMedico} | Dr. {m.Nombre} {m.Apellido} | Especialidad: {especialidad}");
    });
}

static void MostrarEspecialidades(IRepository<Especialidad> repo)
{
    List<Especialidad> lista = repo.ObtenerTodos();
    if (lista.Count == 0) { Console.WriteLine("No hay especialidades registradas."); return; }

    Console.WriteLine("Especialidades registradas:");
    lista.ForEach(e => Console.WriteLine($"  ID: {e.IdEspecialidad} | {e.NombreEspecialidad}"));
}

static void MostrarCitas(IRepository<Cita> repo)
{
    List<Cita> lista = repo.ObtenerTodos();
    if (lista.Count == 0) { Console.WriteLine("No hay citas registradas."); return; }

    Console.WriteLine("Citas registradas:");
    lista.ForEach(c => Console.WriteLine(
        $"  ID: {c.IdCita} | {c.Paciente.Nombre} {c.Paciente.Apellido} -> Dr. {c.Medico.Nombre} | {c.FechaHora:dd/MM/yyyy HH:mm} | [{c.EstadoCita}]"));
}

