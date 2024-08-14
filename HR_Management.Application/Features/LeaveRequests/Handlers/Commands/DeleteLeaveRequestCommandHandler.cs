﻿using MediatR;
using System.Threading.Tasks;
using System.Threading;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;


        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            await _leaveRequestRepository.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}