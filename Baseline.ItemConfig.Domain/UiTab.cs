namespace Baseline.ItemConfig.Domain;

public class UiTab
{
    public static UiTab Create(string name)
    {
        return new UiTab
        {
            UiTabId = Guid.NewGuid(),
            Name = name
        };
    }

    public Guid UiTabId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<UiSubTab> UiSubTabs { get; set; } = new List<UiSubTab>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
}
