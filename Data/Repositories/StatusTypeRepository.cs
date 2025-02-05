using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class StatusTypeRepository(DataContext context) : IStatusTypeRepository
{
    private readonly DataContext _context = context;

    //Create
    public async Task<StatusTypeEntity> CreateStatusTypeEntityAsync(StatusTypeEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.StatusTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating statustype entity :: {ex.Message}");
            return null!;
        };
    }

    //Read
    public async Task<IEnumerable<StatusTypeEntity>> GetAllStatusTypeEntityAsync()
    {
        return await _context.StatusTypes.ToListAsync();
    }

    public async Task<StatusTypeEntity> GetStatusTypeEntityAsync(Expression<Func<StatusTypeEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _context.StatusTypes.FirstOrDefaultAsync(expression) ?? null!;
    }

    //Update
    public async Task<StatusTypeEntity> UpdateStatusTypeEntityAsync(StatusTypeEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await GetStatusTypeEntityAsync(x => x.Id == updatedEntity.Id);
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating statustype entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteStatusTypeEntityAsync(Expression<Func<StatusTypeEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var existingEntity = await GetStatusTypeEntityAsync(expression);
            if (existingEntity == null)
                return false;

            _context.StatusTypes.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting statustype entity :: {ex.Message}");
            return false;
        }
    }
}
