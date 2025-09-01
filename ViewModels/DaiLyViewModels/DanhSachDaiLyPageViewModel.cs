using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using System.Collections.ObjectModel;

namespace QuanLyDaiLy.ViewModels.DaiLyViewModels;

public partial class DanhSachDaiLyPageViewModel : ObservableObject
{
    private readonly IDaiLyService daiLyService;

    public DanhSachDaiLyPageViewModel(IDaiLyService daiLyService)
    {
        this.daiLyService = daiLyService;
        _ = LoadDaiLies();
    }

    [ObservableProperty]
    private string title = "Danh Sách Đại Lý";

    [ObservableProperty]
    private ObservableCollection<DaiLy> dsDaiLy = [];

    public async Task LoadDaiLies()
    {
        var daiLies = await daiLyService.GetAllDaiLiesAsync();
        DsDaiLy = new ObservableCollection<DaiLy>(daiLies);
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
}
