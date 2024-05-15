static int pedirInt(string mensaje, int minimo, int maximo)
{
    int num;
    do
    {
        Console.WriteLine(mensaje);
        num = int.Parse(Console.ReadLine());
    } while (num == null && (num < minimo || num > maximo));
    return num;
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
    fechaString = Console.ReadLine();
    pude = DateTime.TryParse(fechaString, out DateTime fecha);
    while (!pude)
    {
        Console.WriteLine(mensaje);
        fechaString = Console.ReadLine();
        pude = DateTime.TryParse(fechaString, out DateTime fechaEnWhile);
        if (pude)
            fecha = fechaEnWhile;
    }
    return fecha;
}

int opcion, DNI, tipoEntrada, cantidad;
string nombre, apellido;
DateTime fechaInscripcion;
const int OPCION_1 = 1, OPCION_5 = 5;
do
{
    Console.WriteLine("¿Qué desea realizar? 1. Nueva inscripción, 2. obtener estadísticas del evento, 3. buscar gente, 4. cambiar entrada, 5. salir");
    opcion = int.Parse(Console.ReadLine());
} while (opcion < OPCION_1 || opcion > OPCION_5);
switch (opcion)
{
    case 1:
        DNI = pedirInt("Ingrese el DNI del cliente", 0, int.MaxValue);
        nombre = pedirString("Ingrese el nombre del cliente");
        apellido = pedirString("Ingrese el apellido del cliente");
        fechaInscripcion = pedirDateTime("Ingrese la fecha de inscripción");
        tipoEntrada = pedirInt("Ingrese el tipo de entrada. Opción 1: Día 1, $45000; día 2, $60000; día 3, $30000; Full pass, $100000.", 1, 4);
        cantidad = pedirInt("Ingrese la cantidad de entradas que comprará", 1, int.MaxValue);
        Cliente cliente = new Cliente(DNI, apellido, nombre, fechaInscripcion, tipoEntrada, cantidad);
        break;
    case 2://Lei lol
        break;
    case 3:
        break;
    case 4:
        break;
    case 5:
        break;

}