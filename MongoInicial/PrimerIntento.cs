
// using MongoDB.Bson;
// using MongoDB.Bson.Serialization.Attributes;
// using MongoDB.Driver;

// namespace MongoInicial;

// public class PrimerIntento
// {
//     public void pruebaInicial()
//     {
//         Console.WriteLine("Bienvenido a MongoDB con C#");

//         // conexión a mongodb
//         const string uri = "mongodb://localhost:27017/";
//         var client = new MongoClient(uri);

//         // use("tierra_media")
//         var db = client.GetDatabase("tierra_media");
//         var collection = db.GetCollection<Personaje>("personajes");

//         var elMalo = new Personaje
//         {
//             Nombre = "Sauron",
//             Clase = "Archi enemigo",
//             Nivel = 1000
//         };

//         // guardar el personaje
//         // collection.InsertOne(elMalo);

//         // listar los nombres de los personajes
//         var listaDePersonajes = collection.Find(_ => true).ToList();
//         foreach (var personaje in listaDePersonajes)
//         {
//             Console.WriteLine($"{personaje.Nombre}{personaje.Nombre}");
//         }
//     }
// }

// class Personaje
// {
//     public ObjectId _id;

//     [BsonElement("nombre")]
//     public string? Nombre;
//     public string? Clase;
//     public string? clase;
//     public int Nivel;
//     public int nivel;
//     public string[]? equipo;
//     public int flechas_restantes;
//     public string[]? hechizos;
//     public bool bastón;
//     public string? mascota;
// }