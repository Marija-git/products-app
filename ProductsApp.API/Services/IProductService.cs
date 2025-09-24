using ProductsApp.API.DTOs.Request;
using ProductsApp.API.DTOs.Response;
using ProductsApp.Data.Models;
using System.Linq.Expressions;

namespace ProductsApp.API.Services
{
    public interface IProductService
    {
        Task<ProductDtoResponse>CreateAsync(ProductDtoRequest dto);
        Task<ProductDtoResponse> GetByIdAsync(int id);
        //  Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        //  Task<bool> DeleteAsync(int id);
        //  Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDtoResponse> GetByIdWithCategoriesAsync(int id);
        Task<IEnumerable<ProductDtoResponse>> GetAllWithCategoriesAsync();
        Task RemoveProductAsync(int productId);
    }
}
