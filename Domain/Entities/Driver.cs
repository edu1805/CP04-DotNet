using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string LicenseNumber { get; private set; }
        public bool IsAvailable { get; private set; }


        private Driver() { }


        public Driver(string name, string licenseNumber)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
            if (string.IsNullOrWhiteSpace(licenseNumber)) throw new ArgumentException("License required");


            Id = Guid.NewGuid();
            Name = name;
            LicenseNumber = licenseNumber;
            IsAvailable = true;
        }


        public void Assign() => IsAvailable = false;


        public void Release() => IsAvailable = true;
    }
}
