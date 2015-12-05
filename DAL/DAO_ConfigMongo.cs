using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System.Configuration;

namespace DAL
{
    public class DAO_ConfigMongo
    {
        string strcon = ConfigurationManager.AppSettings["conexionmongo"];
        string bd = ConfigurationManager.AppSettings["dbmongo"];
        string collect = ConfigurationManager.AppSettings["collectionmongo"];

        public int[] obtenerParametros()
        {
            MongoClient mc = new MongoClient(strcon);
            MongoServer mongo = mc.GetServer();
            MongoDatabase db = mongo.GetDatabase(bd);
            var coleccion = db.GetCollection<BsonDocument>(collect);
            int[] parametrosactuales = new int[2];
            foreach (BsonDocument item in coleccion.FindAll())
            {
                BsonElement subidavideos = item.GetElement("subidavideos");
                BsonElement backup = item.GetElement("backup");
                parametrosactuales[0] = int.Parse(subidavideos.Value.ToString());
                parametrosactuales[1] = int.Parse(backup.Value.ToString());
            }
            return parametrosactuales;
        }

        public int obtenerTiempoBackup()
        {
            MongoClient mc = new MongoClient(strcon);
            MongoServer mongo = mc.GetServer();
            MongoDatabase db = mongo.GetDatabase(bd);
            var coleccion = db.GetCollection<BsonDocument>(collect);
            int param = 0;
            foreach (BsonDocument item in coleccion.FindAll())
            {
                BsonElement backup = item.GetElement("backup");
                param = int.Parse(backup.Value.ToString());
            }
            return param;
        }

        public int obtenerTiempoVideo()
        {
            MongoClient mc = new MongoClient(strcon);
            MongoServer mongo = mc.GetServer();
            MongoDatabase db = mongo.GetDatabase(bd);
            var coleccion = db.GetCollection<BsonDocument>(collect);
            int param = 0;
            foreach (BsonDocument item in coleccion.FindAll())
            {
                BsonElement subidavideos = item.GetElement("subidavideos");
                param = int.Parse(subidavideos.Value.ToString());
            }
            return param;
        }

        public bool actualizarParametros(int[] parametros)
        {
            MongoClient mc = new MongoClient(strcon);
            MongoServer mongo = mc.GetServer();
            MongoDatabase db = mongo.GetDatabase(bd);
            var coleccion = db.GetCollection<BsonDocument>(collect);
            coleccion.RemoveAll();
            BsonDocument nuevo= new BsonDocument()
                .Add("subidavideos", parametros[0])
                .Add("backup", parametros[1]);
            coleccion.Insert(nuevo);
            return true;
        }
    }
}
