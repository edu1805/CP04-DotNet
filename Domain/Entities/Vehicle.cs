using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle
    {
        public Guid Id { get; private set; }
        public LicensePlate Plate { get; private set; }
        public string Model { get; private set; }
        public bool IsActive { get; private set; }


        private Vehicle() { }


        public Vehicle(LicensePlate plate, string model)
        {
            Id = Guid.NewGuid();
            Plate = plate;
            Model = model;
            IsActive = true;
        }


        public void UpdateModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model required", nameof(model));
            Model = model;
        }


        public void Deactivate() => IsActive = false;
    }
}
