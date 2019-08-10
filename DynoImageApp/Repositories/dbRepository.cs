using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DynoImageApp.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DynoImageApp.Repositories
{
    class dbRepository : Interfaces.IDbRepository
    {
        public dbModel ReadDb()
        {
            using (StreamReader file = File.OpenText("db.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var result =  (dbModel)serializer.Deserialize(file, typeof(Models.dbModel));
                if (result == null)
                    return new dbModel();
                else
                    return result;
            }
        }

        public void UpdateDb(dbModel dbModel)
        {
            using (StreamWriter file = File.CreateText("db.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, dbModel);
            }
        }
    }
}
