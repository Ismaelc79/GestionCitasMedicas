using GestionCitasMedicas.Entities;
using GestionCitasMedicas.Interfaces;
using GestionCitasMedicas.Repositories;
using GestionCitasMedicas.Services;

IRepository<Paciente> pacienteRepository = new PacienteRepository();
IRepository<Medico> medicoRepository = new MedicoRepository();
IRepository<Especialidad> especialidadRepository = new EspecialidadRepository();
IRepository<Cita> citaRepository = new CitaRepository();

PacienteService pacienteService = new PacienteService(pacienteRepository);
MedicoService medicoService = new MedicoService(medicoRepository);
CitaService citaService = new CitaService(citaRepository);
EspecialidadService especialidadService = new EspecialidadService(especialidadRepository);

bool salir = false; 

while (!salir) {

    Console.Clear();

    Console.WriteLine("+----------Sistema de Gestión de Citas Médicas----------+");
    Console.WriteLine("Elija la opción deseada:");
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
    String? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
        Console.WriteLine("==Registrar pacientes==");
            string nombre = LeerTexto("Ingrese el nombre del paciente:");
            string apellido = LeerTexto("Ingrese el apellido del paciente:");
            int edad = LeerEntero("Ingrese la edad del paciente:");
            string cedula = LeerTexto("Ingrese la cédula del paciente:");
            string telefono = LeerTexto("Ingrese el teléfono del paciente:");
            string correo = LeerTexto("Ingrese el correo del paciente: ");
            string direccion = LeerTexto("Ingrese la dirección del paciente:");
            string idPaciente = LeerTexto("Ingrese el ID del paciente:");
            string esPacienteActivo = LeerTexto("¿El paciente está activo? (Sí/No):");

            pacienteService.RegistrarPaciente(
            nombre,apellido, edad, cedula, telefono, correo, 
            direccion, idPaciente, esPacienteActivo);

            break;

        case "2":
            Console.WriteLine("==Registrar médicos==");
            string nombreMedico = LeerTexto("Ingrese el nombre del médico:");
            string apellidoMedico = LeerTexto("Ingrese el apellido del médico:");
            int edadMedico = LeerEntero("Ingrese la edad del médico: ");
            string cedulaMedico = LeerTexto("Ingrese la cédula del médico:");
            string telefonoMedico = LeerTexto("Ingrese el teléfono del médico:");
            string correoMedico = LeerTexto("Ingrese el correo del médico:");
            string direccionMedico = LeerTexto("Ingrese la dirección del médico:");
            string idMedico = LeerTexto("Ingrese el ID del médico: ");
            string exequatur = LeerTexto("Ingrese el exeqúatur:");
            DateTime horarioTrabajo = LeerFecha("Ingrese el horario de trabajo del médico" +
            "(formato: dd/MM/yyyy HH:mm): ");
            decimal sueldo = LeerDecimal("Ingrese el sueldo del médico: ");

            medicoService.RegistrarMedico(nombreMedico, apellidoMedico, edadMedico, cedulaMedico,
            telefonoMedico, correoMedico, direccionMedico, idMedico, exequatur, horarioTrabajo, sueldo);

            break;

        case "3":
            Console.WriteLine("==Registrar especialidades médicas==");
            string nombreEspecialidad = LeerTexto("Ingrese el nombre de la especialidad médica:");
            string codigoEspecialidad = LeerTexto("Ingrese el código de la especialidad médica:");
            string descripcionEspecialidad = LeerTexto("Ingrese la descripción de la especialidad médica:");
            
            especialidadService.RegistrarEspecialidad(
            nombreEspecialidad, codigoEspecialidad, descripcionEspecialidad);

            break;

        case "4":
            Console.WriteLine("==Asignar médicos a una especialidad==");
            Console.WriteLine("Médicos registrados:");
            List<Medico> medicosDisponibles = medicoRepository.ObtenerTodos();
            List <Especialidad> especialidadesDisponibles = especialidadRepository.ObtenerTodos();
            Console.WriteLine("Medicos registrados:");
            
            foreach (Medico medico in medicosDisponibles)
            {
                Console.WriteLine($"ID: {medico.IdMedico}, Nombre: {medico.Nombre} {medico.Apellido}");
            }

            Console.WriteLine("Especialidades registradas:");
            foreach(Especialidad especialidad in especialidadesDisponibles)
            {
                Console.WriteLine($"ID: {especialidad.IdEspecialidad}, Nombre: {especialidad.NombreEspecialidad}");
            }
            string idMedicoAsignar = LeerTexto("Ingrese el ID del médico a asignar:");
            string idEspecialidadAsignar = LeerTexto("Ingrese el ID de la especialidad a asignar:");
            Medico medicoSeleccionado= medicosDisponibles.FirstOrDefault(m=> m.IdMedico == idMedicoAsignar);
            Especialidad especialidadAsignada = especialidadesDisponibles.FirstOrDefault(e => e.IdEspecialidad == idEspecialidadAsignar);
            
            EspecialidadService AsignarMedicoEspecialidad(Medico medico, Especialidad especialidad)
            {
                medico.Especialidad= especialidad;
            }

            break;

        case "5":
            Console.WriteLine("==Agendar citas médicas==");
            string idPacienteCita = LeerTexto("Ingrese el ID del paciente para la cita:");
            string idMedicoCita = LeerTexto("Ingrese el ID del médico para la cita:");
            DateTime fechaHoraCita = LeerFecha("Ingrese la fecha y hora de la cita (formato: dd/MM/yyyy HH:mm):");
            break;

        case "6":
            Console.WriteLine("==Consultar citas por paciente==");
            break;
        case "7":
            Console.WriteLine("==Consultar citas por médico==");
            break;
        case "8":
            Console.WriteLine("==Cancelar citas==");
            break;
        case "9":
            Console.WriteLine("==Reprogramar citas==");
            break;
        case "10":
            Console.WriteLine("==Enviar recordatorio de citas==");
            break;
        case "0":
            Console.WriteLine("Saliendo del sistema...Pase feliz resto del día!");
            salir = true;
            break;

        default:
            Console.WriteLine("Opción no válida. Por favor, ingrese una opción del 0 al 10");
            Console.WriteLine("Presione cualquier tecla para continuar");
            break;
            
    }
    Console.ReadKey();

    static String LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? string.Empty;
    }

    static int LeerEntero(string mensaje)
    {
        Console.WriteLine(mensaje);
        return int.Parse(Console.ReadLine()?? "0");
    }

    static decimal LeerDecimal(string mensaje)
    {
        Console.WriteLine(mensaje);
        return decimal.Parse(Console.ReadLine() ?? "0");
    }

    static DateTime LeerFecha(string mensaje)
    {
        Console.WriteLine(mensaje);
        return DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());
    }

}

