using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IStatusTypeService
    {
        Task<StatusType> CreateStatusTypeAsync(StatusTypeRegistrationForm form);
        Task<bool> DeleteStatusTypeAsync(int id);
        Task<IEnumerable<StatusType>> GetAllStatusTypesAsync();
        Task<StatusType> GetStatusTypeAsync(Expression<Func<StatusTypeEntity, bool>> expression);
        Task<StatusType> UpdateStatusTypeAsync(StatusTypeUpdateForm form);
    }
}