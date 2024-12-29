using CoffeeApp.Presentation.ViewModels;

namespace CoffeeApp.Presentation.Views;

public partial class CoffeeDetailsPage : ContentPage
{
    public CoffeeDetailsPage(CoffeeDetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}