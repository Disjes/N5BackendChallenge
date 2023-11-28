using EmployeeManagement.Api.Commands;
using EmployeeManagement.Api.Queries;
using EmployeeManagement.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace EmployeeManagement.Api.Controllers;

public class PermissionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST: api/employees/permissions
    [HttpPost("permissions")]
    public async Task<IActionResult> RequestPermission([FromBody] PermissionDto dto)
    {
        var command = new RequestPermissionCommand(
            dto.PermissionId, 
            dto.EmployeeName,
            dto.EmployeeLastName,
            dto.PermissionDate);

        var result = await _mediator.Send(command);

        if(result != null)
        {
            Log.Information("RequestPermission Success");
            return Ok("Permission added successfully.");
        }
        
        Log.Error($"RequestPermission Error Employee: {command.EmployeeName}, PermissionId: {dto.PermissionId}");
        return BadRequest("Failed to add permission.");
    }
    
    // GET: api/permissions
    [HttpGet("permissions")]
    public async Task<IActionResult> GetPermissions(GetPermissionsQuery getPermissionsQuery)
    {
        var permissions = await _mediator.Send(getPermissionsQuery);

        if(permissions != null && permissions.Any())
        {
            Log.Information("GetPermissions Success");
            return Ok(permissions);
        }
        
        Log.Error("GetPermissions Permissions NotFound");
        return NotFound("No permissions found for the given employee.");
    }
    
    // PUT: api/permissions/10
    [HttpPut("{permissionId}")]
    public async Task<IActionResult> ModifyPermission(int permissionId, [FromBody] ModifyPermissionCommand modifyPermissionCommand)
    {
        bool result = await _mediator.Send(modifyPermissionCommand);

        if(result)
        {
            Log.Information("ModifyPermission Success");
            return Ok("Permission modified successfully.");
            
        }
        
        Log.Error($"RequestPermission Error Employee: {modifyPermissionCommand.PermissionDto.EmployeeName}, PermissionId: {permissionId}");
        return BadRequest("Failed to modify permission.");
    }
}