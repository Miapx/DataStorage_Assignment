using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    private readonly DataContext _context = context;

    //Create
    public async Task<CustomerEntity> CreateCustomerEntityAsync(CustomerEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating customer entity :: {ex.Message}");
            return null!;
        };
    }

    //Read
    public async Task<IEnumerable<CustomerEntity>> GetAllCustomerEntityAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<CustomerEntity> GetCustomerEntityAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _context.Customers.FirstOrDefaultAsync(expression) ?? null!;
    }

    //Update
    public async Task<CustomerEntity> UpdateCustomerEntityAsync(CustomerEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await GetCustomerEntityAsync(x => x.Id == updatedEntity.Id);
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating customer entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteCustomerEntityAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var existingEntity = await GetCustomerEntityAsync(expression);
            if (existingEntity == null)
                return false;

            _context.Customers.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting customer entity :: {ex.Message}");
            return false;
        }
    }
}
