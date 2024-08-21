using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Responses;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestsCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestsDto LeaveRequestDto { get; set; }
    }
}
