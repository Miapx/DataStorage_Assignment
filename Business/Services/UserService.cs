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
        var entity = await _userRepository.GetUserEntityAsync(x => x.FirstName == form.FirstName);
        entity ??= await _userRepository.CreateUserEntityAsync(UserFactory.Create(form));
        return UserFactory.Create(entity);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var entities = await _userRepository.GetAllUserEntityAsync();
        var products = entities.Select(UserFactory.Create);
        return products ?? [];
    }

    public async Task<User> GetUserAsync(Expression<Func<UserEntity, bool>> expression)
    {
        var entity = await _userRepository.GetUserEntityAsync(expression);
        var product = UserFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<User> UpdateUserAsync(UserUpdateForm form)
    {
        var entity = await _userRepository.UpdateUserEntityAsync(UserFactory.Create(form));
        var product = UserFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var result = await _userRepository.DeleteUserEntityAsync(x => x.Id == id);
        return result;
    }
}

