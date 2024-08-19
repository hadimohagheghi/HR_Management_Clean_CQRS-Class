using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Application.Exceptions;
using HR_Management.Domain;

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

            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            await _leaveTypeRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
}
