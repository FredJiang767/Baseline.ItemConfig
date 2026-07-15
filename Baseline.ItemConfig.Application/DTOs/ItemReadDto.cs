namespace Baseline.ItemConfig.Application.DTOs;

public record ItemReadDto(Guid ItemId, int ItemYear, string ItemNumber, Guid RootItemNumberId, Guid UiSubTabId, Guid UiTabId);
