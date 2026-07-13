namespace Baseline.ItemConfig.Domain;

public class Outlet
{
    public static Outlet Create(string name, Guid outletTypeId)
    {
        return new Outlet
        {
            OutletId = Guid.NewGuid(),
            Name = name,
            OutletTypeId = outletTypeId
        };
    }

    public Guid OutletId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid OutletTypeId { get; set; }

    public OutletType? OutletType { get; set; }
}
