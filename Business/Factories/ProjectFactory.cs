using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();


    //Mappar om ProjectRegistrationForm till ProjectEntity
    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        CustomerId = form.CustomerId,
        StatusId = form.StatusId,
        UserId = form.UserId,
        ProductId = form.ProductId, 
    };

    //Mappar om ProjectEntity till Project
    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Customer = entity.Customer,
        User = entity.User,
        Product = entity.Product,
    };

    //Mappar om gammal ProjectEntity till uppdaterad version

    public static ProjectUpdateForm Create(Project project) => new()
    {
        Id = project.Id,
        Title = project.Title,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        Customer = project.Customer,
        User = project.User,
        Product = project.Product,        
    };
    public static ProjectEntity Create(ProjectUpdateForm form) => new()
    {
        Id = form.Id,
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        Customer = form.Customer,
        User = form.User,
        Product = form.Product,
    };
}
