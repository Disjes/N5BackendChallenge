using AutoMapper;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces.Repositories;
using EmployeeManagement.Domain.Interfaces.Services;
using EmployeeManagement.Services.Models;
using EmployeeManagement.Shared.Dtos;

namespace EmployeeManagement.Services.Services;

public class PermissionsService : IPermissionsService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IPermissionTypeRepository _permissionTypeRepository;
    private readonly IElasticSearchService _elasticSearchService;
    private readonly IKafkaService _kafkaService;
    private readonly IMapper _mapper;

    public PermissionsService(
        IPermissionRepository permissionRepository,
        IPermissionTypeRepository permissionTypeRepository,
        IElasticSearchService elasticSearchService,
        IKafkaService kafkaService,
        IMapper mapper)
    {
        _permissionRepository = permissionRepository;
        _permissionTypeRepository = permissionTypeRepository;
        _elasticSearchService = elasticSearchService;
        _kafkaService = kafkaService;
        _mapper = mapper;
    }
    
    public async Task<PermissionDto> AddPermissionToUser(PermissionDto permissionDto)
    {
        if (ValidateOperation(permissionDto.PermissionTypeId))
        {
            var permissionEntity = _mapper.Map<Permission>(permissionDto);

            _permissionRepository.AddPermission(permissionEntity);
            _elasticSearchService.CreateIndex(permissionEntity);
            await _kafkaService.ProduceToKafkaAsync("operations", new OperationType() { Name = "Add" });

            var mappedPermission = _mapper.Map<PermissionDto>(permissionEntity);
            return mappedPermission;
        }

        throw new ArgumentException("Employee or Permission does not exists.");
    }

    private bool ValidateOperation(int permissionTypeId)
    {
        // Get the user and permission. Ensure they exist.
        var permissionType = _permissionTypeRepository.GetPermissionTypeById(permissionTypeId);
        if (permissionType == null) throw new ArgumentException("Permission not found.");
        
        return true;
    }

    public async Task<bool> ModifyPermission(PermissionDto? permission)
    {
        try
        {
            var mappedPermission = _mapper.Map<Permission>(permission);
            _permissionRepository.UpdatePermission(mappedPermission);
            _elasticSearchService.CreateIndex(mappedPermission);
            await _kafkaService.ProduceToKafkaAsync("operations", new OperationType() { Name = "Modify" });
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<PermissionDto>> GetPermissions()
    {
        var permissions = _mapper.Map<List<PermissionDto>>(_permissionRepository.GetAllPermissions());
        //we're saving only the first record because our CreateIndex only accepts single elements.
        var permission = _mapper.Map<Permission>(permissions.First());
        _elasticSearchService.CreateIndex(permission);
        await _kafkaService.ProduceToKafkaAsync("operations", new OperationType() { Name = "Get" });
        return permissions;
    }
}