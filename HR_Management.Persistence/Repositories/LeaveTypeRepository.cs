﻿using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository:GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext)
            :base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}