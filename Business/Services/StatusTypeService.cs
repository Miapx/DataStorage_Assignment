using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository statusTypeRepository) : IStatusTypeService
{
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;

    public async Task<StatusType> CreateStatusTypeAsync(StatusTypeRegistrationForm form)
    {
        var entity = await _statusTypeRepository.GetAsync(x => x.StatusName == form.StatusName);
        entity ??= await _statusTypeRepository.CreateAsync(StatusTypeFactory.Create(form));
        return StatusTypeFactory.Create(entity);
    }

    public async Task<IEnumerable<StatusType>> GetAllStatusTypesAsync()
    {
        var entities = await _statusTypeRepository.GetAllAsync();
        var products = entities.Select(StatusTypeFactory.Create);
        return products ?? [];
    }

    public async Task<StatusType> GetStatusTypeAsync(Expression<Func<StatusTypeEntity, bool>> expression)
    {
        var entity = await _statusTypeRepository.GetAsync(expression);
        var product = StatusTypeFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<StatusType> UpdateStatusTypeAsync(StatusTypeUpdateForm form)
    {
        var entity = await _statusTypeRepository.UpdateAsync(x => x.Id == form.Id, StatusTypeFactory.Create(form));
        var product = StatusTypeFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<bool> DeleteStatusTypeAsync(int id)
    {
        var result = await _statusTypeRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
