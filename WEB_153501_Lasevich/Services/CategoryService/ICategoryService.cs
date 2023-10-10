using Web_153501_Lasevich.Domain.Entities;
using Web_153501_Lasevich.Domain.Models;

namespace Web_153501_Lasevich.Services.CategoryService;

public interface ICategoryService
{
    public Task<ResponseData<List<Category>>> GetCategoryListAsync();
}
