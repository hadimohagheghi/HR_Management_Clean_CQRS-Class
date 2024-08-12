using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto: BaseDto
    {
        public bool? Approved { get; set; }
    }
}
