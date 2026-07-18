using Baseline.ItemConfig.Application;
using Baseline.ItemConfig.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CatalogController : ControllerBase
    {
        private readonly UiTabService _uiTabService;
        private readonly UiSubTabService _uiSubTabService;
        private readonly ItemService _itemService;
        private readonly RootItemNumberService _rootItemNumberService;

        public CatalogController(UiTabService uiTabService, ItemService itemService, UiSubTabService uiSubTabService, RootItemNumberService rootItemNumberService)
        {
            _uiTabService = uiTabService;
            _itemService = itemService;
            _uiSubTabService = uiSubTabService;
            _rootItemNumberService = rootItemNumberService;
        }

        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            var itemResult = new List<ItemReadDto>();
            var tabs = await _uiTabService.GetAll();
            var package = tabs.Where(x => x.Name == "Package");
            foreach (var tab in package)
            {
                var subTabs = await _uiSubTabService.GetSubTabsByTabId(tab.UiTabId);
                foreach (var subTab in subTabs)
                {
                    var items = await _itemService.GetItemsBySubTabId(subTab.UiSubTabId);
                    itemResult.AddRange(items);
                }
            }

            var rootItemNumbers = await _rootItemNumberService.GetAll();

            var result = itemResult.Select(x =>
            {
                var name = rootItemNumbers.FirstOrDefault(r => r.RootItemNumberId == x.RootItemNumberId)?.Description;
                return new CatalogDto(name);
            });
            return Ok(result);
        }
    }
}
