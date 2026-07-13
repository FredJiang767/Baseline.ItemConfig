namespace Baseline.ItemConfig.Domain;

public class OutletTypeItem
{
    public static OutletTypeItem Create(Guid outletTypeId, Guid itemId)
    {
        return new OutletTypeItem
        {
            OutletTypeItemId = Guid.NewGuid(),
            OutletTypeId = outletTypeId,
            ItemId = itemId
        };
    }

    public Guid OutletTypeItemId { get; set; }
    public Guid OutletTypeId { get; set; }
    public Guid ItemId { get; set; }

    public OutletType? OutletType { get; set; }
    public Item? Item { get; set; }
}
