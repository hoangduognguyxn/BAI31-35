using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class SinhVien
{
    public string MSSV { get; set; }
    public string HoTen { get; set; }
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public double DiemTrungBinh
    {
        get { return (DiemToan + DiemLy + DiemHoa) / 3; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        try
        {
            int soLuongSinhVien = NhapSoLuongSinhVien();
            List<SinhVien> danhSachSinhVien = NhapThongTinSinhVien(soLuongSinhVien);

            TinhDiemTrungBinh(danhSachSinhVien);
            HienThiThongTinSinhVien(danhSachSinhVien);
            HienThiSinhVienDiemTrungBinhLonHon9_5(danhSachSinhVien);
            int soSinhVienTren5 = DemSoSinhVienDiemTrungBinhTren5(danhSachSinhVien);
            Console.WriteLine($"Số sinh viên có điểm trung bình > 5: {soSinhVienTren5}");

            danhSachSinhVien = SapXepDiemTrungBinhTangDan(danhSachSinhVien);
            Console.WriteLine("\nDanh sách sinh viên sau khi sắp xếp theo điểm trung bình tăng dần:");
            HienThiThongTinSinhVien(danhSachSinhVien);

            danhSachSinhVien = SapXepTheoHoTen(danhSachSinhVien);
            Console.WriteLine("\nDanh sách sinh viên sau khi sắp xếp theo họ tên:");
            HienThiThongTinSinhVien(danhSachSinhVien);

            string tenFile = NhapTenFile();
            GhiThongTinSinhVienVaoFile(danhSachSinhVien, tenFile);
            List<SinhVien> danhSachSinhVienTuFile = DocThongTinSinhVienTuFile(tenFile);
            Console.WriteLine("\nDanh sách sinh viên từ file:");
            HienThiThongTinSinhVien(danhSachSinhVienTuFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
        }
    }

    static int NhapSoLuongSinhVien()
    {
        int soLuong;
        while (true)
        {
            try
            {
                Console.Write("Nhập số lượng sinh viên: ");
                soLuong = int.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ.");
            }
        }
        return soLuong;
    }

    static List<SinhVien> NhapThongTinSinhVien(int soLuong)
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        for (int i = 0; i < soLuong; i++)
        {
            SinhVien sv = new SinhVien();
            Console.WriteLine($"Nhập thông tin cho sinh viên thứ {i + 1}:");
            Console.Write("Mã sinh viên: ");
            sv.MSSV = Console.ReadLine();
            Console.Write("Họ tên: ");
            sv.HoTen = Console.ReadLine();
            sv.DiemToan = NhapDiem("toán");
            sv.DiemLy = NhapDiem("lý");
            sv.DiemHoa = NhapDiem("hóa");
            danhSachSinhVien.Add(sv);
        }
        return danhSachSinhVien;
    }

    static double NhapDiem(string monHoc)
    {
        double diem;
        while (true)
        {
            try
            {
                Console.Write($"Điểm {monHoc}: ");
                diem = double.Parse(Console.ReadLine());
                if (diem < 0 || diem > 10)
                {
                    throw new Exception("Điểm phải nằm trong khoảng từ 0 đến 10.");
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Vui lòng nhập một số thực hợp lệ.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return diem;
    }

    static void TinhDiemTrungBinh(List<SinhVien> danhSachSinhVien)
    {
        foreach (SinhVien sv in danhSachSinhVien)
        {
            sv.DiemTrungBinh.ToString(); // Gọi thuộc tính để tính điểm trung bình
        }
    }

    static void HienThiThongTinSinhVien(List<SinhVien> danhSachSinhVien)
    {
        Console.WriteLine("\nThông tin sinh viên:");
        foreach (SinhVien sv in danhSachSinhVien)
        {
            Console.WriteLine($"MSSV: {sv.MSSV}, Họ tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
        }
    }

    static void HienThiSinhVienDiemTrungBinhLonHon9_5(List<SinhVien> danhSachSinhVien)
    {
        foreach (SinhVien sv in danhSachSinhVien)
        {
            if (sv.DiemTrungBinh > 9.5)
            {
                Console.WriteLine($"Sinh viên có điểm trung bình > 9.5 đầu tiên: {sv.HoTen}, MSSV: {sv.MSSV}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
                break;
            }
        }
    }

    static int DemSoSinhVienDiemTrungBinhTren5(List<SinhVien> danhSachSinhVien)
    {
        int count = 0;
        foreach (SinhVien sv in danhSachSinhVien)
        {
            if (sv.DiemTrungBinh > 5)
            {
                count++;
                continue;
            }
        }
        return count;
    }

    static List<SinhVien> SapXepDiemTrungBinhTangDan(List<SinhVien> danhSachSinhVien)
    {
        return danhSachSinhVien.OrderBy(sv => sv.DiemTrungBinh).ToList();
    }

    static List<SinhVien> SapXepTheoHoTen(List<SinhVien> danhSachSinhVien)
    {
        return danhSachSinhVien.OrderBy(sv => sv.HoTen).ToList();
    }

    static string NhapTenFile()
    {
        Console.Write("Nhập tên file để ghi thông tin sinh viên: ");
        return Console.ReadLine();
    }

    static void GhiThongTinSinhVienVaoFile(List<SinhVien> danhSachSinhVien, string tenFile)
    {
        using (StreamWriter writer = new StreamWriter(tenFile))
        {
            foreach (SinhVien sv in danhSachSinhVien)
            {
                writer.WriteLine($"{sv.MSSV},{sv.HoTen},{sv.DiemToan},{sv.DiemLy},{sv.DiemHoa},{sv.DiemTrungBinh:F2}");
            }
        }
    }

    static List<SinhVien> DocThongTinSinhVienTuFile(string tenFile)
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        try
        {
            using (StreamReader reader = new StreamReader(tenFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    SinhVien sv = new SinhVien
                    {
                        MSSV = parts[0],
                        HoTen = parts[1],
                        DiemToan = double.Parse(parts[2]),
                        DiemLy = double.Parse(parts[3]),
                        DiemHoa = double.Parse(parts[4])
                    };
                    danhSachSinhVien.Add(sv);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Có lỗi xảy ra khi đọc file: {ex.Message}");
        }
        return danhSachSinhVien;
    }
}
