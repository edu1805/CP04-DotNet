using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Fleet
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; private set; }
        private readonly List<Vehicle> _vehicles = new();
        private readonly List<Driver> _drivers = new();


        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles.AsReadOnly();
        public IReadOnlyCollection<Driver> Drivers => _drivers.AsReadOnly();


        public Fleet()
        {
            Id = Guid.NewGuid();
        }


        public void AddVehicle(Vehicle vehicle)
        {
            if (_vehicles.Any(v => v.Plate == vehicle.Plate))
                throw new InvalidOperationException("Vehicle with same plate already exists.");
            _vehicles.Add(vehicle);
        }


        public void AddDriver(Driver driver)
        {
            if (_drivers.Any(d => d.LicenseNumber == driver.LicenseNumber))
                throw new InvalidOperationException("Driver with same license already exists.");
            _drivers.Add(driver);
        }


        public void AssignDriverToVehicle(Guid driverId, Guid vehicleId)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == driverId);
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == vehicleId);


            if (driver == null || vehicle == null)
                throw new InvalidOperationException("Driver or vehicle not found.");


            if (!driver.IsAvailable)
                throw new InvalidOperationException("Driver is not available.");


            driver.Assign();
        }

    }
}
