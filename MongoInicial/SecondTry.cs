using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoInicial;

public class SecondTry
{
    string uri = "mongodb://localhost:27017/";
    string nombreDeBaseDeDatos = "ServiciosDelHogar";
    string nombreDeColeccion = "RecibosCFE";
    MongoClient cliente;
    IMongoDatabase db;
    IMongoCollection<ReciboCFE> coleccion;

    public SecondTry() // constructor
    {
        this.cliente = new MongoClient(this.uri);
        this.db = cliente.GetDatabase(nombreDeBaseDeDatos);
        this.coleccion = this.db.GetCollection<ReciboCFE>(nombreDeColeccion);
    }

    public void GuardarNuevoRecibo(ReciboCFE recibo)
    {
        this.coleccion.InsertOne(recibo);
    }

    public void MostrarRecibos()
    {
        foreach (var recibo in coleccion.Find(_ => true).ToList())
        {
            Console.WriteLine($"Servicio: {recibo.NúmeroDeServicio}, Total: {recibo.CostoTotal}");
        }
        Console.ReadKey();
    }

    public List<ReciboCFE> ObtenerListaDeRecibos()
    {
        return coleccion.Find(_ => true).ToList();
    }

    public void ActualizarUnRecibo(ReciboCFE recibo)
    {
        // TODO: Completar la actualización
        coleccion.ReplaceOne(r => r._id == recibo._id, recibo);
    }

    public ReciboCFE BuscarReciboPorNúmeroDeServicioYMes(string número, string mes)
    {
        return coleccion.Find(
                            r => r.NúmeroDeServicio == número
                            && r.PeriodoMes == mes)
                        .FirstOrDefault<ReciboCFE>();
    }
}

