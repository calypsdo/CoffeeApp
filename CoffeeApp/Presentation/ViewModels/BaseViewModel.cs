using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;


namespace CoffeeApp.Presentation.ViewModels;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    private bool isError;

    [ObservableProperty]
    private string errorMessage;

    [ObservableProperty]
    string title;

    partial void OnErrorMessageChanged(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            ShowError(value);
        }
    }

    public void ClearError()
    {
        IsError = false;
        ErrorMessage = string.Empty;
    }

    public void SetError(string message)
    {
        IsError = true;
        ErrorMessage = message;
    }

    private async void ShowError(string message)
    {
        var toast = Toast.Make(message, ToastDuration.Short, 14);
        await toast.Show();
    }

    public bool IsNotBusy => !IsBusy;
}
