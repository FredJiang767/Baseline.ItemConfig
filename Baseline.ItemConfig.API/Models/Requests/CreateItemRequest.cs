namespace Baseline.ItemConfig.API.Models.Requests;

public record CreateItemRequest(int ItemYear, string ItemNumber, Guid UiSubTabId, Guid UiTabId);
