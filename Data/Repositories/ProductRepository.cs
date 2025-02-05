using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProductRepository(DataContext context) : IProductRepository
{
    private readonly DataContext _context = context;

    //Create
    public async Task<ProductEntity> CreateProductEntityAsync(ProductEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Products.AddAsync(entity); 
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) 
        {
            Debug.WriteLine($"Error creating product entity :: {ex.Message}");
            return null!;
        };
    }

    //Read
    public async Task<IEnumerable<ProductEntity>> GetAllProductEntityAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductEntity> GetProductEntityAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _context.Products.FirstOrDefaultAsync(expression) ?? null!;
    }

    //Update
    public async Task<ProductEntity> UpdateProductEntityAsync(ProductEntity updatedEntity)
    {
        if (updatedEntity == null) 
            return null!;

        try
        {
            var existingEntity = await GetProductEntityAsync(x => x.Id == updatedEntity.Id);
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating product entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteProductEntityAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var existingEntity = await GetProductEntityAsync(expression);
            if (existingEntity == null)
                return false;

            _context.Products.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) 
        {
            Debug.WriteLine($"Error deleting product entity :: {ex.Message}");
            return false;
        }
    }
    public async Task<bool> ExistsAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        return await _context.Products.AnyAsync(expression);
    }
}
