using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.Utils;
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
        await AlertUtil.ShowInfoAlert("Clicked");
    }

    [RelayCommand] 
    public void LoadCommand()
    {
        _ = LoadDaiLyButton();
    }

    [RelayCommand] 
    public async Task ThemDaiLyButton()
    {
        try
        {
            // Resolve the ViewModel from DI container
            var themDaiLyViewModel = serviceProvider.GetRequiredService<ThemDaiLyWindowViewModel>();

            // Create the popup with the ViewModel
            var themDaiLyPopup = new ThemDaiLyWindow(themDaiLyViewModel);

            // Show the popup and wait for it to close
            var mainPage = Application.Current?.MainPage;
            if (mainPage is not null)
            {
                await mainPage.ShowPopupAsync(themDaiLyPopup);

                // Always reload the list when popup closes, regardless of what happened
                await LoadDaiLies();
            }
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Không thể mở popup thêm đại lý: {ex.Message}");
        }
    }

    private async Task LoadDaiLyButton()    
    {
        await LoadDaiLies();
        await AlertUtil.ShowSuccessAlert("Tải trang thành công");
    }
}
