using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FleetService : IFleetService
    {
        private readonly IFleetRepository _fleetRepository;

        public FleetService(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<FleetDto> CreateFleetAsync()
        {
            var fleet = new Fleet();
            await _fleetRepository.AddAsync(fleet);
            await _fleetRepository.SaveChangesAsync();
            return FleetDto.FromDomain(fleet);
        }

        public async Task AddDriverAsync(Guid fleetId, CreateDriverDto dto)
        {
            var fleet = await _fleetRepository.GetByIdAsync(fleetId)
                        ?? throw new InvalidOperationException("Fleet not found");

            var driver = new Driver(dto.Name, dto.LicenseNumber);
            fleet.AddDriver(driver);

            await _fleetRepository.SaveChangesAsync();
        }

        public async Task AddVehicleAsync(Guid fleetId, CreateVehicleDto dto)
        {
            var fleet = await _fleetRepository.GetByIdAsync(fleetId)
                        ?? throw new InvalidOperationException("Fleet not found");

            var plate = new Domain.ValueObjects.LicensePlate(dto.Plate);
            var vehicle = new Vehicle(plate, dto.Model);
            fleet.AddVehicle(vehicle);

            await _fleetRepository.SaveChangesAsync();
        }

        public async Task AssignDriverToVehicleAsync(Guid fleetId, Guid driverId, Guid vehicleId)
        {
            var fleet = await _fleetRepository.GetByIdAsync(fleetId)
                        ?? throw new InvalidOperationException("Fleet not found");

            fleet.AssignDriverToVehicle(driverId, vehicleId);

            await _fleetRepository.SaveChangesAsync();
        }

        public async Task<FleetDto?> GetFleetByIdAsync(Guid fleetId)
        {
            var fleet = await _fleetRepository.GetByIdAsync(fleetId);
            return fleet == null ? null : FleetDto.FromDomain(fleet);
        }

        public async Task<FleetDto> CreateFleetAsync(FleetDto dto)
        {
            var fleet = new Fleet(); // no futuro pode usar dados do dto
            await _fleetRepository.AddAsync(fleet);
            await _fleetRepository.SaveChangesAsync();
            return FleetDto.FromDomain(fleet);
        }

        public async Task<FleetDto?> GetFleetAsync(Guid fleetId)
        {
            var fleet = await _fleetRepository.GetByIdAsync(fleetId);
            return fleet == null ? null : FleetDto.FromDomain(fleet);
        }

        public Task<IEnumerable<FleetDto>> GetAllFleetsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateFleetAsync(Guid fleetId, FleetDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFleetAsync(Guid fleetId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVehicleAsync(Guid fleetId, Guid vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDriverAsync(Guid fleetId, Guid driverId)
        {
            throw new NotImplementedException();
        }
    }
}
