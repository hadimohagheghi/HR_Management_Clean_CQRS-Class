﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository:GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations =await _dbContext.LeaveAllocations
                .Include(t=>t.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
               .Include(t => t.LeaveType)
               .FirstOrDefaultAsync(l=>l.Id==id);
            return leaveAllocation;
        }
    }
}
