using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;


    //Create
    public async Task<UserEntity> CreateUserEntityAsync(UserEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating user entity :: {ex.Message}");
            return null!;
        };
    }

    //Read
    public async Task<IEnumerable<UserEntity>> GetAllUserEntityAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserEntity> GetUserEntityAsync(Expression<Func<UserEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _context.Users.FirstOrDefaultAsync(expression) ?? null!;
    }

    //Update
    public async Task<UserEntity> UpdateUserEntityAsync(UserEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await GetUserEntityAsync(x => x.Id == updatedEntity.Id);
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating user entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteUserEntityAsync(Expression<Func<UserEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var existingEntity = await GetUserEntityAsync(expression);
            if (existingEntity == null)
                return false;

            _context.Users.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting user entity :: {ex.Message}");
            return false;
        }
    }
}
