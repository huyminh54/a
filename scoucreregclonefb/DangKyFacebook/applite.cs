using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using KAutoHelper;
using Newtonsoft.Json;
using ThuVienAndroid.CloneApi;
using ThuVienAndroid.EmailService;
using ThuVienAndroid.Enum;
using ThuVienAndroid.Helper;
using ThuVienAndroid.Model;
using ThuVienAndroid.ThuVien;

namespace DangKyFacebook;

public class applite : Form
{
	private CauHinhDangKy cauhinh = new CauHinhDangKy();

	private List<TaiKhoanGmail> _listGmail = new List<TaiKhoanGmail>();

	private int _live = 0;

	private int _die = 0;

	private int _tongso = 0;

	private int _thoigiantreomay = 10;

	private int _chuaveri = 0;

	private bool _tamdung = false;

	private bool _dung = false;

	private System.Windows.Forms.Timer _timer;

	private int _tongtienclone = 0;

	private int _tongtiengmail = 0;

	private string _createdby = ConfigurationManager.AppSettings["createdBy"];

	private Queue<string> _danhsachgmail = new Queue<string>();

	private int _hour;

	private int _minute;

	private int _second;

	public static List<CheckDieAccModel> _danhsachthietbi = new List<CheckDieAccModel>();

	private IContainer components = null;

	private Button batdau1;

	private Button Nutstop;

	private Panel panel1;

	private Panel panel2;

	private Button nutCauHinh;

	private DataGridView dataGridView1;

	private Label label4;

	private Label label3;

	private Label Die;

	private Label Live;

	private Label label11;

	private Label lblTotalDevice;

	private Button Stop;

	private Panel panel3;

	private Panel panel4;

	private DataGridViewTextBoxColumn TenMay;

	private DataGridViewTextBoxColumn Ten;

	private DataGridViewTextBoxColumn Email;

	private DataGridViewTextBoxColumn UID;

	private DataGridViewTextBoxColumn MatKhau;

	private DataGridViewTextBoxColumn FA;

	private DataGridViewTextBoxColumn Cookie;

	private DataGridViewTextBoxColumn Token;

	private DataGridViewTextBoxColumn TrangThai;

	private Panel panel6;

	private Label label2;

	private Label lblTrangThai;

	private Label ThoiGian;

	private Label label9;

	private Label label1;

	private Label label6;

	public applite()
	{
		InitializeComponent();
	}

	private void SetResult()
	{
		InvokeMethod(delegate
		{
			Live.Text = _live.ToString();
			Die.Text = _die.ToString();
		});
	}

	private void SetTotal()
	{
		InvokeMethod(delegate
		{
			CultureInfo cultureInfo = CultureInfo.GetCultureInfo("vi-VN");
		});
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		ThoiGian.Text = "00:00:00";
		lblTotalDevice.Text = ADBHelper.GetDevices().Count.ToString() ?? "";
		SetResult();
		SetTotal();
		_timer = new System.Windows.Forms.Timer
		{
			Enabled = false,
			Interval = 1000
		};
		_timer.Tick += TimerOnTick;
	}

	private void TimerOnTick(object sender, EventArgs e)
	{
		_second++;
		if (_second == 60)
		{
			_minute++;
			_second = 0;
		}
		if (_minute == 60)
		{
			_hour++;
			_minute = 0;
		}
		ThoiGian.Text = $"{_hour:00}:{_minute:00}:{_second:00}";
	}

