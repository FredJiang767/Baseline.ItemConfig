namespace Baseline.ItemConfig.Domain;

public class Item
{
    public static Item Create(int itemYear, string itemNumber, Guid uiSubTabId, Guid uiTabId)
    {
        return new Item
        {
            ItemId = Guid.NewGuid(),
            ItemYear = itemYear,
            ItemNumber = itemNumber,
            UiSubTabId = uiSubTabId,
            UiTabId = uiTabId
        };
    }

    public Guid ItemId { get; set; }
    public int ItemYear { get; set; }
    public string ItemNumber { get; set; } = string.Empty;
    public Guid UiSubTabId { get; set; }
    public Guid UiTabId { get; set; }

    public UiSubTab? UiSubTab { get; set; }
    public UiTab? UiTab { get; set; }
    public ICollection<OutletTypeItem> OutletTypeItems { get; set; } = new List<OutletTypeItem>();
}
