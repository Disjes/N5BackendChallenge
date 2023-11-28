using EmployeeManagement.Domain.Interfaces.Services;
using EmployeeManagement.Shared.Dtos;
using MediatR;

namespace EmployeeManagement.Api.Commands.Handlers;

public class RequestPermissionHandler : IRequestHandler<RequestPermissionCommand, PermissionDto>
{
    private readonly IPermissionsService _permissionsService;

    public RequestPermissionHandler(IPermissionsService permissionsService)
    {
        _permissionsService = permissionsService;
    }

    public async Task<PermissionDto> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
    {
        var dto = new PermissionDto()
        {
            EmployeeName = request.EmployeeName,
            EmployeeLastName = request.EmployeeLastName,
            PermissionTypeId = request.PermissionTypeId,
            PermissionDate = request.PermissionDate
        };
        var result = await _permissionsService.AddPermissionToUser(dto);
        return result;
    }
}