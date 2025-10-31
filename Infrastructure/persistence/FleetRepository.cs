using Domain.Entities;
using Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.persistence;

namespace Infrastructure.Persistence
{
    public class FleetRepository : IFleetRepository
    {
        private readonly IMongoCollection<Fleet> _fleets;

        public FleetRepository(FleetDbContext context)
        {
            _fleets = context.GetCollection<Fleet>("Fleets");
        }

        public async Task<Fleet?> GetByIdAsync(Guid id)
        {
            var filter = Builders<Fleet>.Filter.Eq(f => f.Id, id);
            return await _fleets.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Fleet fleet)
        {
            await _fleets.InsertOneAsync(fleet);
        }

        public async Task<IEnumerable<Fleet>> GetAllFleetsAsync()
        {
            return await _fleets.Find(_ => true).ToListAsync();
        }

        public async Task<Fleet?> DeleteAsync(Fleet fleet)
        {
            if (fleet == null) return null;

            var filter = Builders<Fleet>.Filter.Eq(f => f.Id, fleet.Id);
            await _fleets.DeleteOneAsync(filter);
            return fleet;
        }

        
        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}