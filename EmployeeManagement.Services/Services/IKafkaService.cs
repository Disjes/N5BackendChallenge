using EmployeeManagement.Services.Models;

namespace EmployeeManagement.Services.Services;

public interface IKafkaService
{
    Task ProduceToKafkaAsync(string topic, OperationType operationType);
}