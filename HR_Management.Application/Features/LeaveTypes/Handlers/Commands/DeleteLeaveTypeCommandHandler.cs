using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            await _leaveTypeRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
}
