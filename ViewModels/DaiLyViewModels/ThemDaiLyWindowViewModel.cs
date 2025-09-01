using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.Utils;
using System.Collections.ObjectModel;

namespace QuanLyDaiLy.ViewModels.DaiLyViewModels;

public partial class ThemDaiLyWindowViewModel : BaseViewModel
{
    private readonly IDaiLyService daiLyService;
    private readonly IQuanService quanService;
    private readonly IThamSoService thamSoService;
    private readonly ILoaiDaiLyService loaiDaiLyService;
    private Popup? currentPopup;

    public ThemDaiLyWindowViewModel(
        IDaiLyService daiLyService,
        IQuanService quanService,
        IThamSoService thamSoService,
        ILoaiDaiLyService loaiDaiLyService
    ) {
        this.daiLyService = daiLyService;
        this.quanService = quanService;
        this.thamSoService = thamSoService;
        this.loaiDaiLyService = loaiDaiLyService;

        _ = LoadDataAsync();
    }

    public void SetPopupReference(Popup popup)
    {
        currentPopup = popup;
    }

    [ObservableProperty]
    private int maDaiLy;

    [ObservableProperty]
    private string tenDaiLy = string.Empty;

    [ObservableProperty]
    private string soDienThoai = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string diaChi = string.Empty;

    [ObservableProperty]
    private DateTime ngayTiepNhan = DateTime.Now;

    [ObservableProperty]
    private ObservableCollection<LoaiDaiLy> loaiDaiLies = [];

    [ObservableProperty]
    private LoaiDaiLy? selectedLoaiDaiLy;

    [ObservableProperty]
    private ObservableCollection<Quan> quans = [];

    [ObservableProperty]
    private Quan? selectedQuan;

    [ObservableProperty]
    private int soLuongDaiLyHienCo = 0;

    [ObservableProperty]
    private int soLuongDaiLyToiDa = 0;

    private async Task LoadDataAsync()
    {
        Title = "Tiếp nhận đại lý";
        NgayTiepNhan = DateTime.Now;
        MaDaiLy = await daiLyService.GetNextAvailableIdAsync();

        _ = LoadComboBoxData();
    }

    private async Task LoadComboBoxData()
    {
        try
        {
            IsLoading = true;
            
            var loaiDaiLies = await loaiDaiLyService.GetAllLoaiDaiLiesAsync();
            var quans = await quanService.GetAlllQuansAsync();

            LoaiDaiLies = new ObservableCollection<LoaiDaiLy>(loaiDaiLies);
            Quans = new ObservableCollection<Quan>(quans);

            if (LoaiDaiLies.Any())
                SelectedLoaiDaiLy = LoaiDaiLies[0];
            
            if (Quans.Any())
            {
                SelectedQuan = Quans[0];
                await UpdateDaiLyCountsForSelectedQuan();
            }

            // Load SoLuongDaiLyToiDa from ThamSo
            await LoadSoLuongDaiLyToiDa();
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi khi tải dữ liệu: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task LoadSoLuongDaiLyToiDa()
    {
        try
        {
            var soLuongToiDaStr = await thamSoService.GetThamSo("SoLuongDaiLyToiDa");
            
            if (!string.IsNullOrEmpty(soLuongToiDaStr) && int.TryParse(soLuongToiDaStr, out int soLuongToiDa))
            {
                SoLuongDaiLyToiDa = soLuongToiDa;
            }
            else
            {
                SoLuongDaiLyToiDa = 50; // Default value
            }
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi khi tải số lượng đại lý tối đa: {ex.Message}");
            SoLuongDaiLyToiDa = 50; // Default value
        }
    }

    private async Task UpdateDaiLyCountsForSelectedQuan()
    {
        if (SelectedQuan != null)
        {
            try
            {
                var allDaiLies = await daiLyService.GetAllDaiLiesAsync();
                SoLuongDaiLyHienCo = allDaiLies.Count(dl => dl.MaQuan == SelectedQuan.MaQuan);
            }
            catch (Exception ex)
            {
                await AlertUtil.ShowErrorAlert($"Lỗi khi đếm số lượng đại lý: {ex.Message}");
                SoLuongDaiLyHienCo = 0;
            }
        }
        else
        {
            SoLuongDaiLyHienCo = 0;
        }
    }

    // This method should be called when the selected Quan changes
    partial void OnSelectedQuanChanged(Quan? value)
    {
        _ = UpdateDaiLyCountsForSelectedQuan();
    }

    [RelayCommand]
    private async Task TiepNhanDaiLy()
    {
        if (!await ValidateInput())
            return;

        try
        {
            IsLoading = true;

            var newDaiLy = new DaiLy
            {
                Ten = TenDaiLy,
                DiaChi = DiaChi,
                Email = Email,
                NgayTiepNhan = NgayTiepNhan,
                NoDaiLy = 0,
                MaLoaiDaiLy = SelectedLoaiDaiLy!.MaLoaiDaiLy,
                MaQuan = SelectedQuan!.MaQuan
            };

            await daiLyService.AddDaiLyAsync(newDaiLy);

            await AlertUtil.ShowSuccessAlert("Thêm đại lý thành công!");
            
            // Close popup after adding successfully
            await CloseWindow();
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi khi thêm đại lý: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task DaiLyMoi()
    {
        TenDaiLy = string.Empty;
        SoDienThoai = string.Empty;
        Email = string.Empty;
        DiaChi = string.Empty;
        NgayTiepNhan = DateTime.Now;
        
        if (LoaiDaiLies.Any())
            SelectedLoaiDaiLy = LoaiDaiLies[0];
        
        if (Quans.Any())
        {
            SelectedQuan = Quans[0];
            await UpdateDaiLyCountsForSelectedQuan();
        }

        try
        {
            MaDaiLy = await daiLyService.GetNextAvailableIdAsync();
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi khi tạo mã đại lý mới: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task CloseWindow()
    {
        try
        {
            if (currentPopup != null)
            {
                await currentPopup.CloseAsync();
            }
        }
        catch (Exception ex)
        {
            await AlertUtil.ShowErrorAlert($"Lỗi khi đóng cửa sổ: {ex.Message}");
        }
    }

    private async Task<bool> ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(TenDaiLy))
        {
            await AlertUtil.ShowErrorAlert("Vui lòng nhập tên đại lý");
            return false;
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            await AlertUtil.ShowErrorAlert("Vui lòng nhập email");
            return false;
        }

        if (string.IsNullOrWhiteSpace(DiaChi))
        {
            await AlertUtil.ShowErrorAlert("Vui lòng nhập địa chỉ");
            return false;
        }

        if (SelectedLoaiDaiLy == null)
        {
            await AlertUtil.ShowErrorAlert("Vui lòng chọn loại đại lý");
            return false;
        }

        if (SelectedQuan == null)
        {
            await AlertUtil.ShowErrorAlert("Vui lòng chọn quận");
            return false;
        }

        // Check if adding this agency would exceed the maximum limit
        if (SoLuongDaiLyHienCo >= SoLuongDaiLyToiDa)
        {
            await AlertUtil.ShowErrorAlert($"Không thể thêm đại lý. Quận {SelectedQuan.TenQuan} đã đạt số lượng tối đa ({SoLuongDaiLyToiDa} đại lý)");
            return false;
        }

        return true;
    }
}
