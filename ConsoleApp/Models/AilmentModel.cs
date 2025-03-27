namespace ConsoleApp.Models;

public class AilmentModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public RecoveryModel Recovery { get; set; } = new();
    public ProtectionModel Protection { get; set; } = new();

}