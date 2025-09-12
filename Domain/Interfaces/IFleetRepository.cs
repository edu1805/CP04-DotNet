using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFleetRepository
    {
        Task<Fleet?> GetByIdAsync(Guid id);
        Task AddAsync(Fleet fleet);
        Task SaveChangesAsync();
    }
}
