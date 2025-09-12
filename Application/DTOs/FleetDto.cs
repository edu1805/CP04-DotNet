using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FleetDto
    {
        public Guid Id { get; set; }
        public List<string> Vehicles { get; set; } = new();
        public List<string> Drivers { get; set; } = new();

        public static FleetDto FromDomain(Fleet fleet)
        {
            return new FleetDto
            {
                Id = fleet.Id,
                Vehicles = fleet.Vehicles.Select(v => v.Plate.ToString()).ToList(),
                Drivers = fleet.Drivers.Select(d => d.Name).ToList()
            };
        }
    }
}
