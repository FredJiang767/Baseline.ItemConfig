namespace Baseline.ItemConfig.Domain;

public class RootItemNumber
{
    public static RootItemNumber Create(string number, string description)
    {
        return new RootItemNumber
        {
            RootItemNumberId = Guid.NewGuid(),
            Number = number,
            Description = description
        };
    }

    public Guid RootItemNumberId { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Item> Items { get; set; } = new List<Item>();
}
