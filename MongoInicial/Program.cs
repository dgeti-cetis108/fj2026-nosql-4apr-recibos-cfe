using MongoInicial;

// probando la conexión
var mongo = new SecondTry();

while (true)
{
    mostrarOpciones();
    int opcion = elegirOpcion();

    switch (opcion)
    {
        case 1:
            registrarRecibo();
            break;
        case 2:
            calcularCostosDeRecibos();
            break;
        case 3:
            mongo.MostrarRecibos();
            break;
        case 6:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Error: elige la opción correcta");
            Console.ReadKey();
            break;
    }
}

void calcularCostosDeRecibos()
{
    foreach (var recibo in mongo.ObtenerListaDeRecibos())
    {
        // CantidadKwhDelPeriodo = LecturaActual - LecturaAnterior
        // CostoTotal = PrecioPorKwh * CantidadKwhDelPeriodo
        recibo.CantidadKwhDelPeriodo = recibo.LecturaActual - recibo.LecturaAnterior;
        recibo.CostoTotal = recibo.PrecioPorKwh * recibo.CantidadKwhDelPeriodo;
        mongo.ActualizarUnRecibo(recibo);
    }
    Console.WriteLine("Recibos actualizados correctamente");
    Console.ReadKey();
}


int elegirOpcion()
{
    Console.WriteLine("Ingresa la opción elegida");
    return int.Parse(Console.ReadLine()!);
}

// mostrar el menu de opciones que hará el programa
void mostrarOpciones()
{
    Console.Clear();
    Console.WriteLine("CONTROL DE RECIBOS CFE DEL HOGAR");
    Console.WriteLine("--------------------------------");

    Console.WriteLine("[1] Registrar nuevo recibo");
    Console.WriteLine("[2] Calcular costos de recibos");
    Console.WriteLine("[3] Mostrar todos los recibos");
    Console.WriteLine("[4] Mostrar detalle de un recibo");
    Console.WriteLine("[5] Eliminar un recibo");
    Console.WriteLine("[6] Salir");
}

// permite al usuario registrar un recibo por teclado
void registrarRecibo()
{
    Console.Clear();
    Console.WriteLine("Registro de Recibos CFE");

    Console.WriteLine("Número de servicio:");
    string noServicio = Console.ReadLine()!;

    Console.WriteLine("Periodo del mes");
    string periodoMes = Console.ReadLine()!;

    Console.WriteLine("Lectura anterior");
    int lecAnterior = int.Parse(Console.ReadLine()!);

    Console.WriteLine("Lectura actual");
    int lecActual = int.Parse(Console.ReadLine()!);

    Console.WriteLine("Precio por Kwh");
    double precioAleatorio = new Random().NextDouble();
    decimal precio = (decimal)((precioAleatorio < .29 ? .29 : precioAleatorio) * 3.5);
    Console.WriteLine($"${precio:F2}");

    var recibo = new ReciboCFE
    {
        NúmeroDeServicio = noServicio,
        LecturaAnterior = lecAnterior,
        LecturaActual = lecActual,
        PeriodoMes = "Junio",
        PrecioPorKwh = precio
    };

    mongo.GuardarNuevoRecibo(recibo);
}



// registra un recibo con valores fijos (demostración)
// void registrarUnRecibo()
// {
//     // crear un recibo
//     var recibo1 = new ReciboCFE()
//     {
//         NúmeroDeServicio = "9879487298423",
//         PeriodoMes = "Junio",
//         CostoTotal = 2700m
//     };

//     // guardar el recibo
//     mongo.GuardarNuevoRecibo(recibo1);

//     // mostrar los recibos
//     mongo.MostrarRecibos();
// }