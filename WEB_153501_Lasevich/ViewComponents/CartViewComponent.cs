using Microsoft.AspNetCore.Mvc;

namespace WEB_153501_Lasevich.ViewComponents;
public class CartViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult<IViewComponentResult>(View());
    }
}
