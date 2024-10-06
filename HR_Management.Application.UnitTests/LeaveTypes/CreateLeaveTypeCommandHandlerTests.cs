using Moq;
using AutoMapper;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommandHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CreateLeaveTypeCommandHandler _handler;

    public CreateLeaveTypeCommandHandlerTests()
    {
        _mockLeaveTypeRepository = new Mock<ILeaveTypeRepository>();
        _mockMapper = new Mock<IMapper>();
        _handler = new CreateLeaveTypeCommandHandler(_mockLeaveTypeRepository.Object, _mockMapper.Object);



    }

    [Fact]
    public async Task Handle_ValidLeaveType_ReturnsLeaveTypeId()
    {

        // Arrange
        var leaveTypeDto = new CreateLeaveTypeDto { Name = "Vacation", DefaultDay = 10 };
        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };



        var leaveType = new LeaveType { Id = 1, Name = "Vacation", DefaultDay = 10 };
        //_mockMapper.Setup(m => m.Map<LeaveType>(It.IsAny<CreateLeaveTypeDto>())).Returns(leaveType);
        _mockLeaveTypeRepository.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync(leaveType);
        // Act

        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(1, result);
        //_mockMapper.Verify(m => m.Map<LeaveType>(It.IsAny<CreateLeaveTypeDto>()), Times.Once);
        _mockLeaveTypeRepository.Verify(r => r.Add(It.IsAny<LeaveType>()), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidLeaveType_ThrowsValidationException()
    {
        // Arrange
        var leaveTypeDto = new CreateLeaveTypeDto { Name = "", DefaultDay = -1 }; // Invalid data
        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationExceptions>(async () =>
            await _handler.Handle(command, CancellationToken.None));

        _mockLeaveTypeRepository.Verify(r => r.Add(It.IsAny<LeaveType>()), Times.Never);
    }

    [Fact]
    public async Task Handle_RepositoryAddFails_ThrowsException()
    {
        // Arrange
        var leaveTypeDto = new CreateLeaveTypeDto { Name = "Vacation", DefaultDay= 10 };
        var leaveType = new LeaveType { Id = 1, Name = "Vacation", DefaultDay = 10 };

        _mockMapper.Setup(m => m.Map<LeaveType>(It.IsAny<CreateLeaveTypeDto>())).Returns(leaveType);
        _mockLeaveTypeRepository.Setup(r => r.Add(It.IsAny<LeaveType>())).ThrowsAsync(new System.Exception("Database error"));

        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(async () =>
            await _handler.Handle(command, CancellationToken.None));

        _mockMapper.Verify(m => m.Map<LeaveType>(It.IsAny<CreateLeaveTypeDto>()), Times.Once);
        _mockLeaveTypeRepository.Verify(r => r.Add(It.IsAny<LeaveType>()), Times.Once);
    }
}
