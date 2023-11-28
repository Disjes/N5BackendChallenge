namespace EmployeeManagement.Services.Configs;

public class KafkaOptions
{
    public string BootstrapServers { get; set; } = String.Empty;
    public string ClientId { get; set; } = String.Empty;
    public string Acks { get; set; } = String.Empty;
    public string Url { get; set; } = "All";
}