using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace PharmacyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    [ServiceBehavior(UseSynchronizationContext = false)]
    public class PharmacyService : IPharmacyService
    {
        IMongoClient _client;
        IMongoDatabase _database;
        public List<Medicine> GetMedicinesList()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("MedicalShop");

            var collection = _database.GetCollection<Medicine>("Medicines");
            var filter = new BsonDocument();
           
           var result = collection.FindAsync(Builders<Medicine>.Filter.Gt<int>(x => x.MedicineId, 0)).Result.ToListAsync().Result;
            return result;
          
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
