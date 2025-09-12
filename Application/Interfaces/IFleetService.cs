using Application.DTOs;

namespace Application.Interfaces;

public interface IFleetService
{
    Task<FleetDto> CreateFleetAsync(FleetDto dto);
    Task AddDriverAsync(Guid fleetId, CreateDriverDto dto);
    Task AddVehicleAsync(Guid fleetId, CreateVehicleDto dto);
    Task AssignDriverToVehicleAsync(Guid fleetId, Guid driverId, Guid vehicleId);

    Task<FleetDto?> GetFleetAsync(Guid fleetId);
    Task<IEnumerable<FleetDto>> GetAllFleetsAsync();

    Task UpdateFleetAsync(Guid fleetId, FleetDto dto);
    Task DeleteFleetAsync(Guid fleetId);

    Task DeleteVehicleAsync(Guid fleetId, Guid vehicleId);
    Task DeleteDriverAsync(Guid fleetId, Guid driverId);
}