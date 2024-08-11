using AutoMapper;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationsCommandHandler
        : IRequestHandler<CreateLeaveAllocationsCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationsCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationsCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocations = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocations = await _leaveAllocationRepository.Add(leaveAllocations);
            return leaveAllocations.Id;
        }
    }
}
