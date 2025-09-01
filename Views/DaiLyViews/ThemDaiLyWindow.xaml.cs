using CommunityToolkit.Maui.Views;
using QuanLyDaiLy.ViewModels.DaiLyViewModels;

namespace QuanLyDaiLy.Views.DaiLyViews;

public partial class ThemDaiLyWindow : Popup
{
    public ThemDaiLyWindow(ThemDaiLyWindowViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}