﻿using System;
using AutoMapper;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Domain;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using System.Linq;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Responses;
using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestsCommandHandler
        : IRequestHandler<CreateLeaveRequestsCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;


        public CreateLeaveRequestsCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationExceptions(validationResult);
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);


            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;


            var email = new Email
            {
                To = "info@HadiMohagheghi.com",
                Subject = "Leave Request Submitted",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate} " +
                       $"to {request.LeaveRequestDto.EndDate} " +
                       $"has been submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                //log
            }


            return response;
        }
    }
}
