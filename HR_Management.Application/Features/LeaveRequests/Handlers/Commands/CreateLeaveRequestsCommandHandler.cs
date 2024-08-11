using AutoMapper;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestsCommandHandler
        : IRequestHandler<CreateLeaveRequestsCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        

        public CreateLeaveRequestsCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
           
           
        }
        public async Task<int> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            return leaveRequest.Id;
        }
    }
}
