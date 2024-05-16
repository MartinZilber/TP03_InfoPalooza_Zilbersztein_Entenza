using System.Collections.Generic;
class Tiquetera
{
    private static Dictionary<int, Cliente> DicClientes { get; set; } = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada { get; set; }
    static public int DevolverUltimoID()
    {
        UltimoIDEntrada = DicClientes.Count+1;
        return DicClientes.Count;
    }
    static public int AgregarCliente(Cliente cliente)
    {
        DicClientes.Add(UltimoIDEntrada, cliente);
        return UltimoIDEntrada;
    }
    static public Cliente BuscarCliente(int ID)
    {
        Cliente objeto = new Cliente();
        foreach (int clave in DicClientes.Keys)
        {
            if (ID == clave)
            {
                objeto = DicClientes[clave];
            }
        }
        return objeto;
    }
    static public bool CambiarEntrada(int ID, int tipo, int cantidad)
    {
        //ID es el número de identificador de entrada
        double[] precios = { 45000, 60000, 30000, 100000 };
        bool sePudoCambiar = false;
        Cliente cliente = DicClientes[ID - 1];
        if (precios[tipo] > precios[cliente.TipoEntrada])
        {
            cliente.TipoEntrada = tipo;
            cliente.Cantidad = cantidad;
            DicClientes.Add(ID, cliente);
            sePudoCambiar = true;
        }
        else
        Console.WriteLine("No se ha encontrado el cliente o el importe es menor al anterior");
        return sePudoCambiar;
    }
    static public List<string> EstadisticasTicketera()
    {
        int totalEntradas = 0;
        double clientes1 = 0, clientes2 = 0, clientes3 = 0, clientes4 = 0, recaudacion1 = 0, recaudacion2 = 0, recaudacion3 = 0, recaudacion4 = 0, porcentaje1 = 0, porcentaje2 = 0, porcentaje3 = 0, porcentaje4 = 0, recaudacionTotal = 0, totalClientes = 0;
        List<string> Estadisticas = new List<string>();
        foreach (Cliente cliente in DicClientes.Values)
        {
            totalEntradas += (int)cliente.Cantidad;
            if (cliente.TipoEntrada == 1)
            {
                clientes1++;
                porcentaje1 += cliente.Cantidad;
                recaudacion1 += (cliente.Cantidad * 45000);//precioPagado
            }
            if (cliente.TipoEntrada == 2)
            {
                clientes2++;
                porcentaje2 += cliente.Cantidad;
                recaudacion2 += cliente.Cantidad * 60000;
            }
            if (cliente.TipoEntrada == 3)
            {
                clientes3++;
                porcentaje3 += cliente.Cantidad;
                recaudacion3 += cliente.Cantidad * 30000;
            }
            if (cliente.TipoEntrada == 4)
            {
                clientes4++;
                porcentaje4 += cliente.Cantidad;
                recaudacion4 += cliente.Cantidad * 100000;
            }
            totalClientes++;

        }
        porcentaje1 = porcentaje1 * 100 / totalEntradas;
        porcentaje2 = porcentaje2 * 100 / totalEntradas;
        porcentaje3 = porcentaje3 * 100 / totalEntradas;
        porcentaje4 = porcentaje4 * 100 / totalEntradas;
        recaudacionTotal = recaudacion1 + recaudacion2 + recaudacion3 + recaudacion4;
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
        Estadisticas.Add(totalEntradas.ToString());
        return Estadisticas;
    }
}