using System;
using AutoMapper;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationExceptions(validationResult);
            }

            var leaveType = await leaveTypeRepository.Get(request.LeaveTypeDto.Id);
            mapper.Map(request.LeaveTypeDto, leaveType);
            await leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
