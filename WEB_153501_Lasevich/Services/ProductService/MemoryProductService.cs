using Microsoft.AspNetCore.Mvc;
using Web_153501_Lasevich.Domain.Entities;
using Web_153501_Lasevich.Domain.Models;
using Web_153501_Lasevich.Services.CategoryService;

namespace Web_153501_Lasevich.Services.ProductService;

public class MemoryProductService : IProductService
{
    private List<Product>? _products;
    private List<Category>? _categories;
    private readonly IConfiguration _config;

    public MemoryProductService(
        [FromServices] IConfiguration config,
        ICategoryService pictureGenreService)
    {
        _config = config;
        _categories = pictureGenreService.GetCategoryListAsync().Result.Data;
        SetupData();
    }
    public Task<ResponseData<Product>> CreateProductAsync(Product product, IFormFile? formFile)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseData<Product>> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseData<ListModel<Product>>> GetProductListAsync(string? NormalizedName, int pageNo = 1)
    {
        var itemsPerPage = _config.GetValue<int>("ItemsPerPage");
        var itemsTemp = _products!.
            Where(c => NormalizedName == null || c.Category?.NormalizedName == NormalizedName);
        int totalPages = itemsTemp.Count() / itemsPerPage +
            (itemsTemp.Count() % itemsPerPage == 0 ? 0 : 1);
        var items = itemsTemp
            .Skip((pageNo - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        return Task.FromResult(new ResponseData<ListModel<Product>>
        {
            Success = true,
            Data = new ListModel<Product>
            {
                Items = items,
                CurrentPage = pageNo,
                TotalPages = totalPages
            },
            ErrorMessage = string.Empty
        });
    }

    public Task UpdateProductAsync(int id, Product picture, IFormFile? formFile)
    {
        throw new NotImplementedException();
    }

    private void SetupData()
    {
        _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Чудо",
                Manufacturer = "Вимм-Билль-Данн",
                Description="Сырок чудо с клубникой",
                Price = 0.8,
                ImagePath = "Images/1.jpg",
                Category = _categories?.Find(c => c.NormalizedName.Equals("syrok")),
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Клецкий",
                Manufacturer = "Бабушкина крынка",
                Description="Сырок Клецкий с ванилью ",
                Price = 0.5,
                ImagePath = "Images/3.jpg",
                Category = _categories?.Find(c => c.NormalizedName.Equals("syrok")),
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Б.Ю. Александров",
                Manufacturer = "Какая-то русская компания",
                Description="Сырок Б.Ю. Александров ",
                Price = 2.5,
                ImagePath = "Images/2.jpg",
                Category = _categories?.Find(c => c.NormalizedName.Equals("syrok")),
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Name = "Чай Липтон",
                Manufacturer = "PepsiCo и Unilever",
                Description = "Чай липтон с тропическим фруктом",
                Price = 2,
                ImagePath = "Images/4.jpg",
                Category = _categories ?.Find(c => c.NormalizedName.Equals("tea")),
                CategoryId = 2
            },
            new Product
            {
                Id = 5,
                Name = "TESS",
                Manufacturer = "Где-то на Цейлоне",
                Description = "Чай TESS регулярно пью, что черный, что зеленый",
                Price = 2,
                ImagePath = "Images/6.jpg",
                Category = _categories ?.Find(c => c.NormalizedName.Equals("tea")),
                CategoryId = 2
            },
            new Product
            {
                Id = 6,
                Name = "Jacobs",
                Manufacturer = "Jacobs Suchard",
                Description = "Кофе Якобс",
                Price = 3.5,
                ImagePath = "Images/7.jpg",
                Category = _categories ?.Find(c => c.NormalizedName.Equals("coffee")),
                CategoryId = 3
            },
            new Product
            {
                Id = 7,
                Name = "Милкка",
                Manufacturer = "Mondelez International",
                Description = "Вкусный, но дороговатый шоколад",
                Price = 3,
                ImagePath = "Images/10.jpg",
                Category = _categories ?.Find(c => c.NormalizedName.Equals("chocolate")),
                CategoryId = 4
            },
            new Product
            {
                Id = 8,
                Name = "Алпен Голд",
                Manufacturer = "Mondelez International",
                Description = "Хороший шоколад",
                Price = 2,
                ImagePath = "Images/12.jpg",
                Category = _categories ?.Find(c => c.NormalizedName.Equals("chocolate")),
                CategoryId = 4
            },
        };
    }
}
