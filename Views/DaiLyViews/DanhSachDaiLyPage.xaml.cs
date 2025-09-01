using QuanLyDaiLy.ViewModels.DaiLyViewModels;

namespace QuanLyDaiLy.Views.DaiLyViews;

public partial class DanhSachDaiLyPage : ContentPage
{
	public DanhSachDaiLyPage(DanhSachDaiLyPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}