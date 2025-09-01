namespace QuanLyDaiLy.Utils;

public static class AlertUtil
{
    public static async Task ShowErrorAlert(string message)
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            await mainPage.DisplayAlert("Lỗi", message, "OK");
        }
    }

    public static async Task ShowSuccessAlert(string message)
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            await mainPage.DisplayAlert("Thành công", message, "OK");
        }
    }

    public static async Task ShowInfoAlert(string message)
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            await mainPage.DisplayAlert("Thông báo", message, "OK");
        }
    }

    public static async Task<bool> ShowConfirmAlert(string title, string message, string accept = "Có", string cancel = "Không")
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            return await mainPage.DisplayAlert(title, message, accept, cancel);
        }
        return false;
    }
}
