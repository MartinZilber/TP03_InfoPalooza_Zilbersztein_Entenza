using System.Collections.Generic;
class Tiquetera
{
    private static Dictionary<int, Cliente> DicClientes { get; set; } = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada { get; set; }
    static public int DevolverUltimoID()
    {
        return DicClientes.Count;
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
        double[] precios = { 45000, 60000, 30000, 100000 };
        Cliente cliente = DicClientes[ID];
        if (DicClientes.ContainsKey(ID) && tipo > )
        {
            cliente.TipoEntrada = tipo;
            cliente.Cantidad = cantidad;
        }




        return 0;
    }
    static public List<string> EstadisticasTicketera()
    {
        int totalEntradas = 0;
        double clientes1 = 0, clientes2 = 0, clientes3 = 0, clientes4 = 0, recaudacion1 = 0, recaudacion2 = 0, recaudacion3 = 0, recaudacion4 = 0, porcentaje1 = 0, porcentaje2 = 0, porcentaje3 = 0, porcentaje4 = 0, recaudacionTotal = 0, totalClientes = 0;
        List<string> Estadisticas = new List<string>();
        foreach (Cliente cliente in DicClientes.Values)
        {
            totalEntradas += cliente.Cantidad;
            if (cliente.TipoEntrada == 1)
            {
                clientes1++;
                recaudacion1 += cliente.Cantidad * 45000;//precioPagado
            }
            if (cliente.TipoEntrada == 2)
            {
                clientes2++;
                recaudacion2 += cliente.Cantidad * 60000;
            }
            if (cliente.TipoEntrada == 3)
            {
                clientes3++;
                recaudacion3 += cliente.Cantidad * 30000;
            }
            if (cliente.TipoEntrada == 4)
            {
                clientes4++;
                recaudacion4 += cliente.Cantidad * 100000;
            }
            porcentaje1 = clientes1 * 100 / totalEntradas;
            porcentaje2 = clientes2 * 100 / totalEntradas;
            porcentaje3 = clientes3 * 100 / totalEntradas;
            porcentaje4 = clientes4 * 100 / totalEntradas;
            totalClientes++;
        }
        recaudacionTotal = clientes1 + clientes2 + clientes3 + clientes4;
        Estadisticas.Add(totalClientes.ToString());
        Estadisticas.Add(clientes1.ToString());
        Estadisticas.Add(clientes2.ToString());
        Estadisticas.Add(clientes3.ToString());
        Estadisticas.Add(clientes4.ToString());
        Estadisticas.Add(porcentaje1.ToString());
        Estadisticas.Add(porcentaje2.ToString());
        Estadisticas.Add(porcentaje3.ToString());
        Estadisticas.Add(porcentaje4.ToString());
        Estadisticas.Add(recaudacion1.ToString());
        Estadisticas.Add(recaudacion2.ToString());
        Estadisticas.Add(recaudacion3.ToString());
        Estadisticas.Add(recaudacion4.ToString());
        Estadisticas.Add(recaudacionTotal.ToString());
        return Estadisticas;
    }
}