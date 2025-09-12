using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateVehicleDto
    {
        public string Plate { get; set; } = null!;
        public string Model { get; set; } = null!;
    }
}
