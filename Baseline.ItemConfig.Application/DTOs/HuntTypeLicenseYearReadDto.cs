namespace Baseline.ItemConfig.Application.DTOs;

public record HuntTypeLicenseYearReadDto(
    Guid Id,
    Guid MasterHuntTypeId,
    int Year,
    DateTime StartDate,
    DateTime EndDate);
