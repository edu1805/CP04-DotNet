using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFleetService
    {
        Task<FleetDto> CreateFleetAsync();
        Task AddDriverAsync(Guid fleetId, CreateDriverDto dto);
        Task AddVehicleAsync(Guid fleetId, CreateVehicleDto dto);
        Task AssignDriverToVehicleAsync(Guid fleetId, Guid driverId, Guid vehicleId);
        Task<FleetDto?> GetFleetByIdAsync(Guid fleetId);
    }
}
