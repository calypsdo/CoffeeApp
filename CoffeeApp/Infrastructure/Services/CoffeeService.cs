using CoffeeApp.Application.Services.Interfaces;
using CoffeeApp.Domain.Entities;
using CoffeeApp.Infrastructure.Common.Constants;

namespace CoffeeApp.Infrastructure.Services;

public class CoffeeService : ICoffeeService
{
    private readonly DefaultHttpService _defaultHttpService;

    public CoffeeService(DefaultHttpService defaultHttpService)
    {
        _defaultHttpService = defaultHttpService;
    }

    public async Task<List<Coffee>> GetCoffeeItemsAsync()
    {

        return await _defaultHttpService.GetAsync<List<Coffee>>(ApiConstants.GetCoffeeItems);
    }
}
