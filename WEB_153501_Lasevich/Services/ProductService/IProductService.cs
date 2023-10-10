using Web_153501_Lasevich.Domain.Entities;
using Web_153501_Lasevich.Domain.Models;

namespace Web_153501_Lasevich.Services.ProductService;

public interface IProductService
{
    public Task<ResponseData<ListModel<Product>>> GetProductListAsync(string? genreNormalizedName, int pageNo = 1);
    public Task<ResponseData<Product>> GetProductByIdAsync(int id);
    public Task UpdateProductAsync(int id, Product product, IFormFile? formFile);
    public Task DeleteProductAsync(int id);
    public Task<ResponseData<Product>> CreateProductAsync(Product product, IFormFile? formFile);
}
