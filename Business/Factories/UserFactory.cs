using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class UserFactory
{
    public static UserRegistrationForm Create() => new();


    //Mappar om UserRegistrationForm till UserEntity
    public static UserEntity Create(UserRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
    };

    //Mappar om UserEntity till User
    public static User Create(UserEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        
    };

    //Mappar om gammal UserEntity till uppdaterad version

    public static UserUpdateForm Create(User user) => new()
    {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
    };
    public static UserEntity Create(UserUpdateForm form) => new()
    {
        Id = form.Id,
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
    };
}

