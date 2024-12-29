using CoffeeApp.Application.Common;
using CoffeeApp.Application.Services.Interfaces;
using CoffeeApp.Domain.Entities;

namespace CoffeeApp.Application.UseCases;

public class GetCoffee
{
    private readonly ICoffeeService _coffeeService;

    public GetCoffee(ICoffeeService coffeeService)
    {
        _coffeeService = coffeeService;
    }

    public async Task<Result<List<Coffee>>> GetCoffeeItemsAsync()
    {
        try
        {
            var coffeeItems = await _coffeeService.GetCoffeeItemsAsync();
            return Result<List<Coffee>>.Success(coffeeItems);
        }
        catch (Exception ex)
        {
            return Result<List<Coffee>>.Failure($"An error occurred while fetching coffee items: {ex.Message}");
        }
    }
}