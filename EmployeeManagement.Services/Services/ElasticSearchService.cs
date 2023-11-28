using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Services.Configs;
using Microsoft.Extensions.Options;
using Nest;

namespace EmployeeManagement.Services.Services;

public class ElasticSearchService : IElasticSearchService
{
    private readonly ElasticClient _elasticClient;

    public ElasticSearchService(IOptions<ElasticOptions> elasticOptions)
    {
        var settings = new ConnectionSettings(new Uri(elasticOptions.Value.Uri))
            .DefaultIndex(elasticOptions.Value.Index);
        _elasticClient = new ElasticClient(settings);
    } 

    public void CreateIndex(Permission permission)
    {
        _elasticClient.IndexDocument(permission);
    }
}