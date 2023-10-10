using Web_153501_Lasevich.Domain.Entities;
using Web_153501_Lasevich.Domain.Models;

namespace Web_153501_Lasevich.Services.CategoryService;

public class MemoryCategoryService : ICategoryService
{


    public Task<ResponseData<List<Category>>> GetCategoryListAsync()
    {
        var categories = new List<Category>
        {
            new Category {Id=1, Name="сырок", NormalizedName="syrok"},
            new Category {Id=2, Name="чай", NormalizedName="tea"},
            new Category {Id=3, Name="кофе", NormalizedName="coffee"},
            new Category {Id=4, Name="шоколад", NormalizedName="chocolate"},

        };

        var result = new ResponseData<List<Category>>
        {
            Data = categories
        };

        return Task.FromResult(result);
    }


}
