using CommunityToolkit.Mvvm.ComponentModel;

namespace QuanLyDaiLy.ViewModels.DaiLyViewModels;

public partial class DanhSachDaiLyPageViewModel : ObservableObject
{
    [ObservableProperty] 
    private string title = "Danh Sách Đại Lý";
}
