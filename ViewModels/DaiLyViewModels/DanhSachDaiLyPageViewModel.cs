using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.Views.DaiLyViews;
using System.Collections.ObjectModel;

namespace QuanLyDaiLy.ViewModels.DaiLyViewModels;

public partial class DanhSachDaiLyPageViewModel : BaseViewModel
{
    private readonly IDaiLyService daiLyService;
    private readonly IServiceProvider serviceProvider;

    public DanhSachDaiLyPageViewModel(IDaiLyService daiLyService, IServiceProvider serviceProvider)
    {
        this.daiLyService = daiLyService;
        this.serviceProvider = serviceProvider;
        Title = "Danh Sách Đại Lý";
        _ = LoadDaiLies();
    }

    [ObservableProperty]
    private ObservableCollection<DaiLy> dsDaiLy = [];

    public async Task LoadDaiLies()
    {
        IsLoading = true;
        try
        {
            var daiLies = await daiLyService.GetAllDaiLiesAsync();
            DsDaiLy = new ObservableCollection<DaiLy>(daiLies);
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public async Task ClickButton()
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage is not null)
        {
            await mainPage.DisplayAlert("Info", "Clicked", "OK");
        }
    }

    [RelayCommand] 
    public void LoadCommand()
    {
        _ = LoadDaiLyButton();
    }

    [RelayCommand] 
  public async Task ThemDaiLyButton()
    {
        var themDaiLyViewModel = serviceProvider.GetRequiredService<ThemDaiLyWindowViewModel>();

        var themDaiLyPopup = new ThemDaiLyWindow(themDaiLyViewModel);

        var mainPage = Application.Current?.MainPage;
        if (mainPage is not null)
        {
            var result = await mainPage.ShowPopupAsync(themDaiLyPopup);

            if (result is bool success && success)
            {
                await LoadDaiLies();
            }
        }
    }

    private async Task LoadDaiLyButton()    
    {
        await LoadDaiLies();
        var mainPage = Application.Current?.MainPage;
        if (mainPage is not null)
        {
            await mainPage.DisplayAlert("Thong bao", "Tai trang thanh cong", "OK");
        }
    }
}
