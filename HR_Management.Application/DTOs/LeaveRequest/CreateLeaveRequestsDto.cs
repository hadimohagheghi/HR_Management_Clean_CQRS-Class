using HR_Management.Application.DTOs.Common;
using System;

namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestsDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
    }
}
