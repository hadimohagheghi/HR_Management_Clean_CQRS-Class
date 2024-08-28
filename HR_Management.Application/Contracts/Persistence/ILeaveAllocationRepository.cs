using System.Collections.Generic;
using System.Threading.Tasks;
using HR_Management.Domain;

namespace HR_Management.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository:IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}
