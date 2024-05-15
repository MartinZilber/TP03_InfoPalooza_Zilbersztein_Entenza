using System.Collections.Generic;
class Tiquetera
{
    private static Dictionary<int, Cliente> DicClientes { get; set; } = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada { get; set; }
    static public int DevolverUltimoID()
    {
        UltimoIDEntrada = 0;
        return UltimoIDEntrada;
    }
    static public int AgregarCliente(Cliente cliente)
    {
        DicClientes.Add(cliente.DNI, cliente);
        return cliente.DNI;

    }
    static public Cliente BuscarCliente(int ID)
    {
        Cliente objeto = new Cliente();
        foreach (Cliente cliente in DicClientes.Values)
        {
            if (cliente.DNI == ID)
                return objeto;
        }
        return objeto;
    }
    static public int CambiarEntrada(int ID, int tipo, int cantidad)
    {
        //ID es el número de identificador de entrada
        foreach (int identificador in DicClientes.Keys)
        {
            if (ID == identificador)
            {
                Cliente cliente = DicClientes[identificador];
                if (cantidad > cliente.Cantidad)
                {
                    cliente.TipoEntrada = tipo;
                    cliente.Cantidad = cantidad;
                }

            }
        }
        return 0;
    }
    static public List<string> EstadisticasTicketera()
    {
        int cantidad, clientes1 = 0, clientes2 = 0, clientes3 = 0, clientes4 = 0;
        List<string> Estadisticas = new List<string>(); 
        cantidad = DicClientes.Count;
        foreach (Cliente cliente in DicClientes.Values)
        {
            if (cliente.TipoEntrada == 1) clientes1++;
        }
        return List;
    }
}