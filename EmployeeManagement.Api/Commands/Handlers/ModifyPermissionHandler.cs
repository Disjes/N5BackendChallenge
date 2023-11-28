using EmployeeManagement.Domain.Interfaces.Services;
using EmployeeManagement.Shared.Dtos;
using MediatR;

namespace EmployeeManagement.Api.Commands.Handlers;

public class ModifyPermissionHandler : IRequestHandler<ModifyPermissionCommand, bool>
{
    private readonly IPermissionsService _permissionsService;

    public ModifyPermissionHandler(IPermissionsService permissionsService)
    {
        _permissionsService = permissionsService;
    }

    public async Task<bool> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
    {
        var result = await _permissionsService.ModifyPermission(request.PermissionDto);
        return result;
    }
}