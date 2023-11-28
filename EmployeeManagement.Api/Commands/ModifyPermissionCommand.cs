using EmployeeManagement.Shared.Dtos;
using MediatR;

namespace EmployeeManagement.Api.Commands;

public class ModifyPermissionCommand : IRequest<bool>
{
    public PermissionDto? PermissionDto { get; set; }
}