using CoffeeApp.Application.UseCases;
using CoffeeApp.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CoffeeApp.Presentation.ViewModels;

public partial class CoffeePageViewModel : BaseViewModel
{
    private readonly GetCoffee _getCoffee;

    public ObservableCollection<Coffee> CoffeeItems { get; } = new();

    [ObservableProperty]
    bool isRefreshing;

    public CoffeePageViewModel(GetCoffee getCoffee)
    {
        _getCoffee = getCoffee;
    }

    [RelayCommand]
    public async Task GetCoffeeAsync()
    {
        if (IsBusy)
        {
            return;
        }

        IsBusy = true;
        ClearError();

        var result = await _getCoffee.GetCoffeeItemsAsync();

        if(result.IsSuccess)
        {
            CoffeeItems.Clear();
            foreach (var coffee in result.Data)
            {
                CoffeeItems.Add(coffee);
            }
        }
        else
        {
            SetError(result?.ErrorMessage ?? "An unknown error occurred.");
        }

        IsBusy = false;
        IsRefreshing = false;
    }
}
