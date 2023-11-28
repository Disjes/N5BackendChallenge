using AutoBogus;
using EmployeeManagement.Api.Commands;
using EmployeeManagement.Api.Controllers;
using EmployeeManagement.Api.Queries;
using EmployeeManagement.Data.Entities;
using EmployeeManagement.Shared.Dtos;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;

namespace EmployeeManagement.Api.Tests.Unit.Controllers;

public class PermissionsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly PermissionsController _controller;

    public PermissionsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new PermissionsController(_mediatorMock.Object);
    }

    [Fact]
    public async Task AddPermissionForEmployee_ShouldReturnOk_WhenSuccessful()
    {
        // Arrange
        var permissionDto = AutoFaker.Generate<PermissionDto>();      
        _mediatorMock.Setup(m => m.Send(It.IsAny<RequestPermissionCommand>(), default))
            .ReturnsAsync(permissionDto);

        // Act
        var result = await _controller.RequestPermission(permissionDto);

        // Assert
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().Be("Permission added successfully.");
    }

    [Fact]
    public async Task AddPermissionForEmployee_ShouldReturnBadRequest_WhenUnsuccessful()
    {
        // Arrange
        var permissionDto = AutoFaker.Generate<PermissionDto>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<RequestPermissionCommand>(), default))
            .Returns(Task.FromResult<PermissionDto>(null!));

        // Act
        var result = await _controller.RequestPermission(permissionDto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>()
            .Which.Value.Should().Be("Failed to add permission.");
    }
    
    [Fact]
    public async Task ModifyPermission_ShouldReturnOk_WhenSuccessful()
    {
        // Arrange
        var permissionId = AutoFaker.Generate<int>();
        var modifyDto = AutoFaker.Generate<ModifyPermissionCommand>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<ModifyPermissionCommand>(), CancellationToken.None))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.ModifyPermission(permissionId, modifyDto);

        // Assert
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().Be("Permission modified successfully.");
    }

    [Fact]
    public async Task ModifyPermission_ShouldReturnBadRequest_WhenUnsuccessful()
    {
        // Arrange
        var permissionId = AutoFaker.Generate<int>();
        var modifyDto = AutoFaker.Generate<ModifyPermissionCommand>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<ModifyPermissionCommand>(), CancellationToken.None))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.ModifyPermission(permissionId, modifyDto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>()
            .Which.Value.Should().Be("Failed to modify permission.");
    }
    
    [Fact]
    public async Task GetPermissions_ShouldReturnOk_WithListOfPermissions()
    {
        // Arrange
        var mockPermissionList = AutoFaker.Generate<PermissionDto>(2);

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetPermissionsQuery>(), default))
            .ReturnsAsync(mockPermissionList);

        // Act
        var result = await _controller.GetPermissions(new GetPermissionsQuery());

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<PermissionDto>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }
}