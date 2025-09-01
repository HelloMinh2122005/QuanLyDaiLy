using CommunityToolkit.Mvvm.ComponentModel;

namespace QuanLyDaiLy.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotLoading))]
    private bool isLoading = false;

    public bool IsNotLoading => !IsLoading;

    [ObservableProperty]
    private string title = string.Empty;
}
