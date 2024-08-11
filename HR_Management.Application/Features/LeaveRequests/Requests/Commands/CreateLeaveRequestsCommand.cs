using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestsCommand : IRequest<int>
    {
        public CreateLeaveRequestsDto LeaveRequestDto { get; set; }
    }
}
