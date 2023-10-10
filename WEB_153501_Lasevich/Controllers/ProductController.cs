using Microsoft.AspNetCore.Mvc;
using Web_153501_Lasevich.Services.CategoryService;
using Web_153501_Lasevich.Services.ProductService;

namespace Web_153501_Lasevich.Controllers;

public class ProductController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public ProductController(
        ICategoryService categoryService,
        IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }
    public async Task<IActionResult> Index(string? category, int pageNo = 1)
    {
        ViewData["categories"] = (await _categoryService.GetCategoryListAsync()).Data;

        var productResponse = await _productService.GetProductListAsync(category, pageNo);

        if (!productResponse.Success)
        {
            return NotFound(productResponse.ErrorMessage);
        }

        ViewData["currentCategory"] = category == null ? category : productResponse.Data?.Items?.FirstOrDefault()?.Category?.Name;

        return View((productResponse.Data!.Items, productResponse.Data.CurrentPage, productResponse.Data.TotalPages));
    }
}
