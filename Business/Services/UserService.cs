using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> CreateUserAsync(UserRegistrationForm form)
    {
        var entity = await _userRepository.GetAsync(x => x.FirstName == form.FirstName);
        entity ??= await _userRepository.CreateAsync(UserFactory.Create(form));
        return UserFactory.Create(entity);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var entities = await _userRepository.GetAllAsync();
        var products = entities.Select(UserFactory.Create);
        return products ?? [];
    }

    public async Task<User> GetUserAsync(Expression<Func<UserEntity, bool>> expression)
    {
        var entity = await _userRepository.GetAsync(expression);
        var product = UserFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<User> UpdateUserAsync(UserUpdateForm form)
    {
        var entity = await _userRepository.UpdateAsync(x => x.Id == form.Id, UserFactory.Create(form));
        var product = UserFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var result = await _userRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}

