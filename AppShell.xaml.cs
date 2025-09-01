using QuanLyDaiLy.Views.DaiLyViews;

namespace QuanLyDaiLy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("ThemDaiLyWindow", typeof(ThemDaiLyWindow));
        }
    }
}
