using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;
namespace Business.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Product> CreateProductAsync(ProductRegistrationForm form)
    {
        //Kollar om en produkt redan existerar och hämtar den om den finns,
        //annars skapar den en ny och returnerar tillbaka entiteten

        var entity = await _productRepository.GetAsync(x => x.ProductName == form.ProductName);
        entity ??= await _productRepository.CreateAsync(ProductFactory.Create(form));

        return ProductFactory.Create(entity);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var entities = await _productRepository.GetAllAsync();
        var products = entities.Select(ProductFactory.Create);
        return products ?? [];
    }

    public async Task<Product> GetProductAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = await _productRepository.GetAsync(expression);
        var product = ProductFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<Product> UpdateProductAsync(ProductUpdateForm form)
    {
        var entity = await _productRepository.UpdateAsync(x => x.Id == form.Id, ProductFactory.Create(form));
        var product = ProductFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var result = await _productRepository.DeleteAsync(x => x.Id == id);
        return result;
    }

    //public async Task<bool> CheckIfProductExistsAsync(Expression<Func<ProductEntity, bool>> expression)
    //{
    //    return await _productRepository.ExistsAsync(expression);
    //}
}
