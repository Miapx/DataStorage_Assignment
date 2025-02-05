using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : IProjectRepository
{
    private readonly DataContext _context = context;

    //Create
    public async Task<bool> CreateProjectEntityAsync(ProjectEntity entity)
    {
        try
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        };
    }
    //Read
    public async Task<IEnumerable<ProjectEntity>> GetAllProjectEntityAsync()
    {
        var entities = await _context.Projects.ToListAsync();
        return entities;
    }

    public async Task<ProjectEntity?> GetProjectEntityAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _context.Projects.FirstOrDefaultAsync(expression);
        return entity;
    }

    //Update
    public async Task<bool> UpdateProjectEntityAsync(ProjectEntity entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    //Delete
    public async Task<bool> DeleteProjectEntityAsync(ProjectEntity entity)
    {
        try
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
