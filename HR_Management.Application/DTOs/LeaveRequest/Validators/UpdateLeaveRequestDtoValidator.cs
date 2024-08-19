using FluentValidation;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
