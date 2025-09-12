using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.persistence
{
    class FleetRepository : IFleetRepository
    {
        private readonly FleetDbContext _context;

        public FleetRepository(FleetDbContext context)
        {
            _context = context;
        }

        public async Task<Fleet?> GetByIdAsync(Guid id)
        {
            return await _context.Fleets
                .Include(f => f.Vehicles)
                .Include(f => f.Drivers)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Fleet fleet)
        {
            await _context.Fleets.AddAsync(fleet);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
