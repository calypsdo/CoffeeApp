using CoffeeApp.Presentation.Views;

namespace CoffeeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CoffeeDetailsPage), typeof(CoffeeDetailsPage));
        }
    }
}
