using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class Medicine
    {
        [DataMember]
        public MongoDB.Bson.ObjectId _id { get; set; }
        [DataMember]
        public int MedicineId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public DateTime ManufactureDate { get; set; }
    }
}
