using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class StatusTypeFactory
{
    public static StatusTypeRegistrationForm Create() => new();

    //Mappar om StatusTypeRegistrationForm till StatusTypeEntity
    public static StatusTypeEntity Create(StatusTypeRegistrationForm form) => new()
    {
        StatusName = form.StatusName,
    };

    //Mappar om StatusTypeEntity till StatusType
    public static StatusType Create(StatusTypeEntity entity) => new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName,
    };

    //Mappar om gammal StatusTypeEntity till uppdaterad version

    public static StatusTypeUpdateForm Create(StatusType statusType) => new()
    {
        Id = statusType.Id,
        StatusName = statusType.StatusName,
    };
    public static StatusTypeEntity Create(StatusTypeUpdateForm form) => new()
    {
        Id = form.Id,
        StatusName = form.StatusName,
    };
}
