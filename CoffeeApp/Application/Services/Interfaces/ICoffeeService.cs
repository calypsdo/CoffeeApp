using CoffeeApp.Domain.Entities;

namespace CoffeeApp.Application.Services.Interfaces;

public interface ICoffeeService
{
    Task<List<Coffee>> GetCoffeeItemsAsync();
}

