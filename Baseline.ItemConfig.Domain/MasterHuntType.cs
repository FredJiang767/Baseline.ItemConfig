namespace Baseline.ItemConfig.Domain;

public class MasterHuntType
{
    public static MasterHuntType Create(string name)
    {
        return new MasterHuntType { Id = Guid.NewGuid(), Name = name };
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
