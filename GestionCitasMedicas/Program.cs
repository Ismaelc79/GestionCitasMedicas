

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
        Console.WriteLine("Registrar pacientes");
            
            break;
        case "2":
            Console.WriteLine("Registrar médicos");
            break;
        case "3":
            Console.WriteLine("Registrar especialidades médicas");
            break;
        case "4":
            Console.WriteLine("Asignar médicos a una especialidad");
            break;
        case "5":
            Console.WriteLine("Agendar citas médicas");
            break;
        case "6":
            Console.WriteLine("Consultar citas por paciente");
            break;
        case "7":
            Console.WriteLine("Consultar citas por médico");
            break;
        case "8":
            Console.WriteLine("Cancelar citas");
            break;
        case "9":
            Console.WriteLine("Reprogramar citas");
            break;
        case "10":
            Console.WriteLine("Enviar recordatorio de citas");
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
    
}

