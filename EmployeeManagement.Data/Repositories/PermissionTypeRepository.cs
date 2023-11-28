using AutoMapper;
using EmployeeManagement.Data.Context;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Repositories;

public class PermissionTypeRepository : IPermissionTypeRepository
{
    private readonly EmployeesContext _context;
    private readonly IMapper _mapper; 

    public PermissionTypeRepository(EmployeesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<PermissionType> GetAllPermissionTypes()
    {
        return _mapper.Map<List<PermissionType>>(_context.PermissionType.ToList());
    }

    public PermissionType GetPermissionTypeById(int id)
    {
        return _mapper.Map<PermissionType>(_context.PermissionType.Find(id));
    }

    public void AddPermissionType(PermissionType permissionType)
    {
        var efPermissionType = _mapper.Map<Data.Entities.PermissionType>(permissionType);
        _context.PermissionType.Add(efPermissionType);
    }

    public void UpdatePermissionType(PermissionType permissionType)
    {
        var efPermissionType = _mapper.Map<Data.Entities.PermissionType>(permissionType);
        _context.Entry(efPermissionType).State = EntityState.Modified;
    }

    public void DeletePermissionType(int id)
    {
        var permissionType = _context.PermissionType.Find(id);
        if (permissionType != null)
        {
            _context.PermissionType.Remove(permissionType);
        }
    }
}