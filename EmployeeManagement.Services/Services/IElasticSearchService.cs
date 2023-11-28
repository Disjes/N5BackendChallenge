using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Services.Services;

public interface IElasticSearchService
{
    void CreateIndex(Permission permission);
}