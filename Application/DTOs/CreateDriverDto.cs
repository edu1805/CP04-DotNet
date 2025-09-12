using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateDriverDto
    {
        public string Name { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!;
    }
}
