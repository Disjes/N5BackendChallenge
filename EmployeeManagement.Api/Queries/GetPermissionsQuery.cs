using EmployeeManagement.Shared.Dtos;
using MediatR;

namespace EmployeeManagement.Api.Queries;

public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
{ }