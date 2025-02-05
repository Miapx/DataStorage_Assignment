using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IProductService
{
    Task<bool> CheckIfProductExistsAsync(Expression<Func<ProductEntity, bool>> expression);
    Task<Product> CreateProductAsync(ProductRegistrationForm form);
    Task<bool> DeleteProductAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductAsync(Expression<Func<ProductEntity, bool>> expression);
    Task<Product> UpdateProductAsync(ProductUpdateForm form);
}