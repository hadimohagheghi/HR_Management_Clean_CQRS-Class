using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand:IRequest
    {
        public int Id { get; set; }
    }
}
