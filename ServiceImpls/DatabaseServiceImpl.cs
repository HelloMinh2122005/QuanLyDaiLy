using QuanLyDaiLy.Configs;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;

namespace QuanLyDaiLy.ServiceImpls;

public class DatabaseServiceImpl : DatabaseService
{
    private readonly DatabaseConfig databaseConfig;

    public DatabaseServiceImpl(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public async Task InitializeAsync()
    {
        await databaseConfig.Initialize();
        await SeedData();
    }

    private async Task SeedData()
    {
        var context = databaseConfig.DataContext;

        if (context.Quans.Any() || context.LoaiDaiLies.Any() || context.DaiLies.Any() || context.ThamSos.Any())
        {
            return;
        }

        var quans = new List<Quan>
        {
            new Quan { TenQuan = "Quận 1" },
            new Quan { TenQuan = "Quận 3" },
            new Quan { TenQuan = "Quận 5" },
            new Quan { TenQuan = "Quận 7" }
        };
        context.Quans.AddRange(quans);
        await context.SaveChangesAsync();

        var loaiDaiLies = new List<LoaiDaiLy>
        {
            new LoaiDaiLy { TenLoaiDaiLy = "Loại I", NoToiDa = 50000000 },
            new LoaiDaiLy { TenLoaiDaiLy = "Loại II", NoToiDa = 30000000 }
        };
        context.LoaiDaiLies.AddRange(loaiDaiLies);
        await context.SaveChangesAsync();

        var dailies = new List<DaiLy>
        {
            new DaiLy
            {
                Ten = "Đại lý ABC",
                DiaChi = "123 Đường Nguyễn Huệ",
                Email = "abc@dailyabc.com",
                NgayTiepNhan = DateTime.Now.AddDays(-30),
                NoDaiLy = 5000000,
                MaQuan = quans[0].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[0].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý XYZ",
                DiaChi = "456 Đường Lê Lợi",
                Email = "xyz@dailyxyz.com",
                NgayTiepNhan = DateTime.Now.AddDays(-25),
                NoDaiLy = 3000000,
                MaQuan = quans[1].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[1].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý DEF",
                DiaChi = "789 Đường Pasteur",
                Email = "def@dailydef.com",
                NgayTiepNhan = DateTime.Now.AddDays(-20),
                NoDaiLy = 7000000,
                MaQuan = quans[2].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[0].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý GHI",
                DiaChi = "101 Đường Trần Hưng Đạo",
                Email = "ghi@dailyghi.com",
                NgayTiepNhan = DateTime.Now.AddDays(-15),
                NoDaiLy = 2500000,
                MaQuan = quans[3].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[1].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý JKL",
                DiaChi = "202 Đường Võ Văn Tần",
                Email = "jkl@dailyjkl.com",
                NgayTiepNhan = DateTime.Now.AddDays(-10),
                NoDaiLy = 4500000,
                MaQuan = quans[0].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[0].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý MNO",
                DiaChi = "303 Đường Điện Biên Phủ",
                Email = "mno@dailymno.com",
                NgayTiepNhan = DateTime.Now.AddDays(-8),
                NoDaiLy = 1800000,
                MaQuan = quans[1].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[1].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý PQR",
                DiaChi = "404 Đường Cách Mạng Tháng 8",
                Email = "pqr@dailypqr.com",
                NgayTiepNhan = DateTime.Now.AddDays(-5),
                NoDaiLy = 6200000,
                MaQuan = quans[2].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[0].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý STU",
                DiaChi = "505 Đường Hoàng Văn Thụ",
                Email = "stu@dailystu.com",
                NgayTiepNhan = DateTime.Now.AddDays(-3),
                NoDaiLy = 3800000,
                MaQuan = quans[3].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[1].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý VWX",
                DiaChi = "606 Đường Hai Bà Trưng",
                Email = "vwx@dailyvwx.com",
                NgayTiepNhan = DateTime.Now.AddDays(-2),
                NoDaiLy = 5500000,
                MaQuan = quans[0].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[0].MaLoaiDaiLy
            },
            new DaiLy
            {
                Ten = "Đại lý YZ",
                DiaChi = "707 Đường Nam Kỳ Khởi Nghĩa",
                Email = "yz@dailyyz.com",
                NgayTiepNhan = DateTime.Now.AddDays(-1),
                NoDaiLy = 2100000,
                MaQuan = quans[1].MaQuan,
                MaLoaiDaiLy = loaiDaiLies[1].MaLoaiDaiLy
            }
        };
        context.DaiLies.AddRange(dailies);
        await context.SaveChangesAsync();

        var thamSo = new ThamSo
        {
            TenThamSo = "SoLuongDaiLyToiDa",
            GiaTri = "50"
        };
        context.ThamSos.Add(thamSo);
        await context.SaveChangesAsync();
    }
}