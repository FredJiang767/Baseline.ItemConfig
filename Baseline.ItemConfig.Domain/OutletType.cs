namespace Baseline.ItemConfig.Domain;

public class OutletType
{
    public static OutletType Create(string name)
    {
        return new OutletType
        {
            OutletTypeId = Guid.NewGuid(),
            Name = name
        };
    }

    public Guid OutletTypeId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Outlet> Outlets { get; set; } = new List<Outlet>();
    public ICollection<OutletTypeItem> OutletTypeItems { get; set; } = new List<OutletTypeItem>();
}
