namespace Baseline.ItemConfig.API.Models.Requests;

public record CreateHuntTypeLicenseYearRequest(
    Guid MasterHuntTypeId,
    int Year,
    DateTime StartDate,
    DateTime EndDate);
