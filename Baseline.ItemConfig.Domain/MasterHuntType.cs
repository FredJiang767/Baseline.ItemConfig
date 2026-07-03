namespace Baseline.ItemConfig.Domain;

public class MasterHuntType
{
    public static MasterHuntType Create(Guid id, string name)
    {
        return new MasterHuntType { Id = id, Name = name };
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
