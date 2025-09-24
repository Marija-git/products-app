using AutoMapper;
using ProductsApp.API.DTOs.Request;
using ProductsApp.API.DTOs.Response;
using ProductsApp.Data.Interfaces;
using ProductsApp.Data.Models;

namespace ProductsApp.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDtoResponse> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return _mapper.Map<ProductDtoResponse>(product);
        }

        public async Task<ProductDtoResponse> GetByIdWithCategoriesAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdWithIncludesAsync(id);
            return _mapper.Map<ProductDtoResponse>(product);
        }

        public async Task<IEnumerable<ProductDtoResponse>> GetAllWithCategoriesAsync()
        {
            var products = await _unitOfWork.Products.GetAllWithIncludesAsync();
            return _mapper.Map<IEnumerable<ProductDtoResponse>>(products);
        }

        public async Task<ProductDtoResponse> CreateAsync(ProductDtoRequest dto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var product = _mapper.Map<Product>(dto);

                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();

                if (dto.CategoryIds != null && dto.CategoryIds.Any())
                {
                    var categories = await _unitOfWork.Categories.GetAllAsync();
                    var selectedCategories = categories.Where(c => dto.CategoryIds.Contains(c.CategoryId)).ToList();
                    product.Categories = selectedCategories;

                    _unitOfWork.Products.Update(product);
                    await _unitOfWork.SaveChangesAsync();
                }
                await _unitOfWork.CommitTransactionAsync();

                var createdProduct = await _unitOfWork.Products.GetByIdWithIncludesAsync(product.ProductId);
                return _mapper.Map<ProductDtoResponse>(createdProduct);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }

        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            _unitOfWork.Products.Remove(product);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
