using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IProjectRepository
    {
        Task<bool> CreateProjectEntityAsync(ProjectEntity entity);
        Task<bool> DeleteProjectEntityAsync(ProjectEntity entity);
        Task<IEnumerable<ProjectEntity>> GetAllProjectEntityAsync();
        Task<ProjectEntity?> GetProjectEntityAsync(Expression<Func<ProjectEntity, bool>> expression);
        Task<bool> UpdateProjectEntityAsync(ProjectEntity entity);
    }
}