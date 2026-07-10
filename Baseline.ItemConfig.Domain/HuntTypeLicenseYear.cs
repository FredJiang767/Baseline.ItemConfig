namespace Baseline.ItemConfig.Domain;

public class HuntTypeLicenseYear
{
    public static HuntTypeLicenseYear Create(Guid masterHuntTypeId, int year, DateTime startDate, DateTime endDate)
    {
        return new HuntTypeLicenseYear
        {
            Id = Guid.NewGuid(),
            MasterHuntTypeId = masterHuntTypeId,
            Year = year,
            StartDate = startDate,
            EndDate = endDate
        };
    }

    public Guid Id { get; set; }
    public Guid MasterHuntTypeId { get; set; }
    public int Year { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MasterHuntType? MasterHuntType { get; set; }
}
