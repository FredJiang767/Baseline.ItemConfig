namespace Baseline.ItemConfig.Domain;

public class UiSubTab
{
    public static UiSubTab Create(string name, Guid uiTabId)
    {
        return new UiSubTab
        {
            UiSubTabId = Guid.NewGuid(),
            Name = name,
            UiTabId = uiTabId
        };
    }

    public Guid UiSubTabId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid UiTabId { get; set; }

    public UiTab? UiTab { get; set; }
    public ICollection<Item> Items { get; set; } = new List<Item>();
}
