using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class CustomerFactory
{
    public static CustomerRegistrationForm Create() => new();

    //Mappar om CustomerRegistrationForm till CustomerEntity
    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        CustomerName = form.CustomerName,
    };

    //Mappar om CustomerEntity till Customer
    public static Customer Create(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName,
    };

    //Mappar om gammal CustomerEntity till uppdaterad version

    public static CustomerUpdateForm Create(Customer customer) => new()
    {
        Id = customer.Id,
        CustomerName = customer.CustomerName,
    };
    public static CustomerEntity Create(CustomerUpdateForm form) => new()
    {
        Id = form.Id,
        CustomerName = form.CustomerName,
    };
}
