﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        var entity = await _customerRepository.GetAsync(x => x.CustomerName == form.CustomerName);
        entity ??= await _customerRepository.CreateAsync(CustomerFactory.Create(form));
        return CustomerFactory.Create(entity);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        var products = entities.Select(CustomerFactory.Create);
        return products ?? [];
    }

    public async Task<Customer> GetCustomerAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = await _customerRepository.GetAsync(expression);
        var product = CustomerFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<Customer> UpdateCustomerAsync(CustomerUpdateForm form)
    {
        var entity = await _customerRepository.UpdateAsync(x => x.Id == form.Id, CustomerFactory.Create(form));
        var product = CustomerFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var result = await _customerRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
