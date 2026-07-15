namespace Baseline.ItemConfig.API.Models.Requests;

public record CreateItemRequest(int ItemYear, string ItemNumber, Guid RootItemNumberId, Guid UiSubTabId, Guid UiTabId);
