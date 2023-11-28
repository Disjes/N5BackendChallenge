using AutoMapper;
using EmployeeManagement.Data.Context;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly PermissionsContext _context;
    private readonly IMapper _mapper; 

    public PermissionRepository(PermissionsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public IEnumerable<Permission> GetAllPermissions()
    {
        var permissionList = _context.Permission.ToList();
        return _mapper.Map<List<Permission>>(permissionList);
    }

    public Permission GetPermissionById(int id)
    {
        return _mapper.Map<Permission>(_context.Permission
            .FirstOrDefault(e => e.Id == id));
    }

    public void AddPermission(Permission permission)
    {
        var efPermission = _mapper.Map<Data.Entities.Permission>(permission);
        _context.Permission.Add(efPermission);
    }

    public void UpdatePermission(Permission permission)
    {
        var efPermission = _mapper.Map<Data.Entities.Permission>(permission);
        _context.Entry(efPermission).State = EntityState.Modified;
    }

    public void DeletePermission(int id)
    {
        var permission = _context.Permission.Find(id);
        if (permission != null)
        {
            _context.Permission.Remove(permission);
        }
    }
}