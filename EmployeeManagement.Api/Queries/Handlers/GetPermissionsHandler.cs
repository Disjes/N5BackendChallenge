using EmployeeManagement.Domain.Interfaces.Services;
using EmployeeManagement.Shared.Dtos;
using MediatR;

namespace EmployeeManagement.Api.Queries.Handlers;

public class GetPermissionsHandler: IRequestHandler<GetPermissionsQuery, IEnumerable<PermissionDto>>
{
    private readonly IPermissionsService _permissionsService;

    public GetPermissionsHandler(IPermissionsService permissionsService)
    {
        _permissionsService = permissionsService;
    }

    public async Task<IEnumerable<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _permissionsService.GetPermissions();
        return permissions;
    }
}