	public void NhapTen(ThongTinTaiKhoan taikhoan, ThuVienAndroidChu thuVienAndroidChu)
	{
		thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
		ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
		SetTrangThai(taikhoan.Index, "Tên:" + taikhoan.Ho);
		ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.Ho);
		ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_TAB);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
		ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
		SetTrangThai(taikhoan.Index, "Tên:" + taikhoan.Ten);
		ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.Ten);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
		thuVienAndroidChu.TimKiemTheoClass("android.widget.button", click: true, 5);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
	}

	public void NhapSoPhone(ThongTinTaiKhoan taikhoan, ThuVienAndroidChu thuVienAndroidChu)
	{
		string[] array = ThuVienAndroidAnh.DocFile("dauso_DienThoai.txt");
		string text3 = array[ThuVienAndroidAnh.Random(0, array.Length)];
		string soDienThoai = (taikhoan.SoDienThoai = text3 + ThuVienAndroidAnh.Random(1111111, 9999999));
		SetTrangThai(taikhoan.Index, "Nhập Số Điện thoại");
		AddData(taikhoan);
		thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
		ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
		ThuVienAndroidAnh.DienChu(taikhoan.MaMay, soDienThoai);
		SetTrangThai(taikhoan.Index, "tiếp");
		thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
	}

	public void RegNVR_BanMoi(ThongTinTaiKhoan taikhoan)
	{
		taikhoan.UID = string.Empty;
		SetTrangThai(taikhoan.Index, "Vào Reg Nick Facebook ");
		ThuVienThongTin thuVienThongTin = new ThuVienThongTin(taikhoan, delegate(string trangthai)
		{
			SetTrangThai(taikhoan.Index, trangthai);
		});
		try
		{
			bool flag = false;
			ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
			ThuVienAndroidAnh.InitADBKeyBoard(taikhoan.MaMay);
			string xml = thuVienAndroidChu.Xml;
			ThuVienAndroidAnh.InitADBKeyBoard(taikhoan.MaMay);
			SetTrangThai(taikhoan.Index, "Tắt  app");
			ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.facebook.katana");
			SetTrangThai(taikhoan.Index, "xóa data app");
			ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.facebook.katana");
			ThuVienAndroidAnh.RemoveAppExternalData(taikhoan.MaMay, "com.facebook.katana");
			ThuVienAndroidAnh.CapFullQuyen(taikhoan.MaMay, "com.facebook.katana");
			StopWatchHelper stopWatchHelper = StopWatchHelper.Instance();
			stopWatchHelper.Start();
			OtpConfirmationApi otpConfirmationApi = OtpConfirmationApi.KhoiTao();
			for (int i = 0; i < 20; i++)
			{
				SetTrangThai(taikhoan.Index, "Mở  app");
				ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
				thuVienAndroidChu.ScanScreen();
				SetTrangThai(taikhoan.Index, "tạo tài khoản mới");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản mới", 1))
				{
					SetTrangThai(taikhoan.Index, "mở app thành công");
					break;
				}
				SetTrangThai(taikhoan.Index, "Check lỗi mỡ app");
				if (thuVienAndroidChu.KiemTraChu("text", "trang này hiện không hiển thị", 1))
				{
					SetTrangThai(taikhoan.Index, "Mở app Bị Lỗi");
					return;
				}
				if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
				{
					SetTrangThai(taikhoan.Index, "Treo máy");
					return;
				}
			}
			int num = 0;
			bool flag2 = true;
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < 50; j++)
			{
				SetTrangThai(taikhoan.Index, "Mở  app");
				ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
				if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
				{
					SetTrangThai(taikhoan.Index, "Treo máy");
					return;
				}
				thuVienAndroidChu.ScanScreen();
				SetTrangThai(taikhoan.Index, "tạo tài khoản mới");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản mới", 1))
				{
					num = 0;
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					SetTrangThai(taikhoan.Index, "bấm tạo tài khoản mới");
					thuVienAndroidChu.TimKiemTheoContentDesc("tạo tài khoản mới", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
					continue;
				}
				if (thuVienAndroidChu.ChuaChu("com.google.android.gms:id/credential_secondary_label"))
				{
					num = 0;
					thuVienAndroidChu.TimKiemTheoResourceId("com.google.android.gms:id/cancel", click: true, 5);
					continue;
				}
				SetTrangThai(taikhoan.Index, "bắt đầu");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "bắt đầu", 1))
				{
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					SetTrangThai(taikhoan.Index, "bấm bắt đầu");
					thuVienAndroidChu.TimKiemTheoContentDesc("bắt đầu", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
					continue;
				}
				SetTrangThai(taikhoan.Index, "bạn tên gì?");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "bạn tên gì?", 1))
				{
					if (num2 >= 5)
					{
						SetTrangThai(taikhoan.Index, "Lỗi điền tên");
						return;
					}
					num = 0;
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					SetTrangThai(taikhoan.Index, "Nhập họ");
					thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
					ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					taikhoan.Ho = ThuVienAndroidAnh.Ho;
					taikhoan.Ten = ThuVienAndroidAnh.Ten;
					SetTrangThai(taikhoan.Index, "Tên:" + taikhoan.Ho);
					ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.Ho);
					SetTrangThai(taikhoan.Index, "Nhập Tên");
					thuVienAndroidChu.TimKiemTheoContentDesc("tên", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
					SetTrangThai(taikhoan.Index, "Tên:" + taikhoan.Ten);
					ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.Ten);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
					num2++;
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "chọn tên của bạn", 1))
				{
					ThuVienAndroidAnh.GoBack(taikhoan.MaMay);
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "sử dụng tên khác", 1))
				{
					SetTrangThai(taikhoan.Index, "sử dụng tên khác");
					num = 0;
					ExecuteCommand("adb shell input tap 957 601");
					thuVienAndroidChu.TimKiemTheoContentDesc("sử dụng tên khác", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("resource-id", "android:id/numberpicker_input", 1))
				{
					SetTrangThai(taikhoan.Index, "chọn ngày tháng năm");
					num = 0;
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					SetTrangThai(taikhoan.Index, "chọn tháng");
					int num4 = ThuVienAndroidAnh.Random(1, 4);
					for (int k = 0; k < num4; k++)
					{
						ThuVienAndroidAnh.Vuot(taikhoan.MaMay, 553, 917, 529, 1311);
					}
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					SetTrangThai(taikhoan.Index, "chọn năm");
					int num5 = ThuVienAndroidAnh.Random(5, 8);
					for (int l = 0; l < num5; l++)
					{
						ThuVienAndroidAnh.Vuot(taikhoan.MaMay, 747, 920, 740, 1464, 200);
					}
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					SetTrangThai(taikhoan.Index, "Đặt");
					thuVienAndroidChu.TimKiemTheoResourceId("android:id/button1", click: true, 5);
					thuVienAndroidChu.ScanScreen();
					SetTrangThai(taikhoan.Index, "tiếp");
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
					continue;
				}
				if (thuVienAndroidChu.ChuaChu("bạn đã nhập sai thông tin"))
				{
					num = 0;
					thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					thuVienAndroidChu.ScanScreen();
					SetTrangThai(taikhoan.Index, "chọn năm");
					int num6 = ThuVienAndroidAnh.Random(5, 11);
					for (int m = 0; m < num6; m++)
					{
						ThuVienAndroidAnh.Vuot(taikhoan.MaMay, 984, 1104, 988, 1524, 200);
					}
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					SetTrangThai(taikhoan.Index, "Đặt");
					thuVienAndroidChu.TimKiemTheoResourceId("android:id/button1", click: true, 5);
					thuVienAndroidChu.ScanScreen();
					SetTrangThai(taikhoan.Index, "tiếp");
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
				}
				if (thuVienAndroidChu.ChuaChu("bạn bao nhiêu tuổi?"))
				{
					num = 0;
					string text = ThuVienAndroidAnh.Random(20, 51).ToString();
					ExecuteCommand("adb shell input text \"" + text + "\"");
					thuVienAndroidChu.ScanScreen();
					SetTrangThai(taikhoan.Index, "tiếp");
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 5.0);
					thuVienAndroidChu.ScanScreen();
					SetTrangThai(taikhoan.Index, "Ok");
					ExecuteCommand("adb shell input tap 774 1087");
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 5.0);
					thuVienAndroidChu.ScanScreen();
				}
				SetTrangThai(taikhoan.Index, "giới tính của bạn là gì?");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "chọn danh xưng", 1))
				{
					ThuVienAndroidAnh.GoBack(taikhoan.MaMay);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "giới tính của bạn là gì?", 1))
				{
					num = 0;
					SetTrangThai(taikhoan.Index, "chọn nữ");
					thuVienAndroidChu.TimKiemTheoContentDesc("nữ", click: true, 5);
					SetTrangThai(taikhoan.Index, "tiếp");
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.5);
					continue;
				}
				SetTrangThai(taikhoan.Index, "cho phép");
				if (thuVienAndroidChu.KiemTraChu("text", "cho phép", 1))
				{
					num = 0;
					for (int n = 0; n < 20; n++)
					{
						if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
						{
							SetTrangThai(taikhoan.Index, "Treo máy");
							return;
						}
						thuVienAndroidChu.ScanScreen();
						SetTrangThai(taikhoan.Index, "bấm cho phép");
						if (thuVienAndroidChu.ChuaChu("text=\"cho phép\""))
						{
							thuVienAndroidChu.TimKiemTheoText("cho phép", click: true, 1);
						}
						if (thuVienAndroidChu.KiemTraChu("content-desc", "số di động của bạn là gì?", 1))
						{
							break;
						}
					}
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("text", "allow", 1))
				{
					num = 0;
					for (int num7 = 0; num7 < 20; num7++)
					{
						if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
						{
							SetTrangThai(taikhoan.Index, "Treo máy");
							return;
						}
						thuVienAndroidChu.ScanScreen();
						SetTrangThai(taikhoan.Index, "bấm cho phép");
						if (thuVienAndroidChu.ChuaChu("text=\"allow\""))
						{
							thuVienAndroidChu.TimKiemTheoText("allow", click: true, 1);
						}
						if (thuVienAndroidChu.ChuaChu("text=\"cho phép\""))
						{
							thuVienAndroidChu.TimKiemTheoText("cho phép", click: true, 1);
						}
						if (thuVienAndroidChu.KiemTraChu("content-desc", "số di động của bạn là gì?", 1))
						{
							break;
						}
					}
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "cần hỗ trợ đăng nhập vào tài khoản ư?", 1))
				{
					ThuVienAndroidAnh.GoBack(taikhoan.MaMay);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "số di động của bạn là gì?", 1))
				{
					num = 0;
					NhapSoPhone(taikhoan, thuVienAndroidChu);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
					if (thuVienAndroidChu.KiemTraChu("content-desc", "số di động của bạn là gì?", 1) || thuVienAndroidChu.KiemTraChu("content-desc", "bạn cần hỗ trợ đăng nhập vào tài khoản ư?", 1) || thuVienAndroidChu.KiemTraChu("text", "bạn cần hỗ trợ đăng nhập vào tài khoản ư?", 1))
					{
						ThuVienAndroidAnh.GoBack(taikhoan.MaMay);
					}
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "xác nhận số di động của bạn", 1))
				{
					num = 0;
					SetTrangThai(taikhoan.Index, "Gửi qua SMS");
					ExecuteCommand("adb shell input tap 681 681");
					SetTrangThai(taikhoan.Index, "tiếp");
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp tục", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					if (cauhinh.VeriClone)
					{
						taikhoan.DaXacNhan = false;
						taikhoan.TrangThai = TrangThaiClone.Live;
						SetTrangThai(taikhoan.Index, "Reg Thành Công ");
						return;
					}
				}
				SetTrangThai(taikhoan.Index, "tạo mật khẩu");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "tạo mật khẩu", 1))
				{
					num = 0;
					SetTrangThai(taikhoan.Index, "Nhập Mật khẩu");
					thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
					string matKhau = ThuVienAndroidAnh.TaoMatKhau(13);
					taikhoan.MatKhau = matKhau;
					ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.3);
					ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.MatKhau);
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
					continue;
				}
				SetTrangThai(taikhoan.Index, "lúc khác");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "lúc khác", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("lưu", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
					flag2 = false;
				}
				if (num3 >= 7)
				{
					SetTrangThai(taikhoan.Index, "Lỗi đăng ký");
					return;
				}
				SetTrangThai(taikhoan.Index, "tôi đồng ý");
				if (thuVienAndroidChu.KiemTraChu("content-desc", "tôi đồng ý", 1))
				{
					flag2 = false;
					num3++;
					thuVienAndroidChu.TimKiemTheoContentDesc("tôi đồng ý", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
				}
				if (thuVienAndroidChu.ChuaChu("chính sách quyền riêng tư (bắt buộc)", "tính năng dựa trên vị trí (bắt buộc)", "bạn sẽ nhận được thông báo qua sms và có thể chọn không nhận bất cứ lúc nào"))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("chọn tất cả", click: true, 2);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					thuVienAndroidChu.TimKiemTheoContentDesc("tôi đồng ý", click: true, 2);
				}
				if (thuVienAndroidChu.KiemTraChu("text", "bị từ chối truy cập", 1))
				{
					SetTrangThai(taikhoan.Index, "bị từ chối truy cập ");
					thuVienAndroidChu.TimKiemTheoText("ok", click: true, 3);
					return;
				}
				if (thuVienAndroidChu.ChuaChu("chúng tôi gặp sự cố khi thiết lập facebook bằng tiếng việt"))
				{
					SetTrangThai(taikhoan.Index, "click Thử lại ");
					thuVienAndroidChu.TimKiemTheoText("thử lại", click: true, 3);
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "xác nhận số di động của bạn", 1))
				{
					num = 0;
					SetTrangThai(taikhoan.Index, "Gửi qua SMS");
					ExecuteCommand("adb shell input tap 681 681");
					SetTrangThai(taikhoan.Index, "tiếp");
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp tục", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "nhập mã xác nhận", 1))
				{
					SetTrangThai(taikhoan.Index, "Reg Thành Công ");
					break;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "xác nhận tài khoản", 1))
				{
					SetTrangThai(taikhoan.Index, "Reg Thành Công ");
					break;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "email của bạn là gì?", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("đăng ký bằng số di động", click: true, 2);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
				}
				if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
				{
					taikhoan.TrangThai = TrangThaiClone.Die;
					_die++;
					SetTrangThai(taikhoan.Index, "Oẳng chó");
					return;
				}
				flag = thuVienAndroidChu.KiemTraChu("content-desc", "tiếp", 1);
				if (flag && flag2)
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
					num++;
				}
				if (num >= 10)
				{
					SetTrangThai(taikhoan.Index, "Lỗi treo máy");
					return;
				}
				if (j >= 10 && ThuVienAndroidAnh.KiemTraAnh(taikhoan.MaMay, "180_2.png", 2000, 1))
				{
					taikhoan.TrangThai = TrangThaiClone.Die;
					_die++;
					SetTrangThai(taikhoan.Index, "Oẳng chó");
					return;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "bạn đã có tài khoản facebook chưa?", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("không, tạo tài khoản mới", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "xác nhận bằng mã", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("xác nhận bằng mã", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					break;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "đây có phải là tài khoản của bạn không?", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("không, tạo tài khoản mới", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
				}
				SetTrangThai(taikhoan.Index, "Check lỗi mỡ app");
				if (thuVienAndroidChu.KiemTraChu("text", "trang này hiện không hiển thị", 1))
				{
					SetTrangThai(taikhoan.Index, "Mở app Bị Lỗi");
					return;
				}
				if (thuVienAndroidChu.ChuaChu("trong số này có tài khoản"))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("không, tạo tài khoản mới", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
				}
				if (thuVienAndroidChu.ChuaChu("chúng tôi không thể tạo tài khoản"))
				{
					thuVienAndroidChu.TimKiemTheoText("ok", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					return;
				}
			}
			taikhoan.UID = string.Empty;
			SetTrangThai(taikhoan.Index, "Kiễm tra  Đăng ký ");
			for (int num8 = 0; num8 < 50; num8++)
			{
				if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
				{
					SetTrangThai(taikhoan.Index, "Treo máy");
					break;
				}
				SetTrangThai(taikhoan.Index, "Kiễm tra Đăng ký ");
				ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
				if (string.IsNullOrEmpty(taikhoan.UID))
				{
					ThongTinTaiKhoan thongTinTaiKhoan = ThuVienAndroidAnh.LayCookieToken(taikhoan.MaMay, "", 3);
					taikhoan.Token = thongTinTaiKhoan.Token;
					taikhoan.Cookie = thongTinTaiKhoan.Cookie;
					taikhoan.UID = thongTinTaiKhoan.UID;
					AddData(taikhoan);
				}
				if (num3 >= 7)
				{
					SetTrangThai(taikhoan.Index, "Lỗi đăng ký");
					break;
				}
				TamDung();
				if (thuVienAndroidChu.KiemTraChu("content-desc", "tôi đồng ý", 1))
				{
					flag2 = false;
					num3++;
					thuVienAndroidChu.TimKiemTheoContentDesc("tôi đồng ý", click: true, 3);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
				}
				if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
				{
					taikhoan.TrangThai = TrangThaiClone.Die;
					_die++;
					SetTrangThai(taikhoan.Index, "Oẳng chó");
					break;
				}
				TamDung();
				thuVienAndroidChu.ScanScreen();
				bool flag3 = false;
				bool flag4 = false;
				SetTrangThai(taikhoan.Index, "Tìm nhập mã xác nhận");
				flag = thuVienAndroidChu.KiemTraChu("content-desc", "nhập mã xác nhận", 1);
				while (flag)
				{
					if (cauhinh.VeriClone)
					{
						taikhoan.DaXacNhan = false;
						taikhoan.TrangThai = TrangThaiClone.Live;
						return;
					}
					for (int num9 = 0; num9 < 30; num9++)
					{
						if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
						{
							SetTrangThai(taikhoan.Index, "Treo máy");
							return;
						}
						TamDung();
						SetTrangThai(taikhoan.Index, "Tìm nhập mã xác nhận");
						thuVienAndroidChu.ScanScreen();
						if (thuVienAndroidChu.KiemTraChu("content-desc", "nhập mã xác nhận", 1))
						{
							SetTrangThai(taikhoan.Index, "Bấm nhập mã xác nhận");
							thuVienAndroidChu.TimKiemTheoContentDesc("tôi không nhận được mã", click: true, 5);
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
						}
						SetTrangThai(taikhoan.Index, "Tìm xác nhận bằng email");
						thuVienAndroidChu.ScanScreen();
						TamDung();
						if (cauhinh.IsVeriMail)
						{
							if (thuVienAndroidChu.KiemTraChu("content-desc", "xác nhận bằng email", 1))
							{
								SetTrangThai(taikhoan.Index, "Bấm xác nhận bằng email");
								thuVienAndroidChu.TimKiemTheoContentDesc("xác nhận bằng email", click: true, 5);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
							}
						}
						else if (thuVienAndroidChu.KiemTraChu("content-desc", "đổi số di động", 1))
						{
							SetTrangThai(taikhoan.Index, "Bấm đổi số di động");
							thuVienAndroidChu.TimKiemTheoContentDesc("đổi số di động", click: true, 5);
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
						}
						bool flag5 = true;
						bool flag6 = true;
						string text5;
						while (true)
						{
							IL_19f8:
							for (int num10 = 0; num10 < 5; num10++)
							{
								thuVienAndroidChu.ScanScreen();
								TamDung();
								if (thuVienAndroidChu.KiemTraChu("content-desc", cauhinh.IsVeriMail ? "nhập email" : "nhập số di động", 1))
								{
									TamDung();
									SetTrangThai(taikhoan.Index, "Lấy mail");
									thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
									string text4 = "";
									while (string.IsNullOrEmpty(text4))
									{
										text4 = otpConfirmationApi.LayPhoneOrMail();
										Thread.Sleep(1000);
									}
									if (!cauhinh.IsVeriMail && !text4.StartsWith("+"))
									{
										text4 = "+" + text4;
									}
									TamDung();
									SetTrangThai(taikhoan.Index, "Nhập mail: " + text4);
									ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
									ThuVienAndroidAnh.DienChu(taikhoan.MaMay, text4);
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									thuVienAndroidChu.ScanScreen();
									SetTrangThai(taikhoan.Index, "Tiếp");
									thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
									break;
								}
							}
							bool flag7 = thuVienAndroidChu.KiemTraChu("content-desc", cauhinh.IsVeriMail ? "nhập email" : "nhập số di động", 1);
							flag3 = false;
							stopWatchHelper.Start();
							SetTrangThai(taikhoan.Index, "Lấy mã xác nhận");
							int num11 = 3;
							int num12 = 0;
							for (int num13 = 0; num13 < 20; num13++)
							{
								if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
								{
									SetTrangThai(taikhoan.Index, "Treo máy");
									return;
								}
								thuVienAndroidChu.ScanScreen();
								if (thuVienAndroidChu.KiemTraChu("content-desc", "confirm your mobile number with an sms", 1))
								{
									num = 0;
									ExecuteCommand("adb shell input tap 533 1471");
									SetTrangThai(taikhoan.Index, "Gửi qua SMS");
									ExecuteCommand("adb shell input tap 681 681");
									SetTrangThai(taikhoan.Index, "tiếp");
									thuVienAndroidChu.TimKiemTheoContentDesc("tiếp tục", click: true, 5);
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									if (cauhinh.VeriClone)
									{
										taikhoan.DaXacNhan = false;
										taikhoan.TrangThai = TrangThaiClone.Live;
										SetTrangThai(taikhoan.Index, "Reg Thành Công ");
										return;
									}
								}
								if (thuVienAndroidChu.KiemTraChu("content-desc", "mã xác nhận", 1))
								{
									text5 = otpConfirmationApi.LayMaXacNhan();
									if (!string.IsNullOrEmpty(text5))
									{
										goto IL_2030;
									}
									SetTrangThai(taikhoan.Index, "Bấm tôi không nhận được mã");
									if (thuVienAndroidChu.KiemTraChu("content-desc", "tôi không nhận được mã", 2))
									{
										thuVienAndroidChu.TimKiemTheoContentDesc("tôi không nhận được mã", click: true, 2);
										SetTrangThai(taikhoan.Index, "Bấm gửi lại mã xác nhận");
										if (cauhinh.IsVeriMail)
										{
											thuVienAndroidChu.TimKiemTheoContentDesc("gửi lại mã xác nhận", click: true, 5);
										}
										else
										{
											thuVienAndroidChu.TimKiemTheoContentDesc("gửi lại mã qua sms", click: true, 5);
										}
										ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									}
									num12++;
									flag3 = true;
								}
								TamDung();
								if (thuVienAndroidChu.ChuaChu("phải nhập số di động", "xác minh một tài khoản khác", "vui lòng thử số khác"))
								{
									goto IL_19f8;
								}
								if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
								{
									taikhoan.TrangThai = TrangThaiClone.Die;
									_die++;
									SetTrangThai(taikhoan.Index, "Oẳng chó");
									return;
								}
								if (num12 < num11)
								{
									continue;
								}
								thuVienAndroidChu.ScanScreen();
								TamDung();
								SetTrangThai(taikhoan.Index, "Bấm tôi không nhận được mã");
								if (!thuVienAndroidChu.KiemTraChu("content-desc", "tôi không nhận được mã", 2))
								{
									continue;
								}
								thuVienAndroidChu.ScanScreen();
								TamDung();
								thuVienAndroidChu.TimKiemTheoContentDesc("tôi không nhận được mã", click: true, 2);
								SetTrangThai(taikhoan.Index, "Bấm gửi lại mã xác nhận");
								if (cauhinh.IsVeriMail)
								{
									if (thuVienAndroidChu.KiemTraChu("content-desc", "xác nhận bằng email", 1))
									{
										SetTrangThai(taikhoan.Index, "Bấm xác nhận bằng email");
										thuVienAndroidChu.TimKiemTheoContentDesc("xác nhận bằng email", click: true, 5);
										ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
									}
								}
								else
								{
									thuVienAndroidChu.ScanScreen();
									if (thuVienAndroidChu.KiemTraChu("content-desc", "đổi số di động", 1))
									{
										SetTrangThai(taikhoan.Index, "Bấm đổi số di động");
										thuVienAndroidChu.TimKiemTheoContentDesc("đổi số di động", click: true, 5);
										ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
									}
								}
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
								goto IL_19f8;
							}
							break;
						}
						continue;
						IL_2030:
						TamDung();
						if (thuVienAndroidChu.KiemTraChu("content-desc", "xác nhận số di động của bạn", 1))
						{
							num = 0;
							SetTrangThai(taikhoan.Index, "Gửi qua SMS");
							ExecuteCommand("adb shell input tap 681 681");
							SetTrangThai(taikhoan.Index, "tiếp");
							thuVienAndroidChu.TimKiemTheoContentDesc("tiếp tục", click: true, 5);
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
							if (cauhinh.VeriClone)
							{
								taikhoan.DaXacNhan = false;
								taikhoan.TrangThai = TrangThaiClone.Live;
								SetTrangThai(taikhoan.Index, "Reg Thành Công ");
								return;
							}
						}
						SetTrangThai(taikhoan.Index, "Nhập mã xác nhận: " + text5);
						ThuVienAndroidAnh.DienChu(taikhoan.MaMay, text5);
						ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
						thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
						ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
						taikhoan.DaXacNhan = true;
						break;
					}
					stopWatchHelper.Start();
					AddData(taikhoan);
					SetTrangThai(taikhoan.Index, "Kiểm tra Veri");
					int num14 = 0;
					while (true)
					{
						if (num14 < 20)
						{
							if (stopWatchHelper.TotalMinutes >= _thoigiantreomay)
							{
								SetTrangThai(taikhoan.Index, "Treo máy");
								return;
							}
							TamDung();
							thuVienAndroidChu.ScanScreen();
							if (!thuVienAndroidChu.ChuaChu("thêm ảnh đại diện", "text=\"thêm ảnh\"", "lưu thông tin đăng nhập", "content-desc=\"đi tới trang cá nhân\"", "bật tính năng tải danh bạ lên để tìm bạn bè nhanh hơn"))
							{
								if (thuVienAndroidChu.ChuaChu("cho phép facebook truy cập vị trí của bạn", "cho phép"))
								{
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									thuVienAndroidChu.TimKiemTheoContentDesc("từ chối", click: true, 3);
								}
								else
								{
									flag = thuVienAndroidChu.ChuaChu("mã quá dài", "kiểm tra xem bạn đã nhập đúng chưa");
									if (flag)
									{
										break;
									}
									if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
									{
										taikhoan.TrangThai = TrangThaiClone.Die;
										_die++;
										SetTrangThai(taikhoan.Index, "Oẳng chó");
										SetResult();
										return;
									}
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
								}
								num14++;
								continue;
							}
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
						}
						bool flag8 = false;
						for (int num15 = 0; num15 < 30; num15++)
						{
							thuVienAndroidChu.ScanScreen();
							if (thuVienAndroidChu.KiemTraChu("content-desc", "thêm ảnh đại diện", 1))
							{
								thuVienAndroidChu.TimKiemTheoContentDesc("bỏ qua", click: true, 2);
							}
							TamDung();
							if ((thuVienAndroidChu.ChuaChu("bật") && thuVienAndroidChu.ChuaChu("lúc khác")) || thuVienAndroidChu.ChuaChu("tải danh bạ"))
							{
								if (thuVienAndroidChu.KiemTraChu("content-desc", "bật", 1))
								{
									thuVienAndroidChu.TimKiemTheoContentDesc("bật", click: true, 2);
								}
								if (thuVienAndroidChu.KiemTraChu("content-desc", "tiếp", 1))
								{
									thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 2);
									thuVienAndroidChu.TimKiemTheoText("tìm bạn bè", click: true, 3);
								}
							}
							if (thuVienAndroidChu.KiemTraNhieuLop("//node[@class='android.widget.compoundbutton'][@checked='false']", 1))
							{
								thuVienAndroidChu.TimKiemTheoXPath("//node[@class='android.widget.compoundbutton'][@checked='false']", isClick: true, 1);
							}
							if (!flag8)
							{
								for (int num16 = 4; num16 < 30; num16++)
								{
									if (thuVienAndroidChu.KiemTraChu("content-desc", $"thêm {num16} người bạn", 1))
									{
										thuVienAndroidChu.TimKiemTheoContentDesc($"thêm {num16} người bạn", click: true, 2);
										flag8 = true;
										taikhoan.CoBanBe = true;
										break;
									}
								}
							}
							if (thuVienAndroidChu.ChuaChu("nhấn đúp để tạo bài viết", "trang cá nhân, tab", "bảng feed, tab") || thuVienAndroidChu.ChuaChu("không tìm thấy người bạn nào", "tìm kiếm bạn bè vào lúc khác"))
							{
								break;
							}
							if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
							{
								taikhoan.TrangThai = TrangThaiClone.Die;
								_die++;
								SetTrangThai(taikhoan.Index, "Oẳng chó");
								SetResult();
								return;
							}
							Thread.Sleep(1000);
						}
						ThemThongTinCaNhan(taikhoan);
						return;
					}
					SetTrangThai(taikhoan.Index, "Sai mã");
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					flag4 = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void capquyenFB(ThongTinTaiKhoan taikhoan)
	{
		bool flag = false;
		ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
		ThuVienAndroidAnh.InitADBKeyBoard(taikhoan.MaMay);
		AddData(taikhoan);
		ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.facebook.katana");
		ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.android.settings");
		SetTrangThai(taikhoan.Index, "Mở  cài đặt");
		ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.android.settings");
		thuVienAndroidChu.ScanScreen();
		SetTrangThai(taikhoan.Index, "Ứng dụng và thông báo");
		thuVienAndroidChu.TimKiemTheoText("ứng dụng và thông báo", click: true, 5);
		thuVienAndroidChu.ScanScreen();
		SetTrangThai(taikhoan.Index, "Chọn ứng dụng facebook");
		thuVienAndroidChu.TimKiemTheoText("facebook", click: true, 5);
		thuVienAndroidChu.ScanScreen();
		SetTrangThai(taikhoan.Index, "Quyền");
		thuVienAndroidChu.TimKiemTheoText("quyền", click: true, 5);
		thuVienAndroidChu.ScanScreen();
		SetTrangThai(taikhoan.Index, "Bật bộ nhớ");
		thuVienAndroidChu.TimKiemTheoText("bộ nhớ", click: true, 5);
		SetTrangThai(taikhoan.Index, "Bật danh Bạ");
		thuVienAndroidChu.TimKiemTheoText("danh bạ", click: true, 5);
		SetTrangThai(taikhoan.Index, "Bật điện thoại");
		thuVienAndroidChu.TimKiemTheoText("điện thoại", click: true, 5);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
	}

	public KetQuaReg Dangnhap_Facebook(ThongTinTaiKhoan taikhoan)
	{
		SetTrangThai(taikhoan.Index, "Đăng nhập NVR");
		ThuVienThongTin thuVienThongTin = new ThuVienThongTin(taikhoan, delegate(string trangthai)
		{
			SetTrangThai(taikhoan.Index, trangthai);
		});
		try
		{
			while (true)
			{
				bool flag = false;
				ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
				ThuVienAndroidAnh.InitADBKeyBoard(taikhoan.MaMay);
				SetTrangThai(taikhoan.Index, "Tắt app Facebook");
				ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.facebook.katana");
				SetTrangThai(taikhoan.Index, "Xoá data Facebook");
				ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.facebook.katana");
				ThuVienAndroidAnh.RemoveAppExternalData(taikhoan.MaMay, "com.facebook.katana");
				if (taikhoan.LayLaiClone)
				{
					DoiProxy(taikhoan);
				}
				TamDung();
				AddData(taikhoan);
				if (taikhoan.LayLaiClone)
				{
					SetTrangThai(taikhoan.Index, "Change IP");
					SetTrangThai(taikhoan.Index, "Change thiết bị");
					if (cauhinh.ChangeThietBi)
					{
						ThuVienVPN.Change_thietBi(taikhoan);
					}
				}
				ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_HOME);
				SetTrangThai(taikhoan.Index, "Cấp quyền");
				ThuVienAndroidAnh.CapFullQuyen(taikhoan.MaMay, "com.facebook.katana");
				SetTrangThai(taikhoan.Index, "Mở Facebook");
				ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
				SetTrangThai(taikhoan.Index, "Đợi tải app Facebook");
				ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
				while (true)
				{
					int num = 0;
					bool flag2;
					while (true)
					{
						if (num < 30)
						{
							if (num == 15 || num == 20)
							{
								break;
							}
							TamDung();
							thuVienAndroidChu.ScanScreen();
							string text = "";
							if (thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản facebook mới", 1) || thuVienAndroidChu.ChuaChu("•"))
							{
								text = "số điện thoại hoặc email";
							}
							flag = thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản mới", 1);
							if (flag)
							{
								text = "số di động hoặc email";
							}
							if (!flag && string.IsNullOrEmpty(text))
							{
								if (thuVienAndroidChu.KiemTraChu("resource-id", "android:id/aerr_close", 1))
								{
									thuVienAndroidChu.TimKiemTheoResourceId("android:id/aerr_close", click: true, 1);
									ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
								}
								goto IL_0899;
							}
							if (taikhoan.LayLaiClone)
							{
								CloneApi cloneApi = CloneApi.KhoiTao();
								cloneApi.InitStatus(delegate(string trangthai)
								{
									SetTrangThai(taikhoan.Index, trangthai);
								});
								while (true)
								{
									string text2 = cloneApi.LayClone();
									if (string.IsNullOrEmpty(text2))
									{
										continue;
									}
									ThuVienAndroidAnh.GhiFile("CloneLayDuoc.txt", text2);
									taikhoan.DaXacNhan = false;
									taikhoan.Email = string.Empty;
									string[] array = text2.Split('|');
									if (text2.Contains("outlook.com") || text2.Contains("hotmail.com"))
									{
										try
										{
											taikhoan.Email = array[3] + "|" + array[4];
										}
										catch
										{
										}
									}
									taikhoan.UID = array[0];
									taikhoan.MatKhauCu = array[1];
									taikhoan.MatKhau = array[1];
									AddData(taikhoan);
									_tongso++;
									_tongtienclone = _tongso * 350;
									if (ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
									{
										break;
									}
									_die++;
									SetTotal();
									SetResult();
								}
								SetTotal();
								SetResult();
								if (string.IsNullOrEmpty(taikhoan.UID))
								{
									SetTrangThai(taikhoan.Index, "Không lấy được Clone");
									return KetQuaReg.LamCloneKhac;
								}
							}
							TamDung();
							taikhoan.LayLaiClone = true;
							SetTrangThai(taikhoan.Index, "Mở app thành công");
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
							if (thuVienAndroidChu.ChuaChu("Đăng nhập bằng tài khoản khác"))
							{
								thuVienAndroidChu.TimKiemTheoContentDesc("đăng nhập bằng tài khoản khác", click: true, 3);
								WaitLoading(taikhoan);
								taikhoan.LayLaiClone = false;
								goto IL_0899;
							}
							if (thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản facebook mới", 1) || thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản mới", 1))
							{
								TamDung();
								thuVienAndroidChu.TimKiemTheoText(text, click: true, 5);
								SetTrangThai(taikhoan.Index, "Điền UID");
								ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
								ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.UID);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
								SetTrangThai(taikhoan.Index, "Điền Mật Khẩu");
								thuVienAndroidChu.TimKiemTheoText("mật khẩu", click: true, 5);
								ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.MatKhauCu);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
								SetTrangThai(taikhoan.Index, "Đăng nhập");
								thuVienAndroidChu.TimKiemTheoContentDesc("đăng nhập", click: true, 5);
							}
							else
							{
								TamDung();
								ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_TAB);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
								ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_TAB);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
								SetTrangThai(taikhoan.Index, "Điền UID");
								ThuVienAndroidAnh.XoaChu(taikhoan.MaMay);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
								ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.UID);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
								SetTrangThai(taikhoan.Index, "Điền Mật Khẩu");
								ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_TAB);
								ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.MatKhauCu);
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
								SetTrangThai(taikhoan.Index, "Đăng nhập");
								ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_ENTER);
							}
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
						}
						OtpConfirmationApi otpConfirmationApi = OtpConfirmationApi.KhoiTao();
						otpConfirmationApi.InitStatus(delegate(string trangthai)
						{
							SetTrangThai(taikhoan.Index, trangthai);
						});
						TamDung();
						flag2 = false;
						goto IL_192c;
						IL_0899:
						num++;
					}
					break;
					IL_08ae:
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
					taikhoan.SoLanResetAppTrangChu++;
					if (taikhoan.SoLanResetAppTrangChu > 7)
					{
						SetTrangThai(taikhoan.Index, "Clone chưa VR + Tai khoản Gmail Live");
						ThuVienAndroidAnh.GhiFile("NVR_biLoi.txt", taikhoan.UID + "|" + taikhoan.MatKhauCu);
						ThuVienAndroidAnh.GhiFile("GmailConLive.txt", taikhoan.TaiKhoanGmail.Gmail ?? "");
						taikhoan.SoLanResetAppTrangChu = 0;
						taikhoan.SoLanTatMoApp = 0;
						_chuaveri++;
						taikhoan.TrangThai = TrangThaiClone.Unknow;
						return KetQuaReg.LamCloneKhac;
					}
					taikhoan.LayLaiClone = false;
					break;
					IL_192c:
					while (true)
					{
						SetTrangThai(taikhoan.Index, "Check login");
						int num2 = 0;
						int num3;
						int num4;
						while (true)
						{
							if (num2 < 80)
							{
								TamDung();
								if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
								{
									_die++;
									SetTrangThai(taikhoan.Index, "Oẳng chó");
									taikhoan.TrangThai = TrangThaiClone.Die;
									return KetQuaReg.LamCloneKhac;
								}
								if (num2 == 40)
								{
									SetTrangThai(taikhoan.Index, "Tắt mở lại app");
									ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.facebook.katana");
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
									ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 5.0);
								}
								bool flag3 = false;
								SetTrangThai(taikhoan.Index, "Check chúng tôi không thể liên hệ với bạn theo địa chỉ");
								thuVienAndroidChu.ScanScreen();
								if (thuVienAndroidChu.Xml.Contains("nhập email hợp lệ"))
								{
									string text3 = "nguyentiendao" + ThuVienAndroidAnh.Random(1111, 9999) + "@gmail.com";
									thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
									ThuVienAndroidAnh.DienChu(taikhoan.MaMay, text3);
									thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
									flag3 = true;
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
								}
								flag = thuVienAndroidChu.Xml.Contains("lưu thông tin đăng nhập");
								if (flag && !flag2)
								{
									if (thuVienAndroidChu.KiemTraChu("content-desc", "lúc khác", 1))
									{
										thuVienAndroidChu.TimKiemTheoContentDesc("lúc khác", click: true, 5);
										thuVienAndroidChu.TimKiemTheoResourceId("com.google.android.gms:id/credential_save_reject", click: true, 5);
										flag2 = true;
									}
									if (thuVienAndroidChu.KiemTraChu("content-desc", "bỏ qua", 1))
									{
										thuVienAndroidChu.TimKiemTheoContentDesc("bỏ qua", click: true, 5);
										flag2 = true;
									}
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									goto IL_13eb;
								}
								if (flag && flag2)
								{
									thuVienAndroidChu.TimKiemTheoText("lúc khác", click: true, 3);
									goto IL_13eb;
								}
								if (thuVienAndroidChu.KiemTraChu("resource-id", "com.google.android.gms:id/credential_save_reject", 1))
								{
									thuVienAndroidChu.TimKiemTheoResourceId("com.google.android.gms:id/credential_save_reject", click: true, 2);
								}
								if (thuVienAndroidChu.ChuaChu("tạo mã pin đăng nhập"))
								{
									thuVienAndroidChu.TimKiemTheoText("lúc khác", click: true, 3);
									goto IL_13eb;
								}
								if (thuVienAndroidChu.ChuaChu("cho phép facebook truy cập vị trí của bạn"))
								{
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									thuVienAndroidChu.TimKiemTheoContentDesc("từ chối", click: true, 3);
									goto IL_13eb;
								}
								if (thuVienAndroidChu.ChuaChu("từ chối") && thuVienAndroidChu.ChuaChu("cho phép"))
								{
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									thuVienAndroidChu.TimKiemTheoContentDesc("từ chối", click: true, 3);
									goto IL_13eb;
								}
								TamDung();
								if ((flag3 || thuVienAndroidChu.Xml.Contains("chúng tôi không thể liên hệ với bạn theo địa chỉ") || thuVienAndroidChu.Xml.Contains("update email address") || thuVienAndroidChu.Xml.Contains("enter the code from your sms") || thuVienAndroidChu.Xml.Contains("let us know this phone number") || thuVienAndroidChu.Xml.Contains("thay đổi địa chỉ email") || thuVienAndroidChu.Xml.Contains("chúng tôi đã gửi sms kèm mã tới") || thuVienAndroidChu.Xml.Contains("nhập mã gồm 5 chữ số") || thuVienAndroidChu.Xml.Contains("enter the 5-digit code we sent") || thuVienAndroidChu.Xml.Contains("xác nhận bằng số điện thoại") || thuVienAndroidChu.Xml.Contains("nhập số di động hợp lệ") || thuVienAndroidChu.Xml.Contains("thay đổi địa chỉ số điện thoại") || thuVienAndroidChu.Xml.Contains("gửi lại sms") || thuVienAndroidChu.Xml.Contains("thêm ảnh của bạn") || thuVienAndroidChu.Xml.Contains("chụp ảnh") || thuVienAndroidChu.Xml.Contains("bỏ qua") || thuVienAndroidChu.Xml.Contains("tải danh bạ lên") || thuVienAndroidChu.Xml.Contains("take photo") || thuVienAndroidChu.Xml.Contains("confirm by phone number")) && num2 >= 5)
								{
									if (taikhoan.SoLanTatMoApp > 1)
									{
										break;
									}
									taikhoan.SoLanTatMoApp++;
									SetTrangThai(taikhoan.Index, "Tắt mở lại app");
									ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.facebook.katana");
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
									ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 5.0);
								}
								TamDung();
								CheckCookie(thuVienAndroidChu);
								if (thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản facebook mới", 1))
								{
									goto IL_1d3b;
								}
								if (thuVienAndroidChu.ChuaChu("đang chờ phê duyệt"))
								{
									goto IL_1d4b;
								}
								if (thuVienAndroidChu.ChuaChu("đã xảy ra lỗi. vui lòng thử lại"))
								{
									ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.facebook.katana");
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
									ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 5.0);
								}
								TamDung();
								SetTrangThai(taikhoan.Index, "Check có phải email của bạn là");
								if (thuVienAndroidChu.KiemTraChu("text", "có phải email của bạn là " + taikhoan.Gmail.Split('|')[0].ToLower() + "?", 1) || thuVienAndroidChu.KiemTraChu("text", "có, đây là email của tôi", 1) || thuVienAndroidChu.KiemTraChu("text", "is your email " + taikhoan.Gmail.Split('|')[0].ToLower() + "?", 1) || thuVienAndroidChu.KiemTraChu("text", "yes, this is my email", 1))
								{
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
									SetTrangThai(taikhoan.Index, "Có phải email của bạn là");
									thuVienAndroidChu.TimKiemTheoClass("android.widget.button", click: true, 5);
									if (thuVienAndroidChu.KiemTraChu("text", "yes, this is my email", 1))
									{
										thuVienAndroidChu.TimKiemTheoText("yes, this is my email", click: true, 1);
									}
								}
								else
								{
									SetTrangThai(taikhoan.Index, "tự động xác nhận tài khoản của bạn");
									if (!thuVienAndroidChu.ChuaChu("tự động xác nhận tài khoản của bạn", "địa chỉ email này liên kết với thiết bị của bạn. chúng tôi sẽ tự động xác nhận tài khoản của bạn và thêm email này vào đó"))
									{
										if (!thuVienAndroidChu.ChuaChu("lưu thông tin đăng nhập của bạn", "cần nhấn vào ảnh đại diện") && false)
										{
											goto IL_1422;
										}
										if (thuVienAndroidChu.Xml.Contains("không thể kết nối với máy chủ") || thuVienAndroidChu.Xml.Contains("cannot connect to server"))
										{
											goto IL_1d07;
										}
										SetTrangThai(taikhoan.Index, "Check sai mật khẩu");
										if (thuVienAndroidChu.KiemTraChu("text", "sai mật khẩu", 1) || thuVienAndroidChu.ChuaChu("sai thông tin đăng nhập", "mật khẩu không khớp"))
										{
											SetTrangThai(taikhoan.Index, "Sai Mật Khẩu");
											thuVienAndroidChu.TimKiemTheoText("ok", click: true, 5);
											_die++;
											taikhoan.TrangThai = TrangThaiClone.Die;
											return KetQuaReg.LamCloneKhac;
										}
										SetTrangThai(taikhoan.Index, "Check phê duyệt đăng nhập");
										if (thuVienAndroidChu.ChuaChu("cần phê duyệt đăng nhập"))
										{
											SetTrangThai(taikhoan.Index, "Phê duyệt đăng nhập");
											_die++;
											taikhoan.TrangThai = TrangThaiClone.Die;
											return KetQuaReg.LamCloneKhac;
										}
										SetTrangThai(taikhoan.Index, "Check login");
										if (thuVienAndroidChu.KiemTraChu("text", "đăng nhập không thành công", 1))
										{
											goto IL_1d5b;
										}
										TamDung();
										flag = thuVienAndroidChu.KiemTraChu("content-desc", "nhắn tin", 1) || thuVienAndroidChu.KiemTraChu("content-desc", "tìm kiếm", 1);
										if (!(flag || flag3))
										{
											goto IL_13eb;
										}
										goto IL_08ae;
									}
									SetTrangThai(taikhoan.Index, "tiếp");
									thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
									ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
								}
							}
							num3 = 0;
							SetTrangThai(taikhoan.Index, "Check very thành công hay không");
							num4 = 0;
							goto IL_191f;
							IL_13eb:
							num2++;
						}
						break;
						IL_1400:
						thuVienAndroidChu.TimKiemTheoText("hủy", click: true, 5);
						thuVienAndroidChu.TimKiemTheoContentDesc("đăng nhập", click: true, 5);
						continue;
						IL_1422:
						taikhoan.DaXacNhan = true;
						goto IL_1b1e;
						IL_191f:
						while (true)
						{
							if (num4 < 50)
							{
								TamDung();
								thuVienAndroidChu.ScanScreen();
								SetTrangThai(taikhoan.Index, "Check Very lưu thông tin đăng nhập của bạn");
								if (thuVienAndroidChu.KiemTraChu("text", "lưu thông tin đăng nhập của bạn", 1))
								{
									SetTrangThai(taikhoan.Index, "Lưu thông tin đăng nhập của bạn");
								}
								else
								{
									if (thuVienAndroidChu.ChuaChu("<node index=\"0\" text=\"\" resource-id=\"android:id/content\" class=\"android.widget.FrameLayout\" package=\"com.facebook.katana\" content-desc=\"\" checkable=\"false\" checked=\"false\" clickable=\"false\" enabled=\"true\" focusable=\"false\" focused=\"false\" scrollable=\"false\" long-clickable=\"false\" password=\"false\" selected=\"false\" bounds=\"[0,84][1440,2560]\" /></node>") && num4 >= 3)
									{
										ThuVienAndroidAnh.TatApp(taikhoan.MaMay, "com.facebook.katana");
										ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
										ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
										ThuVienAndroidAnh.Doi(taikhoan.MaMay, 5.0);
									}
									if (thuVienAndroidChu.ChuaChu("com.google.android.packageinstaller") && thuVienAndroidChu.ChuaChu("android:id/switch_widget"))
									{
										ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
										ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
										goto IL_1917;
									}
									if (thuVienAndroidChu.Xml.Contains("chúng tôi đã gửi sms") || thuVienAndroidChu.Xml.Contains("nhập mã gồm 5 chữ số từ sms"))
									{
										break;
									}
									CheckCookie(thuVienAndroidChu);
									if (num4 >= 3)
									{
										SetTrangThai(taikhoan.Index, "tự động xác nhận tài khoản của bạn");
										if (thuVienAndroidChu.ChuaChu("tự động xác nhận tài khoản của bạn", "địa chỉ email này liên kết với thiết bị của bạn. chúng tôi sẽ tự động xác nhận tài khoản của bạn và thêm email này vào đó"))
										{
											SetTrangThai(taikhoan.Index, "tiếp");
											thuVienAndroidChu.TimKiemTheoContentDesc("tiếp", click: true, 5);
											ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
											num3++;
										}
										if (num3 >= 2)
										{
											SetTrangThai(taikhoan.Index, "1002 - Gmail Die");
											taikhoan.TrangThai = TrangThaiClone.Unknow;
											taikhoan.LayLaiClone = false;
											return KetQuaReg.DoiGmail;
										}
									}
									if (thuVienAndroidChu.Xml.Contains("không thể kết nối với máy chủ"))
									{
										goto IL_1400;
									}
									if (thuVienAndroidChu.Xml.Contains("cho phép") && thuVienAndroidChu.Xml.Contains("từ chối"))
									{
										SetTrangThai(taikhoan.Index, "Cho phép đọc vị trí");
									}
									else
									{
										TamDung();
										thuVienAndroidChu.ScanScreen();
										SetTrangThai(taikhoan.Index, "Check Very Thêm ảnh");
										if (!thuVienAndroidChu.Xml.Contains("thêm ảnh của bạn") && !thuVienAndroidChu.Xml.Contains("chụp ảnh") && !thuVienAndroidChu.Xml.Contains("bỏ qua") && (!thuVienAndroidChu.Xml.Contains("lúc khác") || !thuVienAndroidChu.Xml.Contains("bật")) && !thuVienAndroidChu.Xml.Contains("viết bài trên facebook") && !thuVienAndroidChu.Xml.Contains("tải danh bạ lên") && !thuVienAndroidChu.Xml.Contains("thêm 15 bạn bè để xem thêm bài viết") && !thuVienAndroidChu.Xml.Contains("take photo"))
										{
											if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
											{
												SetTrangThai(taikhoan.Index, "1000 - Oẳng chó");
												_die++;
												taikhoan.TrangThai = TrangThaiClone.Die;
												return KetQuaReg.DoiGmail;
											}
											TamDung();
											SetTrangThai(taikhoan.Index, "Check chúng tôi không thể tự động xác nhận tài khoản của bạn");
											if (thuVienAndroidChu.KiemTraChu("text", "chúng tôi không thể tự động xác nhận tài khoản của bạn.", 1) || thuVienAndroidChu.ChuaChu("đang chờ phê duyệt"))
											{
												SetTrangThai(taikhoan.Index, "1002 - Gmail Die");
												taikhoan.TrangThai = TrangThaiClone.Unknow;
												taikhoan.LayLaiClone = false;
												return KetQuaReg.DoiGmail;
											}
											goto IL_1917;
										}
										SetTrangThai(taikhoan.Index, "Thêm ảnh của bạn");
									}
								}
							}
							if (!cauhinh.XacMinhMail)
							{
								themmail_khongxacminh(taikhoan);
							}
							TamDung();
							goto IL_1b1e;
							IL_1917:
							num4++;
						}
						goto IL_1a14;
					}
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
					taikhoan.SoLanResetApp++;
					if (taikhoan.SoLanResetApp > 7)
					{
						SetTrangThai(taikhoan.Index, "Clone chưa VR + Tai khoản Gmail Live");
						ThuVienAndroidAnh.GhiFile("NVR_biLoi.txt", taikhoan.UID + "|" + taikhoan.MatKhauCu);
						taikhoan.SoLanResetApp = 0;
						taikhoan.SoLanTatMoApp = 0;
						_chuaveri++;
						taikhoan.TrangThai = TrangThaiClone.Unknow;
						return KetQuaReg.LamCloneKhac;
					}
					taikhoan.LayLaiClone = false;
					break;
					IL_1a14:
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
					taikhoan.SoLanResetAppTrangChu++;
					if (taikhoan.SoLanResetAppTrangChu > 7)
					{
						SetTrangThai(taikhoan.Index, "Clone chưa VR + Tai khoản Gmail Live");
						ThuVienAndroidAnh.GhiFile("NVR_biLoi.txt", taikhoan.UID + "|" + taikhoan.MatKhauCu);
						ThuVienAndroidAnh.GhiFile("GmailConLive.txt", taikhoan.TaiKhoanGmail.Gmail ?? "");
						taikhoan.SoLanResetAppTrangChu = 0;
						taikhoan.SoLanTatMoApp = 0;
						_chuaveri++;
						taikhoan.TrangThai = TrangThaiClone.Unknow;
						return KetQuaReg.LamCloneKhac;
					}
					taikhoan.LayLaiClone = false;
					break;
					IL_1b1e:
					SetTrangThai(taikhoan.Index, "Very thành công");
					switch (Thaymail_trongcaidat(taikhoan))
					{
					case "die":
						SetTrangThai(taikhoan.Index, "2000 - Oẳng chó");
						_die++;
						taikhoan.TrangThai = TrangThaiClone.Die;
						return KetQuaReg.DoiGmail;
					case "doigmail":
						SetTrangThai(taikhoan.Index, "Gmail Die");
						taikhoan.TrangThai = TrangThaiClone.Unknow;
						taikhoan.LayLaiClone = false;
						return KetQuaReg.DoiGmail;
					case "lamlai":
						ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
						taikhoan.SoLanResetAppTrangChu++;
						if (taikhoan.SoLanResetAppTrangChu > 4)
						{
							SetTrangThai(taikhoan.Index, "Clone chưa VR + Tai khoản Gmail Live");
							ThuVienAndroidAnh.GhiFile("NVR_biLoi.txt", taikhoan.UID + "|" + taikhoan.MatKhauCu);
							ThuVienAndroidAnh.GhiFile("GmailConLive.txt", taikhoan.TaiKhoanGmail.Gmail ?? "");
							taikhoan.SoLanResetAppTrangChu = 0;
							taikhoan.SoLanTatMoApp = 0;
							_chuaveri++;
							taikhoan.TrangThai = TrangThaiClone.Unknow;
							return KetQuaReg.LamCloneKhac;
						}
						taikhoan.LayLaiClone = false;
						break;
					default:
						ThemThongTinCaNhan(taikhoan);
						return KetQuaReg.LamCloneKhac;
					}
					break;
					IL_1d07:
					SetTrangThai(taikhoan.Index, "Đổi IP");
					DoiProxy(taikhoan);
					taikhoan.LayLaiClone = false;
					break;
					IL_1d3b:
					taikhoan.LayLaiClone = false;
					continue;
					IL_1d4b:
					taikhoan.LayLaiClone = true;
					break;
					IL_1d5b:
					taikhoan.LayLaiClone = false;
					break;
				}
			}
		}
		catch
		{
		}
		return KetQuaReg.LamCloneKhac;
	}

	public void ThemThongTinCaNhan(ThongTinTaiKhoan taikhoan)
	{
		ThuVienThongTin thuVienThongTin = new ThuVienThongTin(taikhoan, delegate(string trangthai)
		{
			SetTrangThai(taikhoan.Index, trangthai);
		});
		thuVienThongTin.Lay2FA();
		TamDung();
		thuVienThongTin.AddAvatar();
		thuVienThongTin.ThemGioiThieu();
		if (cauhinh.KetBan && taikhoan.CoBanBe)
		{
			ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
			ThuVienAndroidAnh.ChuyenHuong(taikhoan.MaMay, "fb://home", "com.facebook.katana");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 2.0);
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				thuVienAndroidChu.ScanScreen();
				if (thuVienAndroidChu.KiemTraChu("content-desc", "xem tất cả", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("xem tất cả", click: true, 1);
					flag = true;
				}
				else if (thuVienAndroidChu.KiemTraChu("content-desc", "xem tất cả gợi ý kết bạn", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("xem tất cả gợi ý kết bạn", click: true, 1);
					flag = true;
				}
				else
				{
					ThuVienAndroidAnh.Vuot(taikhoan.MaMay, 715, 2130, 715, 1500, 150);
				}
				if (flag && thuVienAndroidChu.KiemTraChu("content-desc", "thêm bạn bè", 1))
				{
					break;
				}
			}
			int soLuongBanBe = cauhinh.SoLuongBanBe;
			int num = 0;
			bool flag2 = false;
			for (int j = 0; j < cauhinh.SoLuongBanBe + 30; j++)
			{
				SetTrangThai(taikhoan.Index, $"Kết bạn: {num + 1}/{soLuongBanBe}");
				thuVienAndroidChu.ScanScreen();
				if (thuVienAndroidChu.KiemTraChu("content-desc", "tapping close removes this promotion from the screen.", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("tapping close removes this promotion from the screen.", click: true, 1);
					continue;
				}
				if (thuVienAndroidChu.KiemTraChu("content-desc", "thêm bạn bè", 1))
				{
					thuVienAndroidChu.TimKiemTheoContentDesc("thêm bạn bè", click: true, 1);
					num++;
				}
				if (thuVienAndroidChu.ChuaChu("người này có biết bạn không", "chỉ gửi lời mời kết bạn cho những người bạn quen biết"))
				{
					thuVienAndroidChu.TimKiemTheoText("xác nhận", click: true, 1);
					continue;
				}
				string input = thuVienAndroidChu.ToString();
				Match match = Regex.Match(input, "content-desc=\"thêm (.*?) làm bạn bè\".*bounds=\"\\[(\\d+),(\\d+)\\]\\[(\\d+),(\\d+)\\]\" />");
				if (match.Success)
				{
					List<int> bounds = new List<int>
					{
						Convert.ToInt32(match.Groups[2].Value),
						Convert.ToInt32(match.Groups[3].Value),
						Convert.ToInt32(match.Groups[4].Value),
						Convert.ToInt32(match.Groups[5].Value)
					};
					thuVienAndroidChu.Click(bounds);
					num++;
				}
				if (thuVienAndroidChu.ChuaChu("không gửi được lời mời", "có vẻ như bạn không biết người này"))
				{
					thuVienAndroidChu.TimKiemTheoText("ok", click: true, 1);
					ThuVienAndroidAnh.Vuot(taikhoan.MaMay, 715, 2130, 715, 1850, 150);
				}
				else if (num >= cauhinh.SoLuongBanBe)
				{
					break;
				}
			}
		}
		if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
		{
			SetTrangThai(taikhoan.Index, "1000 - Oẳng chó");
			_die++;
			taikhoan.TrangThai = TrangThaiClone.Die;
			return;
		}
		if (taikhoan.TaiKhoanGmail != null)
		{
			taikhoan.TaiKhoanGmail.SoLuong++;
		}
		ThongTinTaiKhoan thongTinTaiKhoan = ThuVienAndroidAnh.LayCookieToken(taikhoan.MaMay);
		taikhoan.Token = thongTinTaiKhoan.Token;
		taikhoan.Cookie = thongTinTaiKhoan.Cookie;
		taikhoan.TrangThai = TrangThaiClone.Live;
		SetTrangThai(taikhoan.Index, "Lưu Data Thành Công");
		string tenFile = TaoFileLuuClone(taikhoan);
		string text = taikhoan.ToString();
		if (cauhinh.HotmailBox || cauhinh.DongVanFb)
		{
			text = text + "|" + taikhoan.Email;
		}
		AddData(taikhoan);
		ThuVienAndroidAnh.GhiFile(tenFile, text, "data\\clone");
		SetTrangThai(taikhoan.Index, "Tắt app FB");
		ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.facebook.katana");
		ThuVienAndroidAnh.RemoveAppExternalData(taikhoan.MaMay, "com.facebook.katana");
		_live++;
		SetTrangThai(taikhoan.Index, "Húp + 1");
		SetResult();
	}

	public void WaitLoading(ThongTinTaiKhoan taikhoan)
	{
		ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
		Thread.Sleep(500);
		int num = 0;
		while (true)
		{
			thuVienAndroidChu.ScanScreen();
			if (!thuVienAndroidChu.Xml.Contains("android.widget.progressbar") || num >= 30)
			{
				break;
			}
			SetTrangThai(taikhoan.Index, "Loading...");
			Thread.Sleep(1000);
			num++;
		}
	}

	public string TaoFileLuuClone(ThongTinTaiKhoan taiKhoan)
	{
		string text = "CloneVeriMail_";
		if (cauhinh.HotmailBox || cauhinh.DongVanFb)
		{
			text = "CloneVeriHotMail_";
		}
		if (cauhinh.UploadAvatar || cauhinh.UploadAnhBia)
		{
			text += "CoAnh_";
		}
		if (taiKhoan.CoBanBe)
		{
			text += "CoBanBe_";
		}
		if (!cauhinh.RandomMatKhau)
		{
			text += "ChungPass_";
		}
		return $"{text}{DateTime.Now:ddMMyyyy}.txt";
	}

	public void themmail_khongxacminh(ThongTinTaiKhoan taikhoan)
	{
		bool flag = false;
		ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
		string xml = thuVienAndroidChu.Xml;
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
		string text = "taogmail_ao" + ThuVienAndroidAnh.Random(11111, 55555) + "@gmail.com";
		ThuVienAndroidAnh.ChuyenHuong(taikhoan.MaMay, "fb://facewebmodal/f?href=https://mbasic.facebook.com/settings/email/add", "com.facebook.katana");
		thuVienAndroidChu.ScanScreen();
		if (thuVienAndroidChu.KiemTraChu("resource-id", "m-settings-form", 1))
		{
			thuVienAndroidChu.ScanScreen();
			thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
			ThuVienAndroidAnh.DienChu(taikhoan.MaMay, text);
			thuVienAndroidChu.TimKiemNhieuLop(true, 5, "resource-id=password_verifier_div", "index=1", "class=android.widget.edittext");
			ThuVienAndroidAnh.DienChu(taikhoan.MaMay, text);
			thuVienAndroidChu.ScanScreen();
		}
	}

	public void XoaTaiKhoan_GmailDie(ThongTinTaiKhoan taikhoan)
	{
		bool flag = false;
		ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
		SetTrangThai(taikhoan.Index, "Tắt Cài Đặt");
		ThuVienAndroidAnh.VaoPhanTaiKhoan(taikhoan.MaMay);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
		thuVienAndroidChu.ScanScreen();
		SetTrangThai(taikhoan.Index, "Kiểm tra tài khoản GG");
		if (!thuVienAndroidChu.KiemTraChu("text", "google", 2))
		{
			SetTrangThai(taikhoan.Index, "Chưa có tài khoản nào");
			return;
		}
		SetTrangThai(taikhoan.Index, "Chọn tài khoản GG");
		thuVienAndroidChu.TimKiemTheoText("google", click: true, 5);
		thuVienAndroidChu.ScanScreen();
		SetTrangThai(taikhoan.Index, "Xoá tài khoản");
		thuVienAndroidChu.TimKiemTheoResourceId("com.android.settings:id/button", click: true, 5);
		thuVienAndroidChu.ScanScreen();
		SetTrangThai(taikhoan.Index, "Xác nhận xoá tài khoản");
		thuVienAndroidChu.TimKiemTheoResourceId("android:id/button1", click: true, 5);
	}

	public void VeriFacebookGmail(ThongTinTaiKhoan taikhoan)
	{
		StopWatchHelper stopWatchHelper = StopWatchHelper.Instance();
		CheckDieAccModel checkDieAccModel = new CheckDieAccModel
		{
			MaMay = taikhoan.MaMay
		};
		_danhsachthietbi.Add(checkDieAccModel);
		while (true)
		{
			ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.facebook.katana");
			ThuVienAndroidAnh.RemoveAppExternalData(taikhoan.MaMay, "com.facebook.katana");
			if (_dung)
			{
				break;
			}
			stopWatchHelper.Start();
			bool flag = true;
			if (taikhoan.LayLaiClone)
			{
				AddData(taikhoan, taikhoan.LayLaiClone);
			}
			DoiProxy(taikhoan);
			TamDung();
			KetQuaReg ketQuaReg;
			do
			{
				ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.facebook.katana");
				ThuVienAndroidAnh.RemoveAppExternalData(taikhoan.MaMay, "com.facebook.katana");
				if (!flag)
				{
					stopWatchHelper.Start();
				}
				LoadConfig();
				AddData(taikhoan, !flag);
				SetResult();
				TamDung();
				ketQuaReg = Dangnhap_Facebook(taikhoan);
				int totalSeconds = stopWatchHelper.TotalSeconds;
				int num = totalSeconds / 60;
				int num2 = totalSeconds % 60;
				taikhoan.TongThoiGian = $"{num}p{num2}s";
				AddData(taikhoan);
				SetResult();
				flag = !taikhoan.LayLaiClone;
				if (taikhoan.TrangThai == TrangThaiClone.Die)
				{
					checkDieAccModel.SoAccDie++;
					checkDieAccModel.TongAccDie++;
				}
				if (taikhoan.TrangThai == TrangThaiClone.Live)
				{
					checkDieAccModel.SoAccDie = 0;
					checkDieAccModel.TongAccLive++;
				}
			}
			while (ketQuaReg != 0);
			if (taikhoan.LayLaiClone)
			{
				taikhoan.Index++;
			}
		}
	}

	public void RegFacebookBangGmail(ThongTinTaiKhoan taikhoan)
	{
		ThuVienThongTin thuVienThongTin = new ThuVienThongTin(taikhoan, delegate(string trangthai)
		{
			SetTrangThai(taikhoan.Index, trangthai);
		});
		bool flag = false;
		ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
		ThuVienAndroidAnh.InitADBKeyBoard(taikhoan.MaMay);
		ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.facebook.katana");
		ThuVienAndroidAnh.RemoveAppExternalData(taikhoan.MaMay, "com.facebook.katana");
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
		SetTrangThai(taikhoan.Index, "Cấp Quyền Facebook");
		capquyenFB(taikhoan);
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
		ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.facebook.katana");
		for (int i = 0; i < 20; i++)
		{
			thuVienAndroidChu.ScanScreen();
			SetTrangThai(taikhoan.Index, "tạo tài khoản facebook mới");
			if (thuVienAndroidChu.KiemTraChu("content-desc", "tạo tài khoản facebook mới", 1))
			{
				break;
			}
		}
	}

	public string Thaymail_trongcaidat(ThongTinTaiKhoan taikhoan)
	{
		string text = string.Empty;
		OtpConfirmationApi otpConfirmationApi = OtpConfirmationApi.KhoiTao();
		if (cauhinh.TempMail)
		{
			string[] array = File.ReadAllLines("Data/proxy_get_mail.txt");
			if (array != null && array.Length != 0)
			{
				int num = taikhoan.DeviceIndex / 8;
				string proxy = array[num];
				otpConfirmationApi.ThemProxy(proxy);
			}
		}
		otpConfirmationApi.InitStatus(delegate(string trangthai)
		{
			SetTrangThai(taikhoan.Index, trangthai);
		});
		bool flag = false;
		ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
		string xml = thuVienAndroidChu.Xml;
		bool flag2 = false;
		while (true)
		{
			if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
			{
				return "die";
			}
			if (taikhoan.DaXacNhan)
			{
				break;
			}
			SetTrangThai(taikhoan.Index, "Vào Thêm Mail Mới");
			ThuVienAndroidAnh.ChuyenHuong(taikhoan.MaMay, "fb://facewebmodal/f?href=https://m.facebook.com/settings/email/add", "com.facebook.katana");
			WaitLoading(taikhoan);
			SetTrangThai(taikhoan.Index, "Kiểm tra vào trang thêm mail");
			for (int i = 0; i < 50; i++)
			{
				TamDung();
				thuVienAndroidChu.ScanScreen();
				flag = thuVienAndroidChu.ChuaChu("vui lòng cập nhật số điện thoại", "cập nhật số di động", "chúng tôi đã gửi sms", "tôi ko nhận được mã");
				CheckCookie(thuVienAndroidChu);
				if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
				{
					return "die";
				}
				if (flag)
				{
					return "doigmail";
				}
				if (thuVienAndroidChu.ChuaChu("cập nhật email của bạn"))
				{
					return "lamlai";
				}
				if (thuVienAndroidChu.KiemTraChu("text", "thêm email", 1))
				{
					break;
				}
				ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			}
			for (int j = 0; j < 25; j++)
			{
				if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
				{
					return "die";
				}
				TamDung();
				thuVienAndroidChu.ScanScreen();
				SetTrangThai(taikhoan.Index, "Chex Thêm Mail");
				if (!thuVienAndroidChu.KiemTraChu("text", "thêm email", 1))
				{
					continue;
				}
				flag2 = true;
				for (int k = 0; k < 100; k++)
				{
					text = otpConfirmationApi.LayPhoneOrMail();
					if (!string.IsNullOrEmpty(text))
					{
						break;
					}
				}
				CheckCookie(thuVienAndroidChu);
				taikhoan.Email = otpConfirmationApi.Email;
				do
				{
					if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
					{
						return "die";
					}
					SetTrangThai(taikhoan.Index, "Điền mail: " + text.Split('|')[0]);
					thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
					TamDung();
					SetTrangThai(taikhoan.Index, text);
					ThuVienAndroidAnh.DienChu(taikhoan.MaMay, text.Split('|')[0]);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_ENTER);
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
					WaitLoading(taikhoan);
					thuVienAndroidChu.ScanScreen();
				}
				while (thuVienAndroidChu.ChuaChu("vui lòng nhập địa chỉ email hợp lệ"));
				SetTrangThai(taikhoan.Index, "Tìm xác nhận địa chỉ mail");
				if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
				{
					return "die";
				}
				TamDung();
				bool flag3 = true;
				bool flag4 = true;
				bool flag8;
				while (true)
				{
					IL_04c6:
					ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
					ThuVienAndroidAnh.ChuyenHuong(taikhoan.MaMay, "fb://facewebmodal/f?href=https://mbasic.facebook.com/entercode.php?cp=" + text.Split('|')[0] + "&source_verified=m_settings", "com.facebook.katana");
					WaitLoading(taikhoan);
					SetTrangThai(taikhoan.Index, "Click gửi lại email xác nhận");
					thuVienAndroidChu.ScanScreen();
					CheckCookie(thuVienAndroidChu);
					thuVienAndroidChu.TimKiemTheoText("gửi lại email xác nhận", click: true, 5);
					CheckCookie(thuVienAndroidChu, delegate
					{
						thuVienAndroidChu.TimKiemTheoText("gửi lại email xác nhận", click: true, 2);
					});
					SetTrangThai(taikhoan.Index, "Xác Minh Mail  ");
					if (thuVienAndroidChu.ChuaChu("gửi lại email xác nhận", "nhập mã hoặc nhấp vào liên kết được gửi"))
					{
						string text2 = string.Empty;
						for (int l = 0; l < 3; l++)
						{
							TamDung();
							thuVienAndroidChu.ScanScreen();
							CheckCookie(thuVienAndroidChu, delegate
							{
								thuVienAndroidChu.TimKiemTheoText("gửi lại email xác nhận", click: true, 2);
							});
							SetTrangThai(taikhoan.Index, $"Lấy mã xác nhận lần: {l + 1}");
							text2 = otpConfirmationApi.LayMaXacNhan();
							if (!ThuVienAndroidAnh.CheckLiveUID(taikhoan.UID))
							{
								return "die";
							}
							if (!string.IsNullOrEmpty(text2))
							{
								break;
							}
						}
						if (string.IsNullOrEmpty(text2))
						{
							break;
						}
						TamDung();
						int num2 = 0;
						while (true)
						{
							SetTrangThai(taikhoan.Index, "Nhập mã xác nhận: " + text2);
							thuVienAndroidChu.ScanScreen();
							CheckCookie(thuVienAndroidChu);
							thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
							ThuVienAndroidAnh.DienChu(taikhoan.MaMay, text2);
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
							ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_ENTER);
							TamDung();
							SetTrangThai(taikhoan.Index, "Đợi xác nhận");
							WaitLoading(taikhoan);
							ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
							int num3 = 0;
							while (num3 < 20 && num2 < 3)
							{
								TamDung();
								thuVienAndroidChu.ScanScreen();
								CheckCookie(thuVienAndroidChu);
								if (thuVienAndroidChu.Xml.Contains("mã xác nhận không hợp lệ"))
								{
									goto IL_084f;
								}
								CheckCookie(thuVienAndroidChu);
								if (thuVienAndroidChu.ChuaChu("m_newsfeed_stream", "mfirstbatch", "tìm bạn bè", "tìm kiếm bạn bè"))
								{
									break;
								}
								num3++;
							}
							break;
							IL_084f:
							num2++;
						}
					}
					bool flag5 = true;
					bool flag6 = true;
					while (true)
					{
						IL_0869:
						SetTrangThai(taikhoan.Index, "Vào gỡ mail");
						ThuVienAndroidAnh.ChuyenHuong(taikhoan.MaMay, "fb://facewebmodal/f?href=https%3A//m.facebook.com/settings/email", "com.facebook.katana");
						ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
						bool flag7 = false;
						for (int m = 0; m < 5; m++)
						{
							TamDung();
							thuVienAndroidChu.ScanScreen();
							CheckCookie(thuVienAndroidChu);
							if (!thuVienAndroidChu.Xml.Contains("email hiện tại") && !thuVienAndroidChu.Xml.Contains("email đang chờ xử lý"))
							{
								continue;
							}
							if (thuVienAndroidChu.ChuaChu("xác nhận địa chỉ email") && !(flag7 = thuVienAndroidChu.ChuaChu("index=\"12\" text=\"xóa, gỡ\"")))
							{
								goto IL_04c6;
							}
							SetTrangThai(taikhoan.Index, "Bấm gỡ mail");
							for (int n = 6; n < 15; n++)
							{
								TamDung();
								if (thuVienAndroidChu.KiemTraTonTai("index=\"" + n + "\" text=\"xóa, gỡ\""))
								{
									thuVienAndroidChu.TimKiemTheoXPath($"//node[@index='{n}'][@text='xóa, gỡ']", isClick: true, 1);
									break;
								}
								if (thuVienAndroidChu.KiemTraTonTai("content-desc=\"xóa, gỡ\""))
								{
									thuVienAndroidChu.TimKiemTheoXPath("//node[@content-desc='xóa, gỡ']", isClick: true, 1);
									break;
								}
							}
							SetTrangThai(taikhoan.Index, "Đợi vào trang gỡ mail");
							WaitLoading(taikhoan);
							for (int num4 = 0; num4 < 20; num4++)
							{
								TamDung();
								thuVienAndroidChu.ScanScreen();
								CheckCookie(thuVienAndroidChu);
								if (thuVienAndroidChu.Xml.Contains("gỡ email") || thuVienAndroidChu.Xml.Contains("bạn có chắc chắn muốn"))
								{
									break;
								}
								ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
							}
							if (thuVienAndroidChu.KiemTraChu("resource-id", "password_verifier_div", 1))
							{
								SetTrangThai(taikhoan.Index, "Nhập mật khẩu");
								thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 5);
								ThuVienAndroidAnh.DienChuCham(taikhoan.MaMay, taikhoan.MatKhauCu);
							}
							SetTrangThai(taikhoan.Index, "Bấm gỡ mail 2");
							thuVienAndroidChu.ScanScreen();
							CheckCookie(thuVienAndroidChu);
							thuVienAndroidChu.TimKiemTheoClass("android.widget.button", click: true, 2);
							WaitLoading(taikhoan);
							SetTrangThai(taikhoan.Index, "Kiểm tra gỡ mail");
							flag8 = false;
							int num5 = 0;
							while (num5 < 20)
							{
								TamDung();
								thuVienAndroidChu.ScanScreen();
								CheckCookie(thuVienAndroidChu);
								if (thuVienAndroidChu.ChuaChu("xác nhận địa chỉ email") && !flag7)
								{
									goto IL_04c6;
								}
								bool flag9 = num5 >= 10 && !thuVienAndroidChu.Xml.Contains(taikhoan.Gmail.Split('|')[0].ToLower());
								flag = thuVienAndroidChu.Xml.Contains(taikhoan.Email.Split('|')[0].ToLower()) && (thuVienAndroidChu.Xml.Contains("đã lưu thay đổi") || !thuVienAndroidChu.Xml.Contains(taikhoan.Gmail.Split('|')[0].ToLower()));
								if (!(flag || flag9))
								{
									Thread.Sleep(1000);
									num5++;
									continue;
								}
								goto IL_0d30;
							}
							if (!flag8)
							{
								goto IL_0869;
							}
						}
						break;
					}
					goto IL_0d39;
				}
				goto IL_0d50;
				IL_0d30:
				flag8 = true;
				break;
				IL_0d39:;
			}
			break;
			IL_0d50:
			SetTrangThai(taikhoan.Index, "Không về mã, cho làm lại");
		}
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
		SetTrangThai(taikhoan.Index, "Vào trang đổi mật khẩu");
		ThuVienAndroidAnh.ChuyenHuong(taikhoan.MaMay, "fb://facewebmodal/f?href=https://m.facebook.com/settings/security/password", "com.facebook.katana");
		WaitLoading(taikhoan);
		thuVienAndroidChu.ScanScreen();
		TamDung();
		CheckCookie(thuVienAndroidChu);
		SetTrangThai(taikhoan.Index, "Tìm ô mật khẩu");
		if (thuVienAndroidChu.KiemTraChu("resource-id", "forgot-password-link", 5))
		{
			SetTrangThai(taikhoan.Index, "Nhập mật khẩu cũ");
			thuVienAndroidChu.TimKiemTheoClass("android.widget.edittext", click: true, 1);
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.MatKhauCu);
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_TAB);
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			string matKhau = ThuVienAndroidAnh.TaoMatKhau(13);
			if (!cauhinh.RandomMatKhau)
			{
				matKhau = cauhinh.MatKhau;
			}
			taikhoan.MatKhau = matKhau;
			TamDung();
			SetTrangThai(taikhoan.Index, "Điền mật khẩu mới: " + taikhoan.MatKhau);
			ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.MatKhau);
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_TAB);
			SetTrangThai(taikhoan.Index, "Nhập lại mật khẩu mới");
			ThuVienAndroidAnh.DienChu(taikhoan.MaMay, taikhoan.MatKhau);
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			SetTrangThai(taikhoan.Index, "Đổi mật khẩu");
			ADBHelper.Key(taikhoan.MaMay, ADBKeyEvent.KEYCODE_ENTER);
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.0);
			WaitLoading(taikhoan);
			TamDung();
			CheckCookie(thuVienAndroidChu);
			thuVienAndroidChu.ScanScreen();
			SetTrangThai(taikhoan.Index, "Click kiểm tra thiết bị khác");
			thuVienAndroidChu.TimKiemTheoText("kiểm tra thiết bị khác", click: true, 5);
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			thuVienAndroidChu.TimKiemTheoClass("android.widget.button", click: true, 1);
			SetTrangThai(taikhoan.Index, "Chọn dăng xuất tất cả");
			WaitLoading(taikhoan);
			thuVienAndroidChu.TimKiemTheoText("đăng xuất khỏi tất cả", click: true, 5);
			SetTrangThai(taikhoan.Index, "Đợi màn đăng xuất");
			for (int num6 = 0; num6 < 5; num6++)
			{
				TamDung();
				thuVienAndroidChu.ScanScreen();
				CheckCookie(thuVienAndroidChu);
				if (thuVienAndroidChu.Xml.Contains("hành động này sẽ đăng xuất bạn khỏi"))
				{
					break;
				}
				ThuVienAndroidAnh.Doi(taikhoan.MaMay, 0.5);
			}
			SetTrangThai(taikhoan.Index, "Đăng xuất tất cả");
			thuVienAndroidChu.TimKiemTheoClass("android.widget.button", click: true, 5);
			return "live";
		}
		if (!flag2)
		{
			return "lamlai";
		}
		return "live";
	}

	public void CheckCookie(ThuVienAndroidChu thuVienAndroidChu, Action action = null, bool isScan = false)
	{
		if (isScan)
		{
			thuVienAndroidChu.ScanScreen();
		}
		if (thuVienAndroidChu.KiemTraChu("content-desc", "cho phép tất cả cookie", 1))
		{
			thuVienAndroidChu.TimKiemTheoContentDesc("cho phép tất cả cookie", click: true, 1);
			if (action != null)
			{
				ThuVienAndroidAnh.Doi(thuVienAndroidChu.DeviceId, 0.5);
				action();
			}
			ThuVienAndroidAnh.Doi(thuVienAndroidChu.DeviceId, 0.5);
		}
		if (thuVienAndroidChu.ChuaChu("cho phép facebook truy cập vị trí của bạn") || (thuVienAndroidChu.ChuaChu("từ chối") && thuVienAndroidChu.ChuaChu("cho phép")))
		{
			ThuVienAndroidAnh.Doi(thuVienAndroidChu.DeviceId, 1.0);
			thuVienAndroidChu.ScanScreen();
			thuVienAndroidChu.TimKiemTheoContentDesc("từ chối", click: true, 3);
		}
	}

	private void DoiProxy(ThongTinTaiKhoan taikhoan)
	{
		ThuVienAndroidAnh.XoaProxy(taikhoan.MaMay);
		if (cauhinh.BonG)
		{
			ThuVienVPN.ChangeIP_4G(taikhoan.MaMay);
		}
		if (cauhinh.VpnKiwi)
		{
			ThuVienVPN.ChangeIP_VPNKIWI(taikhoan.MaMay);
		}
		if (cauhinh.Warp)
		{
			ThuVienVPN.VPN1111(taikhoan);
		}
		if (cauhinh.Pia)
		{
			ThuVienVPN.VPNPia(taikhoan);
		}
	}

	public TaiKhoanGmail LayGmail(int index)
	{
		string text = "";
		MailApi mailApi = MailApi.KhoiTao();
		mailApi.InitStatus(delegate(string trangthai)
		{
			SetTrangThai(index, trangthai);
		});
		for (int i = 0; i < 10; i++)
		{
			text = mailApi.LayMail();
			if (!string.IsNullOrEmpty(text) && text.Contains("@gmail.com"))
			{
				ThuVienAndroidAnh.GhiFile($"GmailDaMua_{DateTime.Now: ddMMyyyy}.txt", text ?? "");
				break;
			}
			Thread.Sleep(1000);
		}
		if (!text.Contains("@gmail.com"))
		{
			SetTrangThai(index, "Không lấy được Gmail");
			return new TaiKhoanGmail();
		}
		int count = _listGmail.Count;
		TaiKhoanGmail taiKhoanGmail = new TaiKhoanGmail
		{
			Gmail = text,
			SoLuong = 0,
			Index = count
		};
		_listGmail.Add(taiKhoanGmail);
		_tongtiengmail += 200;
		SetTotal();
		return taiKhoanGmail;
	}

	public void TatAllAppVPN(string mamay)
	{
		ThuVienAndroidAnh.TatApp(mamay, "secure.unblock.unlimited.proxy.snap.hotspot.shield");
		ThuVienAndroidAnh.TatApp(mamay, "com.hidemyass.hidemyassprovpn");
		ThuVienAndroidAnh.TatApp(mamay, "com.free.vpn.super.hotspot.open");
	}

	private void XoaData()
	{
		ExecuteCommand("adb shell input keyevent 123");
		ExecuteCommand("adb shell input keyevent 29");
		ExecuteCommand("adb shell input keyevent 122");
		Thread.Sleep(1000);
		ExecuteCommand("adb shell input keyevent KEYCODE_DEL");
		Thread.Sleep(1000);
	}

	public void ProxyIPPORT(ThongTinTaiKhoan taikhoan)
	{
		List<string> list = File.ReadAllLines("proxy.txt").ToList();
		string text = list[0];
		list.RemoveAt(0);
		File.WriteAllLines("proxy.txt", list);
		bool flag = false;
		ThuVienAndroidChu thuVienAndroidChu = new ThuVienAndroidChu(taikhoan.MaMay, StringExtension.TaoMatKhau(13));
		ThuVienAndroidAnh.InitADBKeyBoard(taikhoan.MaMay);
		SetTrangThai(taikhoan.Index, "Dừng app Proxy");
		ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.cell47.College_Proxy");
		ThuVienAndroidAnh.CapFullQuyen(taikhoan.MaMay, "com.cell47.College_Proxy");
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 1.5);
		SetTrangThai(taikhoan.Index, "Proxy");
		ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.cell47.College_Proxy");
		ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
		int num = 0;
		if (num < 50)
		{
			ThuVienAndroidAnh.MoApp(taikhoan.MaMay, "com.cell47.College_Proxy");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 5.0);
			ExecuteCommand("adb shell input tap 893 1026");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input tap 723 988");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input text \"" + text.Split(':')[0] + "\"");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input tap 774 1111");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input text \"" + text.Split(':')[1] + "\"");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input tap 679 1230");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input text \"" + text.Split(':')[2] + "\"");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input tap 597 1355");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input text \"" + text.Split(':')[3] + "\"");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input tap 519 1464");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input tap 808 1141");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
			ExecuteCommand("adb shell input tap 711 1070");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 7.0);
			ExecuteCommand("adb shell input tap 711 1070");
			ThuVienAndroidAnh.Doi(taikhoan.MaMay, 3.0);
		}
	}

	private void batdau1_Click(object sender, EventArgs e)
	{
		ThuVienVPN.SetAction(SetTrangThai);
		_timer.Enabled = true;
		LoadConfig();
		lblTrangThai.Text = "Tool đang chạy...";
		List<string> devices = ADBHelper.GetDevices().Take(cauhinh.SoLuong).ToList();
		if (!cauhinh.RandomMatKhau && string.IsNullOrEmpty(cauhinh.MatKhau))
		{
			MessageBox.Show("Chưa nhập mật khẩu Reg", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		_dung = false;
		_tamdung = false;
		batdau1.Enabled = false;
		KillAdb();
		for (int i = 0; i < devices.Count; i++)
		{
			Thread.Sleep(ThuVienAndroidAnh.Random(100, 200));
			int index = i;
			Thread thread = new Thread((ThreadStart)delegate
			{
				ThuVienAndroidAnh.UnlockScreen(devices[index]);
				while (true)
				{
					string[] array = ThuVienAndroidAnh.DocFile("dauso_DienThoai.txt");
					string text = array[ThuVienAndroidAnh.Random(0, array.Length - 1)];
					string soDienThoai = text + ThuVienAndroidAnh.Random(1111111, 9999999);
					string matKhau = ThuVienAndroidAnh.TaoMatKhau(13);
					string text2 = "taogmail_ao" + ThuVienAndroidAnh.Random(1111111, 9999999) + "@gmail.com";
					ThongTinTaiKhoan taikhoan = new ThongTinTaiKhoan
					{
						Index = dataGridView1.Rows.Count - 1,
						MaMay = devices[index],
						DeviceIndex = index,
						Ho = ThuVienAndroidAnh.Ho,
						Ten = ThuVienAndroidAnh.Ten,
						SoDienThoai = soDienThoai,
						MatKhau = matKhau,
						LayLaiClone = true
					};
					ThuVienThongTin thuVienThongTin = new ThuVienThongTin(taikhoan, delegate(string trangthai)
					{
						SetTrangThai(taikhoan.Index, trangthai);
					});
					thuVienThongTin.Dongbodanhba(taikhoan);
					if (cauhinh.RegNVR)
					{
						AddData(taikhoan, isAdd: true);
					}
					if (_dung)
					{
						break;
					}
					TatAllAppVPN(taikhoan.MaMay);
					if (cauhinh.ChangeThietBi && !cauhinh.TutVeriGmail)
					{
						ThuVienVPN.Change_thietBi(taikhoan);
					}
					if (!cauhinh.TutVeriGmail)
					{
						DoiProxy(taikhoan);
					}
					if (cauhinh.TutVeriGmail)
					{
						VeriFacebookGmail(taikhoan);
					}
					if (cauhinh.RegNVR)
					{
						if (cauhinh.ProxyIPPORT)
						{
							ProxyIPPORT(taikhoan);
						}
						RegNVR_BanMoi(taikhoan);
						if (taikhoan.DaXacNhan && taikhoan.TrangThai == TrangThaiClone.Die)
						{
							ThongTinTaiKhoan thongTinTaiKhoan = ThuVienAndroidAnh.LayCookieToken(taikhoan.MaMay);
							taikhoan.Token = thongTinTaiKhoan.Token;
							taikhoan.Cookie = thongTinTaiKhoan.Cookie;
							string tenFile = $"CloneDie282_VRP_{DateTime.Now:ddMMyyyy}.txt";
							string data = taikhoan.UID + "|" + taikhoan.MatKhau + "|" + taikhoan.HaiFA.Replace(" ", "").ToUpper() + "|" + thongTinTaiKhoan.Cookie + "|" + thongTinTaiKhoan.Token;
							ThuVienAndroidAnh.GhiFile(tenFile, data, "data\\clone");
						}
						if (!taikhoan.DaXacNhan && taikhoan.TrangThai == TrangThaiClone.Live)
						{
							string tenFile2 = $"CloneLive_NVR_{DateTime.Now:ddMMyyyy}.txt";
							string data2 = taikhoan.SoDienThoai + "|" + taikhoan.MatKhau;
							ThuVienAndroidAnh.GhiFile(tenFile2, data2, "data\\clone");
						}
					}
					ThuVienAndroidAnh.XoaDataApp(taikhoan.MaMay, "com.facebook.katana");
					ThuVienAndroidAnh.RemoveAppExternalData(taikhoan.MaMay, "com.facebook.katana");
				}
			});
			thread.IsBackground = true;
			thread.Start();
		}
	}

	private void Clear(string cmd)
	{
		Process process = new Process();
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		processStartInfo.FileName = "cmd.exe";
		processStartInfo.Arguments = "/c " + cmd;
		processStartInfo.Verb = "runas";
		process.StartInfo = processStartInfo;
		process.Start();
	}

	public static string ExecuteCommand(string command)
	{
		try
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + command;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			string result = process.StandardOutput.ReadToEnd();
			string text = process.StandardError.ReadToEnd();
			process.WaitForExit();
			if (!string.IsNullOrEmpty(text))
			{
				return "Error: " + text;
			}
			return result;
		}
		catch (Exception ex)
		{
			return "Exception: " + ex.Message;
		}
	}

	public void AddData(ThongTinTaiKhoan taikhoan, bool isAdd = false, int status = 0)
	{
		InvokeMethod(delegate
		{
			ThongTinTaiKhoan thongTinTaiKhoan = taikhoan.Copy();
			if (isAdd)
			{
				dataGridView1.Rows.Add();
				thongTinTaiKhoan.Index = dataGridView1.Rows.Count - 2;
				thongTinTaiKhoan.UID = string.Empty;
				thongTinTaiKhoan.MatKhau = string.Empty;
				thongTinTaiKhoan.HaiFA = string.Empty;
				thongTinTaiKhoan.Cookie = string.Empty;
				thongTinTaiKhoan.Token = string.Empty;
				thongTinTaiKhoan.Ho = ThuVienAndroidAnh.Ho;
				thongTinTaiKhoan.Ten = ThuVienAndroidAnh.Ten;
				thongTinTaiKhoan.TrangThai = TrangThaiClone.Unknow;
				taikhoan.UID = string.Empty;
				taikhoan.MatKhau = string.Empty;
				taikhoan.Index = thongTinTaiKhoan.Index;
				taikhoan.HaiFA = string.Empty;
				taikhoan.Cookie = string.Empty;
				taikhoan.Token = string.Empty;
				taikhoan.Ho = ThuVienAndroidAnh.Ho;
				taikhoan.Ten = ThuVienAndroidAnh.Ten;
				taikhoan.TrangThai = TrangThaiClone.Unknow;
			}
			try
			{
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["TenMay"].Value = "NTD " + thongTinTaiKhoan.MaMay.Substring(thongTinTaiKhoan.MaMay.Length - 5, 5);
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["UID"].Value = thongTinTaiKhoan.UID;
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["MatKhau"].Value = thongTinTaiKhoan.MatKhau;
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["Ten"].Value = thongTinTaiKhoan.Ho + " " + taikhoan.Ten;
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["Email"].Value = thongTinTaiKhoan.SoDienThoai;
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["FA"].Value = thongTinTaiKhoan.HaiFA;
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["Cookie"].Value = thongTinTaiKhoan.Cookie;
				dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["Token"].Value = thongTinTaiKhoan.Token;
				if (thongTinTaiKhoan.TrangThai == TrangThaiClone.Live)
				{
					dataGridView1.Rows[thongTinTaiKhoan.Index].DefaultCellStyle.BackColor = Color.DarkRed;
					dataGridView1.Rows[thongTinTaiKhoan.Index].DefaultCellStyle.ForeColor = Color.White;
					dataGridView1.Rows[thongTinTaiKhoan.Index].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);
					SetTrangThai(thongTinTaiKhoan.Index, "Húp - " + thongTinTaiKhoan.TongThoiGian);
				}
				if (thongTinTaiKhoan.TrangThai == TrangThaiClone.Die)
				{
					dataGridView1.Rows[thongTinTaiKhoan.Index].DefaultCellStyle.BackColor = Color.ForestGreen;
					dataGridView1.Rows[thongTinTaiKhoan.Index].DefaultCellStyle.ForeColor = Color.White;
				}
				if (isAdd)
				{
					dataGridView1.Rows[thongTinTaiKhoan.Index].Cells["TrangThai"].Value = "Bắt đầu";
				}
			}
			catch (Exception)
			{
			}
		});
	}

	public void SetTrangThai(int index, string trangthai)
	{
		dataGridView1.Rows[index].Cells["TrangThai"].Value = trangthai;
	}

	private void nutCauHinh_Click(object sender, EventArgs e)
	{
		FormCauHinh formCauHinh = new FormCauHinh();
		formCauHinh.Show();
	}

	private void InvokeMethod(Action action)
	{
		Invoke(action);
	}

	private void label11_Click(object sender, EventArgs e)
	{
		lblTotalDevice.Text = ADBHelper.GetDevices().Count.ToString() ?? "";
	}

	private void lblTotalDevice_Click(object sender, EventArgs e)
	{
		lblTotalDevice.Text = ADBHelper.GetDevices().Count.ToString() ?? "";
	}

	private void Nutstop_Click(object sender, EventArgs e)
	{
		_tamdung = !_tamdung;
		Nutstop.Text = (_tamdung ? "TIẾP TỤC" : "TẠM DỪNG");
	}

	private void TamDung()
	{
		while (_tamdung)
		{
		}
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void Stop_Click(object sender, EventArgs e)
	{
		_dung = true;
		Stop.Text = "ĐÃ DỪNG";
	}

	private void applite_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void LoadConfig()
	{
		if (File.Exists("cauhinh/cauhinh.json"))
		{
			string value = File.ReadAllText("cauhinh/cauhinh.json");
			if (!string.IsNullOrEmpty(value))
			{
				cauhinh = JsonConvert.DeserializeObject<CauHinhDangKy>(value);
			}
		}
	}

	private void KillAdb()
	{
		StopWatchHelper stopWatch = StopWatchHelper.Instance();
		stopWatch.Start();
		Thread thread = new Thread((ThreadStart)delegate
		{
			while (true)
			{
				InvokeMethod(delegate
				{
					lblTrangThai.Text = stopWatch.TotalMinutes.ToString();
				});
				if (stopWatch.TotalMinutes >= 45)
				{
					_tamdung = true;
					Thread.Sleep(10000);
					Clear("taskkill /f /im adb.exe");
					Thread.Sleep(3000);
					string text = Application.StartupPath + "\\";
					Clear(text + "adb devices");
					Thread.Sleep(3000);
					_tamdung = false;
					stopWatch.Start();
				}
				Thread.Sleep(500);
			}
		})
		{
			IsBackground = true
		};
		thread.Start();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKyFacebook.applite));
		this.batdau1 = new System.Windows.Forms.Button();
		this.Nutstop = new System.Windows.Forms.Button();
		this.panel1 = new System.Windows.Forms.Panel();
		this.nutCauHinh = new System.Windows.Forms.Button();
		this.Stop = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		this.Die = new System.Windows.Forms.Label();
		this.Live = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.panel2 = new System.Windows.Forms.Panel();
		this.label6 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.lblTotalDevice = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.lblTrangThai = new System.Windows.Forms.Label();
		this.ThoiGian = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.TenMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.FA = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Cookie = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.panel3 = new System.Windows.Forms.Panel();
		this.panel4 = new System.Windows.Forms.Panel();
		this.panel6 = new System.Windows.Forms.Panel();
		this.panel1.SuspendLayout();
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		this.panel3.SuspendLayout();
		this.panel4.SuspendLayout();
		this.panel6.SuspendLayout();
		base.SuspendLayout();
		this.batdau1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.batdau1.BackColor = System.Drawing.Color.FromArgb(128, 64, 64);
		this.batdau1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.batdau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.batdau1.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.batdau1.Location = new System.Drawing.Point(1030, 2);
		this.batdau1.Name = "batdau1";
		this.batdau1.Size = new System.Drawing.Size(138, 41);
		this.batdau1.TabIndex = 3;
		this.batdau1.Text = "Bắt đầu";
		this.batdau1.UseVisualStyleBackColor = false;
		this.batdau1.Click += new System.EventHandler(batdau1_Click);
		this.Nutstop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Nutstop.BackColor = System.Drawing.SystemColors.WindowFrame;
		this.Nutstop.Cursor = System.Windows.Forms.Cursors.Hand;
		this.Nutstop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Nutstop.ForeColor = System.Drawing.Color.Cornsilk;
		this.Nutstop.Location = new System.Drawing.Point(730, 2);
		this.Nutstop.Name = "Nutstop";
		this.Nutstop.Size = new System.Drawing.Size(145, 41);
		this.Nutstop.TabIndex = 4;
		this.Nutstop.Text = "Tạm dừng";
		this.Nutstop.UseVisualStyleBackColor = false;
		this.Nutstop.Click += new System.EventHandler(Nutstop_Click);
		this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.panel1.Controls.Add(this.batdau1);
		this.panel1.Controls.Add(this.nutCauHinh);
		this.panel1.Controls.Add(this.Stop);
		this.panel1.Controls.Add(this.Nutstop);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel1.Location = new System.Drawing.Point(0, 0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(1175, 46);
		this.panel1.TabIndex = 16;
		this.nutCauHinh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.nutCauHinh.BackColor = System.Drawing.Color.Blue;
		this.nutCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
		this.nutCauHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.nutCauHinh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
		this.nutCauHinh.Location = new System.Drawing.Point(569, 3);
		this.nutCauHinh.Name = "nutCauHinh";
		this.nutCauHinh.Size = new System.Drawing.Size(155, 38);
		this.nutCauHinh.TabIndex = 20;
		this.nutCauHinh.Text = "Cấu hình";
		this.nutCauHinh.UseVisualStyleBackColor = false;
		this.nutCauHinh.Click += new System.EventHandler(nutCauHinh_Click);
		this.Stop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Stop.BackColor = System.Drawing.Color.Crimson;
		this.Stop.Cursor = System.Windows.Forms.Cursors.Hand;
		this.Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Stop.ForeColor = System.Drawing.Color.Cornsilk;
		this.Stop.Location = new System.Drawing.Point(880, 2);
		this.Stop.Name = "Stop";
		this.Stop.Size = new System.Drawing.Size(145, 41);
		this.Stop.TabIndex = 4;
		this.Stop.Text = "Dừng";
		this.Stop.UseVisualStyleBackColor = false;
		this.Stop.Click += new System.EventHandler(Stop_Click);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(298, 7);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(36, 17);
		this.label4.TabIndex = 22;
		this.label4.Text = "Die:";
		this.Die.AutoSize = true;
		this.Die.Font = new System.Drawing.Font("Constantia", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Die.ForeColor = System.Drawing.Color.Crimson;
		this.Die.Location = new System.Drawing.Point(329, 3);
		this.Die.Name = "Die";
		this.Die.Size = new System.Drawing.Size(45, 19);
		this.Die.TabIndex = 21;
		this.Die.Text = "9999";
		this.Live.AutoSize = true;
		this.Live.Font = new System.Drawing.Font("Constantia", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Live.ForeColor = System.Drawing.Color.Green;
		this.Live.Location = new System.Drawing.Point(408, 3);
		this.Live.Name = "Live";
		this.Live.Size = new System.Drawing.Size(45, 19);
		this.Live.TabIndex = 21;
		this.Live.Text = "9999";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(373, 7);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(40, 17);
		this.label3.TabIndex = 21;
		this.label3.Text = "Live:";
		this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.panel2.Controls.Add(this.label6);
		this.panel2.Controls.Add(this.label4);
		this.panel2.Controls.Add(this.label11);
		this.panel2.Controls.Add(this.Die);
		this.panel2.Controls.Add(this.lblTotalDevice);
		this.panel2.Controls.Add(this.Live);
		this.panel2.Controls.Add(this.label3);
		this.panel2.Controls.Add(this.label1);
		this.panel2.Controls.Add(this.label2);
		this.panel2.Controls.Add(this.lblTrangThai);
		this.panel2.Controls.Add(this.ThoiGian);
		this.panel2.Controls.Add(this.label9);
		this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel2.ForeColor = System.Drawing.Color.Coral;
		this.panel2.Location = new System.Drawing.Point(0, 0);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(1175, 34);
		this.panel2.TabIndex = 17;
		this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.ForeColor = System.Drawing.Color.Black;
		this.label6.Location = new System.Drawing.Point(113, 7);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(46, 17);
		this.label6.TabIndex = 23;
		this.label6.Text = "User :";
		this.label11.AutoSize = true;
		this.label11.BackColor = System.Drawing.Color.Transparent;
		this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
		this.label11.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.ForeColor = System.Drawing.Color.Black;
		this.label11.Location = new System.Drawing.Point(3, 7);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(65, 17);
		this.label11.TabIndex = 2;
		this.label11.Text = "Thiết bị:";
		this.label11.Click += new System.EventHandler(label11_Click);
		this.lblTotalDevice.AutoSize = true;
		this.lblTotalDevice.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblTotalDevice.Font = new System.Drawing.Font("Constantia", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTotalDevice.ForeColor = System.Drawing.Color.Green;
		this.lblTotalDevice.Location = new System.Drawing.Point(65, 4);
		this.lblTotalDevice.Name = "lblTotalDevice";
		this.lblTotalDevice.Size = new System.Drawing.Size(42, 19);
		this.lblTotalDevice.TabIndex = 2;
		this.lblTotalDevice.Text = "1000";
		this.lblTotalDevice.Click += new System.EventHandler(lblTotalDevice_Click);
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Black;
		this.label1.Location = new System.Drawing.Point(156, 7);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(136, 17);
		this.label1.TabIndex = 2;
		this.label1.Text = "CỬU LONG CLONE";
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.Black;
		this.label2.Location = new System.Drawing.Point(773, 7);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(81, 17);
		this.label2.TabIndex = 2;
		this.label2.Text = "Trạng thái:";
		this.lblTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.lblTrangThai.AutoSize = true;
		this.lblTrangThai.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTrangThai.ForeColor = System.Drawing.Color.Green;
		this.lblTrangThai.Location = new System.Drawing.Point(566, 7);
		this.lblTrangThai.Name = "lblTrangThai";
		this.lblTrangThai.Size = new System.Drawing.Size(69, 17);
		this.lblTrangThai.TabIndex = 2;
		this.lblTrangThai.Text = "Chuẩn bị";
		this.ThoiGian.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.ThoiGian.AutoSize = true;
		this.ThoiGian.Font = new System.Drawing.Font("Constantia", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.ThoiGian.ForeColor = System.Drawing.Color.Green;
		this.ThoiGian.Location = new System.Drawing.Point(1099, 5);
		this.ThoiGian.Name = "ThoiGian";
		this.ThoiGian.Size = new System.Drawing.Size(73, 19);
		this.ThoiGian.TabIndex = 22;
		this.ThoiGian.Text = "00:00:00";
		this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Constantia", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.ForeColor = System.Drawing.Color.Black;
		this.label9.Location = new System.Drawing.Point(1027, 7);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(78, 17);
		this.label9.TabIndex = 22;
		this.label9.Text = "Thời gian:";
		this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView1.Columns.AddRange(this.TenMay, this.Ten, this.Email, this.UID, this.MatKhau, this.FA, this.Cookie, this.Token, this.TrangThai);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dataGridView1.EnableHeadersVisualStyles = false;
		this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
		this.dataGridView1.Location = new System.Drawing.Point(0, 0);
		this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.Size = new System.Drawing.Size(1172, 320);
		this.dataGridView1.TabIndex = 21;
		this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
		this.TenMay.HeaderText = "Tên Máy";
		this.TenMay.Name = "TenMay";
		this.Ten.HeaderText = "Ten";
		this.Ten.Name = "Ten";
		this.Email.HeaderText = "Email";
		this.Email.Name = "Email";
		this.Email.Width = 120;
		this.UID.HeaderText = "UID";
		this.UID.Name = "UID";
		this.UID.Width = 120;
		this.MatKhau.HeaderText = "MK";
		this.MatKhau.Name = "MatKhau";
		this.MatKhau.Width = 60;
		this.FA.HeaderText = "2FA";
		this.FA.Name = "FA";
		this.FA.Width = 120;
		this.Cookie.HeaderText = "Cookie";
		this.Cookie.Name = "Cookie";
		this.Token.HeaderText = "Token";
		this.Token.Name = "Token";
		this.TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.TrangThai.HeaderText = "Trạng thái";
		this.TrangThai.Name = "TrangThai";
		this.panel3.Controls.Add(this.panel2);
		this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel3.Location = new System.Drawing.Point(3, 369);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(1175, 34);
		this.panel3.TabIndex = 23;
		this.panel4.Controls.Add(this.panel1);
		this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel4.Location = new System.Drawing.Point(3, 3);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(1175, 46);
		this.panel4.TabIndex = 24;
		this.panel6.Controls.Add(this.dataGridView1);
		this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel6.Location = new System.Drawing.Point(3, 49);
		this.panel6.Name = "panel6";
		this.panel6.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
		this.panel6.Size = new System.Drawing.Size(1175, 320);
		this.panel6.TabIndex = 26;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ButtonFace;
		base.ClientSize = new System.Drawing.Size(1181, 406);
		base.Controls.Add(this.panel6);
		base.Controls.Add(this.panel4);
		base.Controls.Add(this.panel3);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "applite";
		base.Padding = new System.Windows.Forms.Padding(3);
		this.RightToLeft = System.Windows.Forms.RightToLeft.No;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "TOOL REG TÀI KHOẢNG FACEBOOK  CỬU LONG PRO";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(applite_FormClosed);
		base.Load += new System.EventHandler(Form1_Load);
		this.panel1.ResumeLayout(false);
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		this.panel3.ResumeLayout(false);
		this.panel4.ResumeLayout(false);
		this.panel6.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
