using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator: AbstractValidator<CreateLeaveRequestsDto>
    {
        public CreateLeaveRequestDtoValidator()
        {
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate)
                .WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate)
                .WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
