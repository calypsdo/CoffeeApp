using CoffeeApp.Presentation.ViewModels;

namespace CoffeeApp.Presentation.Views;

public partial class CoffeePage : ContentPage
{
    public CoffeePage(CoffeePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
