using Infrastructure;
using Application.Interfaces;  
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FleetController : ControllerBase
    {
        private readonly IFleetService _fleetService;

        public FleetController(IFleetService fleetService)
        {
            _fleetService = fleetService;
        }

        // GET: api/fleet/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFleetById(Guid id)
        {
            var fleet = await _fleetService.GetFleetAsync(id);
            if (fleet == null) return NotFound();
            return Ok(fleet);
        }

        // GET: api/fleet
        [HttpGet]
        public async Task<IActionResult> GetAllFleets()
        {
            var fleets = await _fleetService.GetAllFleetsAsync();
            return Ok(fleets);
        }

        // POST: api/fleet
        [HttpPost]
        public async Task<IActionResult> CreateFleet([FromBody] FleetDto dto)
        {
            var fleet = await _fleetService.CreateFleetAsync(dto);
            return CreatedAtAction(nameof(GetFleetById), new { id = fleet.Id }, fleet);
        }

        // PUT: api/fleet/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFleet(Guid id, [FromBody] FleetDto dto)
        {
            try
            {
                await _fleetService.UpdateFleetAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/fleet/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFleet(Guid id)
        {
            try
            {
                await _fleetService.DeleteFleetAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/fleet/{fleetId}/vehicles
        [HttpPost("{fleetId}/vehicles")]
        public async Task<IActionResult> AddVehicle(Guid fleetId, [FromBody] CreateVehicleDto dto)
        {
            try
            {
                await _fleetService.AddVehicleAsync(fleetId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/fleet/{fleetId}/vehicles/{vehicleId}
        [HttpDelete("{fleetId}/vehicles/{vehicleId}")]
        public async Task<IActionResult> DeleteVehicle(Guid fleetId, Guid vehicleId)
        {
            try
            {
                await _fleetService.DeleteVehicleAsync(fleetId, vehicleId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/fleet/{fleetId}/drivers
        [HttpPost("{fleetId}/drivers")]
        public async Task<IActionResult> AddDriver(Guid fleetId, [FromBody] CreateDriverDto dto)
        {
            try
            {
                await _fleetService.AddDriverAsync(fleetId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/fleet/{fleetId}/drivers/{driverId}
        [HttpDelete("{fleetId}/drivers/{driverId}")]
        public async Task<IActionResult> DeleteDriver(Guid fleetId, Guid driverId)
        {
            try
            {
                await _fleetService.DeleteDriverAsync(fleetId, driverId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
