using System.Collections.Generic;
class Cliente
{
    public int DNI { get; private set; }
    public string Apellido { get; private set; }
    public string Nombre { get; private set; }
    public DateTime FechaInscripcion { get; private set; }
    public int TipoEntrada { get; private set; }
    public int Cantidad { get; private set; }
    public Cliente()
    {

    }
    public Cliente(int dni, string apellido, string nombre, DateTime fechaInscripcion, int tipoEntrada, int cantidad)
    {
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaInscripcion = fechaInscripcion;
        TipoEntrada = tipoEntrada;
        Cantidad = cantidad;
    }
}