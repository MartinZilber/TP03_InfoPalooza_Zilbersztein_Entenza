static int pedirInt(string mensaje, int minimo, int maximo)
{
    int num;
    do
    {
        Console.WriteLine(mensaje);
        num = int.Parse(Console.ReadLine());
    } while (num == null || (num < minimo || num > maximo));
    return num;
}

static int pedirNumeroUnico(string mensaje, List<int> DNIS)
{
    int DNI, posicion;
    do
    {
        Console.WriteLine(mensaje);
        DNI = int.Parse(Console.ReadLine());
        posicion = DNIS.IndexOf(DNI);
    } while (posicion != -1);
    return DNI;
}

static string pedirString(string mensaje)
{
    string palabra;
    do
    {
        Console.WriteLine(mensaje);
        palabra = Console.ReadLine();
    } while (palabra == "" || palabra == " ");
    return palabra;
}

static DateTime pedirDateTime(string mensaje)
{
    bool pude = false;
    string fechaString;
    Console.WriteLine(mensaje);
    fechaString = Console.ReadLine();
    pude = DateTime.TryParse(fechaString, out DateTime fecha);
    while (!pude)
    {
        Console.WriteLine("Error al ingresar la fecha. " + mensaje);
        fechaString = Console.ReadLine();
        pude = DateTime.TryParse(fechaString, out DateTime fechaEnWhile);
        if (pude)
            fecha = fechaEnWhile;

    }
    return fecha;
}

int opcion, DNI, tipoEntrada, cantidad, cantClientes = 0, IDEntrada, tipo;
string nombre, apellido;
bool sePudo = false;
DateTime fechaInscripcion;
List<int> DNIS = new List<int>();
const int OPCION_1 = 1, OPCION_5 = 5;
opcion = pedirInt("¿Qué desea realizar? 1. Nueva inscripción, 2. obtener estadísticas del evento, 3. buscar gente, 4. cambiar entrada, 5. salir", OPCION_1, OPCION_5);
while (opcion != 5)
{
    switch (opcion)
    {
        case 1:
            DNI = pedirNumeroUnico("Ingrese el DNI del cliente", DNIS);
            DNIS.Add(DNI);
            nombre = pedirString("Ingrese el nombre del cliente");
            apellido = pedirString("Ingrese el apellido del cliente");
            fechaInscripcion = pedirDateTime("Ingrese la fecha de inscripción");
            tipoEntrada = pedirInt("Ingrese el tipo de entrada. Opción 1: Día 1, $45000; opción 2: día 2, $60000; opción 3: día 3, $30000; opción 4: Full pass, $100000.", 1, 4);
            cantidad = pedirInt("Ingrese la cantidad de entradas que comprará", 1, int.MaxValue);
            Cliente cliente = new Cliente(DNI, apellido, nombre, fechaInscripcion, tipoEntrada, cantidad);
            Tiquetera.DevolverUltimoID();
            Tiquetera.AgregarCliente(cliente);
            cantClientes++;
            break;
        case 2:
            List<string> Estadísticas = new List<string>();
            Estadísticas = Tiquetera.EstadisticasTicketera();
            if (Estadísticas[0] != "0")
            {
                Console.WriteLine("La cantidad de clientes inscriptos es de " + Estadísticas[0]);
                for (int i = 1; i < 5; i++)
                {
                    Console.WriteLine($"La cantidad de clientes que compraron la entrada {i}  es de {Estadísticas[i]}");
                }
                for (int i = 5; i < 9; i++)
                {
                    Console.WriteLine($"El porcentaje de entradas de tipo {i - 4}  compradas es de {Estadísticas[i]} %");
                }
                for (int i = 9; i < 13; i++)
                {
                    Console.WriteLine($"La recaudación de entrada de tipo {i - 8}  es de ${Estadísticas[i]}");
                }
                Console.WriteLine($"La cantidad de dinero recaudado es ${Estadísticas[13]}");
                Console.WriteLine($"La cantidad de entradas compradas es de {Estadísticas[14]}");
            }
            else Console.WriteLine("Aún no se ha ingresado ningún cliente");
            break;
        case 3:
            Cliente clienteABuscar;
            IDEntrada = pedirInt("Ingrese el número de entrada cuyo comprador se buscará", 0, cantClientes);
            clienteABuscar = Tiquetera.BuscarCliente(IDEntrada);
            if (clienteABuscar.Nombre == null) Console.WriteLine("No se ha encontrado el cliente");
            else
            {
                Console.WriteLine($"El nombre del cliente es {clienteABuscar.Nombre} {clienteABuscar.Apellido}");
                Console.WriteLine($"El DNI del cliente es {clienteABuscar.DNI}");
                Console.WriteLine($"La fecha en la que se inscribió el cliente es {clienteABuscar.FechaInscripcion}");
                Console.WriteLine($"La entrada que compró es {clienteABuscar.TipoEntrada}");
                Console.WriteLine($"El cliente compró {clienteABuscar.Cantidad} entradas");
            }
            break;
        case 4:
            int ID = pedirInt("Ingrese el ID de la entrada", 0, cantClientes);
            bool existe = (ID > 0 && ID < cantClientes);
            if (existe)
            {
                tipo = pedirInt("Ingrese el tipo de entrada por el cual se cambiará", 0, 4);
                cantidad = pedirInt("Ingrese la cantidad de entradas que comprará", 0, int.MaxValue);
                sePudo = Tiquetera.CambiarEntrada(ID, tipo, cantidad);
                if (sePudo)
                    Console.WriteLine("Se ha hecho el cambio.");
                else
                    Console.WriteLine("No se ha podido realizar el cambio.");
            }
            else Console.WriteLine("El ID de la entrada no existe");
            break;
        case 5:
            break;
    }
    opcion = pedirInt("¿Qué desea realizar? 1. Nueva inscripción, 2. obtener estadísticas del evento, 3. buscar gente, 4. cambiar entrada, 5. salir", OPCION_1, OPCION_5);
}
Console.WriteLine("El programa ha finalizado.");