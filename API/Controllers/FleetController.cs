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

    }
}
