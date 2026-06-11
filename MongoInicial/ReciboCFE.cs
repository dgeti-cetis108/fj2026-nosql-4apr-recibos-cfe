using MongoDB.Bson;

namespace MongoInicial;

// datos del recibo de la CFE
// número de servicio, costo, periodo (inicio, fin, mes), 
// cantidad (kwh), precio por kwh, lectura anterior, lectura actual
public class ReciboCFE
{
    public ObjectId _id = new ObjectId();
    public required string NúmeroDeServicio = "";
    public int LecturaAnterior = 0;
    public int LecturaActual = 0;
    public decimal PrecioPorKwh = 0m;
    public int CantidadKwhDelPeriodo = 0;
    public decimal CostoTotal = 0m;
    public required string PeriodoMes = "";
    public DateOnly PeriodoInicio = new DateOnly();
    public DateOnly PeriodoFinal = new DateOnly();
}