using System;
using AutoMapper;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.Exceptions;

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
            var validator = new CreateLeaveAllocationDtoValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationExceptions(validationResult);
            }

            var leaveAllocations = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocations = await _leaveAllocationRepository.Add(leaveAllocations);
            return leaveAllocations.Id;
        }
    }
}
