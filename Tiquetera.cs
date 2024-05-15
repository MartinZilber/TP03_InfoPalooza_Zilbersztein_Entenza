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
        return 0;
    }
    static public Cliente BuscarCliente(int ID)
    {
       bool seEncontro = false;
       Cliente objeto = new Cliente();
       foreach(Cliente cliente in DicClientes.Values)
       {
        if (cliente.DNI == ID)
        return objeto;
       }
       return objeto;
    }
    static public int CambiarEntrada(int ID, int tipo, int cantidad)
    {
        return 0;
    }
    static public List<string> EstadisticasTicketera()
    {
        return List;
    }
}