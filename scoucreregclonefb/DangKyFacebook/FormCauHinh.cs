using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using ThuVienAndroid.Model;

namespace DangKyFacebook;

public class FormCauHinh : Form
{
	private IContainer components = null;

	private GroupBox groupBox4;

	private CheckBox oXacMinh;

	private RadioButton oregNVR;

	private GroupBox groupBox2;

	private CheckBox Ketban;

	private CheckBox Dangbai;

	private CheckBox TruongHoc;

	private CheckBox Vieclam;

	private CheckBox Thanhpho;

	private CheckBox QueQuan;

	private CheckBox UploadAnhBia;

	private CheckBox UploadAvatar;

	private CheckBox Bat2FA;

	private RadioButton radioButton1;

	private RadioButton owifi;

	private RadioButton o4G;

	private RadioButton vpnkiwi;

	private GroupBox groupBox1;

	private RadioButton oHotmailBox;

	private GroupBox groupBox7;

	private GroupBox groupBox8;

	private GroupBox groupBox9;

	private GroupBox groupBox3;

	private Label lblSoLuong;

	private Label label1;

	private Button btnLuu;

	private Label label2;

	private RadioButton rdoVeriGmail;

	private RadioButton CloneFile;

	private CheckBox oChangethietbi;

	private TextBox ThuMucCover;

	private TextBox ThuMucAvatar;

	private NumericUpDown SoLuong;

	private TextBox DichVuGmailApi;

	private RadioButton oDichVuGmail;

	private TextBox GmailSuperTeamApi;

	private RadioButton oGmailSuper;

	private TextBox HotmailBoxApi;

	private CheckBox oGioiThieu;

	private GroupBox groupBox5;

	private TextBox DongVanFbApi;

	private RadioButton oDongVanFb;

	private TextBox MatKhau;

	private Label label3;

	private CheckBox oMatKhau;

	private RadioButton oTempmail;

	private RadioButton oOneSecMail;

	private RadioButton oGmailSuperXacNhan;

	private CheckBox cboNameUs;

	private RadioButton oDichVuGmailXacNhan;

	private RadioButton radioButton4;

	private RadioButton rdoWarp;

	private RadioButton rdoPia;

	private RadioButton radioButton2;

	private TextBox txtIronSimApi;

	private RadioButton rdoIRonSim;

	private NumericUpDown nmrNumberOfFriend;

	private CheckBox cboAddFriend;

	private TextBox txtHcOtpApi;

	private RadioButton rdoHcOtp;

	private CheckBox cboSoNgoai;

	private TextBox txtSim24Api;

	private CheckBox ckbVeriAccount;

	private RadioButton radioButton3;

	private RadioButton rdo24H;

	public FormCauHinh()
	{
		InitializeComponent();
	}

	private void FormCauHinh_Load(object sender, EventArgs e)
	{
		LoadCauHinh();
	}

	public void LoadCauHinh()
	{
		if (!File.Exists("cauhinh/cauhinh.json"))
		{
			return;
		}
		string value = File.ReadAllText("cauhinh/cauhinh.json");
		if (!string.IsNullOrEmpty(value))
		{
			CauHinhDangKy cauHinhDangKy = JsonConvert.DeserializeObject<CauHinhDangKy>(value);
			if (cauHinhDangKy != null)
			{
				oMatKhau.Checked = cauHinhDangKy.RandomMatKhau;
				MatKhau.Text = cauHinhDangKy.MatKhau;
				MatKhau.Enabled = !cauHinhDangKy.RandomMatKhau;
				cboNameUs.Checked = cauHinhDangKy.NameUs;
				SoLuong.Value = cauHinhDangKy.SoLuong;
				oTempmail.Checked = cauHinhDangKy.TempMail;
				oOneSecMail.Checked = cauHinhDangKy.OneSecMail;
				oGmailSuper.Checked = cauHinhDangKy.GmailSuperTeam;
				oGmailSuperXacNhan.Checked = cauHinhDangKy.GmailSuperXacNhan;
				GmailSuperTeamApi.Text = cauHinhDangKy.GmailSuperTeamApi;
				oDichVuGmail.Checked = cauHinhDangKy.DichVuGmail;
				oDichVuGmailXacNhan.Checked = cauHinhDangKy.DichVuGmailXacNhan;
				DichVuGmailApi.Text = cauHinhDangKy.DichVuGmailApi;
				oHotmailBox.Checked = cauHinhDangKy.HotmailBox;
				HotmailBoxApi.Text = cauHinhDangKy.HotmailBoxApi;
				oDongVanFb.Checked = cauHinhDangKy.DongVanFb;
				DongVanFbApi.Text = cauHinhDangKy.DongVanFbApi;
				o4G.Checked = cauHinhDangKy.BonG;
				vpnkiwi.Checked = cauHinhDangKy.VpnKiwi;
				oregNVR.Checked = cauHinhDangKy.RegNVR;
				CloneFile.Checked = cauHinhDangKy.LayTuFile;
				oXacMinh.Checked = cauHinhDangKy.XacMinhMail;
				oChangethietbi.Checked = cauHinhDangKy.ChangeThietBi;
				rdoVeriGmail.Checked = cauHinhDangKy.TutVeriGmail;
				ThuMucAvatar.Text = cauHinhDangKy.ThuMucAvatar;
				ThuMucCover.Text = cauHinhDangKy.ThuMucCover;
				Bat2FA.Checked = cauHinhDangKy.HaiFa;
				UploadAnhBia.Checked = cauHinhDangKy.UploadAnhBia;
				UploadAvatar.Checked = cauHinhDangKy.UploadAvatar;
				oGioiThieu.Checked = cauHinhDangKy.ThemGioiThieu;
				txtIronSimApi.Text = cauHinhDangKy.IRonsimApi;
				rdoIRonSim.Checked = cauHinhDangKy.IRonsim;
				cboSoNgoai.Checked = cauHinhDangKy.SoNgoai;
				txtHcOtpApi.Text = cauHinhDangKy.HcOtpApi;
				rdoHcOtp.Checked = cauHinhDangKy.HcOtp;
				txtSim24Api.Text = cauHinhDangKy.Sim24Api;
				rdo24H.Checked = cauHinhDangKy.Sim24;
				cboAddFriend.Checked = cauHinhDangKy.KetBan;
				nmrNumberOfFriend.Value = cauHinhDangKy.SoLuongBanBe;
				rdoWarp.Checked = cauHinhDangKy.Warp;
				rdoPia.Checked = cauHinhDangKy.Pia;
				ckbVeriAccount.Checked = cauHinhDangKy.VeriClone;
				radioButton3.Checked = cauHinhDangKy.ProxyIPPORT;
			}
		}
	}

	private void btnLuu_Click(object sender, EventArgs e)
	{
		CauHinhDangKy value = new CauHinhDangKy
		{
			SoLuong = (int)(SoLuong?.Value ?? 1m),
			RandomMatKhau = oMatKhau.Checked,
			MatKhau = MatKhau.Text,
			NameUs = cboNameUs.Checked,
			IRonsimApi = txtIronSimApi.Text,
			IRonsim = rdoIRonSim.Checked,
			SoNgoai = cboSoNgoai.Checked,
			HcOtpApi = txtHcOtpApi.Text,
			HcOtp = rdoHcOtp.Checked,
			Sim24Api = txtSim24Api.Text,
			Sim24 = rdo24H.Checked,
			GmailSuperXacNhan = oGmailSuperXacNhan.Checked,
			GmailSuperTeam = oGmailSuper.Checked,
			GmailSuperTeamApi = GmailSuperTeamApi.Text,
			DichVuGmailXacNhan = oDichVuGmailXacNhan.Checked,
			HotmailBox = oHotmailBox.Checked,
			HotmailBoxApi = HotmailBoxApi.Text,
			DongVanFb = oDongVanFb.Checked,
			DongVanFbApi = DongVanFbApi.Text,
			DichVuGmail = oDichVuGmail.Checked,
			DichVuGmailApi = DichVuGmailApi.Text,
			RegNVR = oregNVR.Checked,
			TempMail = oTempmail.Checked,
			OneSecMail = oOneSecMail.Checked,
			TutVeriGmail = rdoVeriGmail.Checked,
			BonG = o4G.Checked,
			Warp = rdoWarp.Checked,
			Pia = rdoPia.Checked,
			XacMinhMail = oXacMinh.Checked,
			LayTuFile = CloneFile.Checked,
			ChangeThietBi = oChangethietbi.Checked,
			ThuMucAvatar = ThuMucAvatar.Text,
			ThuMucCover = ThuMucCover.Text,
			HaiFa = Bat2FA.Checked,
			UploadAvatar = UploadAvatar.Checked,
			UploadAnhBia = UploadAnhBia.Checked,
			ThemGioiThieu = oGioiThieu.Checked,
			KetBan = cboAddFriend.Checked,
			SoLuongBanBe = Convert.ToInt32(nmrNumberOfFriend.Value),
			VeriClone = ckbVeriAccount.Checked,
			ProxyIPPORT = radioButton3.Checked
		};
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cauhinh", "cauhinh.json");
        string directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory); // Tạo thư mục nếu không tồn tại
        }
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "{}"); // Tạo file rỗng nếu không tồn tại
        }
        string contents = JsonConvert.SerializeObject(value);
        File.WriteAllText(path, contents); // Ghi nội dung
        Close();
    }
	

	private void oMatKhau_CheckedChanged(object sender, EventArgs e)
	{
		MatKhau.Enabled = !oMatKhau.Checked;
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
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.radioButton4 = new System.Windows.Forms.RadioButton();
		this.CloneFile = new System.Windows.Forms.RadioButton();
		this.rdoVeriGmail = new System.Windows.Forms.RadioButton();
		this.oXacMinh = new System.Windows.Forms.CheckBox();
		this.oregNVR = new System.Windows.Forms.RadioButton();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.nmrNumberOfFriend = new System.Windows.Forms.NumericUpDown();
		this.Ketban = new System.Windows.Forms.CheckBox();
		this.Dangbai = new System.Windows.Forms.CheckBox();
		this.TruongHoc = new System.Windows.Forms.CheckBox();
		this.Vieclam = new System.Windows.Forms.CheckBox();
		this.Thanhpho = new System.Windows.Forms.CheckBox();
		this.cboAddFriend = new System.Windows.Forms.CheckBox();
		this.QueQuan = new System.Windows.Forms.CheckBox();
		this.oGioiThieu = new System.Windows.Forms.CheckBox();
		this.UploadAnhBia = new System.Windows.Forms.CheckBox();
		this.UploadAvatar = new System.Windows.Forms.CheckBox();
		this.Bat2FA = new System.Windows.Forms.CheckBox();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.owifi = new System.Windows.Forms.RadioButton();
		this.o4G = new System.Windows.Forms.RadioButton();
		this.vpnkiwi = new System.Windows.Forms.RadioButton();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.ckbVeriAccount = new System.Windows.Forms.CheckBox();
		this.GmailSuperTeamApi = new System.Windows.Forms.TextBox();
		this.DichVuGmailApi = new System.Windows.Forms.TextBox();
		this.oGmailSuper = new System.Windows.Forms.RadioButton();
		this.oDichVuGmail = new System.Windows.Forms.RadioButton();
		this.txtHcOtpApi = new System.Windows.Forms.TextBox();
		this.rdoHcOtp = new System.Windows.Forms.RadioButton();
		this.txtIronSimApi = new System.Windows.Forms.TextBox();
		this.rdoIRonSim = new System.Windows.Forms.RadioButton();
		this.HotmailBoxApi = new System.Windows.Forms.TextBox();
		this.oHotmailBox = new System.Windows.Forms.RadioButton();
		this.btnLuu = new System.Windows.Forms.Button();
		this.groupBox8 = new System.Windows.Forms.GroupBox();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.rdoWarp = new System.Windows.Forms.RadioButton();
		this.rdoPia = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.groupBox7 = new System.Windows.Forms.GroupBox();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.txtSim24Api = new System.Windows.Forms.TextBox();
		this.rdo24H = new System.Windows.Forms.RadioButton();
		this.oTempmail = new System.Windows.Forms.RadioButton();
		this.oOneSecMail = new System.Windows.Forms.RadioButton();
		this.DongVanFbApi = new System.Windows.Forms.TextBox();
		this.cboSoNgoai = new System.Windows.Forms.CheckBox();
		this.oDongVanFb = new System.Windows.Forms.RadioButton();
		this.oDichVuGmailXacNhan = new System.Windows.Forms.RadioButton();
		this.oGmailSuperXacNhan = new System.Windows.Forms.RadioButton();
		this.groupBox9 = new System.Windows.Forms.GroupBox();
		this.SoLuong = new System.Windows.Forms.NumericUpDown();
		this.ThuMucCover = new System.Windows.Forms.TextBox();
		this.MatKhau = new System.Windows.Forms.TextBox();
		this.ThuMucAvatar = new System.Windows.Forms.TextBox();
		this.oMatKhau = new System.Windows.Forms.CheckBox();
		this.cboNameUs = new System.Windows.Forms.CheckBox();
		this.oChangethietbi = new System.Windows.Forms.CheckBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.lblSoLuong = new System.Windows.Forms.Label();
		this.groupBox4.SuspendLayout();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.nmrNumberOfFriend).BeginInit();
		this.groupBox1.SuspendLayout();
		this.groupBox8.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox7.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.groupBox9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.SoLuong).BeginInit();
		base.SuspendLayout();
		this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.groupBox4.Controls.Add(this.radioButton4);
		this.groupBox4.Controls.Add(this.CloneFile);
		this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox4.ForeColor = System.Drawing.Color.Blue;
		this.groupBox4.Location = new System.Drawing.Point(570, 18);
		this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox4.Size = new System.Drawing.Size(135, 87);
		this.groupBox4.TabIndex = 30;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "Chọn Trang Clone";
		this.radioButton4.AutoSize = true;
		this.radioButton4.ForeColor = System.Drawing.SystemColors.ControlText;
		this.radioButton4.Location = new System.Drawing.Point(7, 44);
		this.radioButton4.Name = "radioButton4";
		this.radioButton4.Size = new System.Drawing.Size(105, 17);
		this.radioButton4.TabIndex = 33;
		this.radioButton4.TabStop = true;
		this.radioButton4.Text = "Clonetds.shop";
		this.radioButton4.UseVisualStyleBackColor = true;
		this.CloneFile.AutoSize = true;
		this.CloneFile.ForeColor = System.Drawing.SystemColors.ControlText;
		this.CloneFile.Location = new System.Drawing.Point(7, 21);
		this.CloneFile.Name = "CloneFile";
		this.CloneFile.Size = new System.Drawing.Size(81, 17);
		this.CloneFile.TabIndex = 32;
		this.CloneFile.TabStop = true;
		this.CloneFile.Text = "Lấy từ file";
		this.CloneFile.UseVisualStyleBackColor = true;
		this.rdoVeriGmail.AutoSize = true;
		this.rdoVeriGmail.Location = new System.Drawing.Point(8, 46);
		this.rdoVeriGmail.Name = "rdoVeriGmail";
		this.rdoVeriGmail.Size = new System.Drawing.Size(82, 17);
		this.rdoVeriGmail.TabIndex = 0;
		this.rdoVeriGmail.TabStop = true;
		this.rdoVeriGmail.Text = "Veri Gmail";
		this.rdoVeriGmail.UseVisualStyleBackColor = true;
		this.oXacMinh.AutoSize = true;
		this.oXacMinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.oXacMinh.Location = new System.Drawing.Point(7, 18);
		this.oXacMinh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oXacMinh.Name = "oXacMinh";
		this.oXacMinh.Size = new System.Drawing.Size(105, 17);
		this.oXacMinh.TabIndex = 0;
		this.oXacMinh.Text = "Xác minh Mail";
		this.oXacMinh.UseVisualStyleBackColor = true;
		this.oregNVR.AutoSize = true;
		this.oregNVR.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oregNVR.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oregNVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.oregNVR.Location = new System.Drawing.Point(8, 21);
		this.oregNVR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oregNVR.Name = "oregNVR";
		this.oregNVR.Size = new System.Drawing.Size(90, 18);
		this.oregNVR.TabIndex = 4;
		this.oregNVR.Text = "Reg Clone";
		this.oregNVR.UseVisualStyleBackColor = true;
		this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.groupBox2.Controls.Add(this.nmrNumberOfFriend);
		this.groupBox2.Controls.Add(this.Ketban);
		this.groupBox2.Controls.Add(this.Dangbai);
		this.groupBox2.Controls.Add(this.TruongHoc);
		this.groupBox2.Controls.Add(this.Vieclam);
		this.groupBox2.Controls.Add(this.Thanhpho);
		this.groupBox2.Controls.Add(this.cboAddFriend);
		this.groupBox2.Controls.Add(this.QueQuan);
		this.groupBox2.Controls.Add(this.oGioiThieu);
		this.groupBox2.Controls.Add(this.UploadAnhBia);
		this.groupBox2.Controls.Add(this.UploadAvatar);
		this.groupBox2.Controls.Add(this.Bat2FA);
		this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox2.ForeColor = System.Drawing.Color.Blue;
		this.groupBox2.Location = new System.Drawing.Point(281, 266);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox2.Size = new System.Drawing.Size(395, 168);
		this.groupBox2.TabIndex = 26;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Cấu Hình Thông Tin";
		this.nmrNumberOfFriend.Location = new System.Drawing.Point(316, 19);
		this.nmrNumberOfFriend.Name = "nmrNumberOfFriend";
		this.nmrNumberOfFriend.Size = new System.Drawing.Size(72, 20);
		this.nmrNumberOfFriend.TabIndex = 9;
		this.Ketban.AutoSize = true;
		this.Ketban.Cursor = System.Windows.Forms.Cursors.Hand;
		this.Ketban.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.Ketban.Location = new System.Drawing.Point(98, 91);
		this.Ketban.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.Ketban.Name = "Ketban";
		this.Ketban.Size = new System.Drawing.Size(77, 18);
		this.Ketban.TabIndex = 9;
		this.Ketban.Text = "Kết Bạn";
		this.Ketban.UseVisualStyleBackColor = true;
		this.Dangbai.AutoSize = true;
		this.Dangbai.Cursor = System.Windows.Forms.Cursors.Hand;
		this.Dangbai.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.Dangbai.Location = new System.Drawing.Point(98, 115);
		this.Dangbai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.Dangbai.Name = "Dangbai";
		this.Dangbai.Size = new System.Drawing.Size(84, 18);
		this.Dangbai.TabIndex = 8;
		this.Dangbai.Text = "Đăng Bài";
		this.Dangbai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Dangbai.UseVisualStyleBackColor = true;
		this.TruongHoc.AutoSize = true;
		this.TruongHoc.Cursor = System.Windows.Forms.Cursors.Hand;
		this.TruongHoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.TruongHoc.Location = new System.Drawing.Point(98, 68);
		this.TruongHoc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.TruongHoc.Name = "TruongHoc";
		this.TruongHoc.Size = new System.Drawing.Size(99, 18);
		this.TruongHoc.TabIndex = 6;
		this.TruongHoc.Text = "Trường Học";
		this.TruongHoc.UseVisualStyleBackColor = true;
		this.Vieclam.AutoSize = true;
		this.Vieclam.Cursor = System.Windows.Forms.Cursors.Hand;
		this.Vieclam.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.Vieclam.Location = new System.Drawing.Point(8, 115);
		this.Vieclam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.Vieclam.Name = "Vieclam";
		this.Vieclam.Size = new System.Drawing.Size(84, 18);
		this.Vieclam.TabIndex = 5;
		this.Vieclam.Text = "Việc Làm";
		this.Vieclam.UseVisualStyleBackColor = true;
		this.Thanhpho.AutoSize = true;
		this.Thanhpho.Cursor = System.Windows.Forms.Cursors.Hand;
		this.Thanhpho.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.Thanhpho.Location = new System.Drawing.Point(98, 44);
		this.Thanhpho.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.Thanhpho.Name = "Thanhpho";
		this.Thanhpho.Size = new System.Drawing.Size(98, 18);
		this.Thanhpho.TabIndex = 4;
		this.Thanhpho.Text = "Thành Phố ";
		this.Thanhpho.UseVisualStyleBackColor = true;
		this.cboAddFriend.AutoSize = true;
		this.cboAddFriend.Cursor = System.Windows.Forms.Cursors.Hand;
		this.cboAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.cboAddFriend.Location = new System.Drawing.Point(193, 20);
		this.cboAddFriend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.cboAddFriend.Name = "cboAddFriend";
		this.cboAddFriend.Size = new System.Drawing.Size(132, 18);
		this.cboAddFriend.TabIndex = 3;
		this.cboAddFriend.Text = "Kết bạn số lương:";
		this.cboAddFriend.UseVisualStyleBackColor = true;
		this.QueQuan.AutoSize = true;
		this.QueQuan.Cursor = System.Windows.Forms.Cursors.Hand;
		this.QueQuan.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.QueQuan.Location = new System.Drawing.Point(98, 20);
		this.QueQuan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.QueQuan.Name = "QueQuan";
		this.QueQuan.Size = new System.Drawing.Size(89, 18);
		this.QueQuan.TabIndex = 3;
		this.QueQuan.Text = "Quê Quán";
		this.QueQuan.UseVisualStyleBackColor = true;
		this.oGioiThieu.AutoSize = true;
		this.oGioiThieu.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oGioiThieu.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oGioiThieu.Location = new System.Drawing.Point(8, 91);
		this.oGioiThieu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oGioiThieu.Name = "oGioiThieu";
		this.oGioiThieu.Size = new System.Drawing.Size(86, 18);
		this.oGioiThieu.TabIndex = 2;
		this.oGioiThieu.Text = "Giới thiệu";
		this.oGioiThieu.UseVisualStyleBackColor = true;
		this.UploadAnhBia.AutoSize = true;
		this.UploadAnhBia.Cursor = System.Windows.Forms.Cursors.Hand;
		this.UploadAnhBia.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.UploadAnhBia.Location = new System.Drawing.Point(8, 68);
		this.UploadAnhBia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.UploadAnhBia.Name = "UploadAnhBia";
		this.UploadAnhBia.Size = new System.Drawing.Size(85, 18);
		this.UploadAnhBia.TabIndex = 2;
		this.UploadAnhBia.Text = "Up Cover";
		this.UploadAnhBia.UseVisualStyleBackColor = true;
		this.UploadAvatar.AutoSize = true;
		this.UploadAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
		this.UploadAvatar.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.UploadAvatar.Location = new System.Drawing.Point(8, 44);
		this.UploadAvatar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.UploadAvatar.Name = "UploadAvatar";
		this.UploadAvatar.Size = new System.Drawing.Size(89, 18);
		this.UploadAvatar.TabIndex = 1;
		this.UploadAvatar.Text = "Up Avatar";
		this.UploadAvatar.UseVisualStyleBackColor = true;
		this.Bat2FA.AutoSize = true;
		this.Bat2FA.Cursor = System.Windows.Forms.Cursors.Hand;
		this.Bat2FA.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.Bat2FA.Location = new System.Drawing.Point(8, 20);
		this.Bat2FA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.Bat2FA.Name = "Bat2FA";
		this.Bat2FA.Size = new System.Drawing.Size(82, 18);
		this.Bat2FA.TabIndex = 0;
		this.Bat2FA.Text = "BẬT 2FA";
		this.Bat2FA.UseVisualStyleBackColor = true;
		this.radioButton1.AutoCheck = false;
		this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.radioButton1.Location = new System.Drawing.Point(113, 19);
		this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(114, 18);
		this.radioButton1.TabIndex = 7;
		this.radioButton1.Text = "KHÔNG ĐỔI IP";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.owifi.BackColor = System.Drawing.SystemColors.Control;
		this.owifi.Cursor = System.Windows.Forms.Cursors.Hand;
		this.owifi.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.owifi.Location = new System.Drawing.Point(8, 43);
		this.owifi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.owifi.Name = "owifi";
		this.owifi.Size = new System.Drawing.Size(68, 18);
		this.owifi.TabIndex = 2;
		this.owifi.Text = "WIFI";
		this.owifi.UseVisualStyleBackColor = false;
		this.o4G.Cursor = System.Windows.Forms.Cursors.Hand;
		this.o4G.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.o4G.Location = new System.Drawing.Point(8, 19);
		this.o4G.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.o4G.Name = "o4G";
		this.o4G.Size = new System.Drawing.Size(55, 18);
		this.o4G.TabIndex = 1;
		this.o4G.Text = "4G";
		this.o4G.UseVisualStyleBackColor = true;
		this.vpnkiwi.Cursor = System.Windows.Forms.Cursors.Hand;
		this.vpnkiwi.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.vpnkiwi.Location = new System.Drawing.Point(8, 67);
		this.vpnkiwi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.vpnkiwi.Name = "vpnkiwi";
		this.vpnkiwi.Size = new System.Drawing.Size(82, 18);
		this.vpnkiwi.TabIndex = 0;
		this.vpnkiwi.Text = "VPN KIWI";
		this.vpnkiwi.UseVisualStyleBackColor = true;
		this.groupBox1.AutoSize = true;
		this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.groupBox1.Controls.Add(this.ckbVeriAccount);
		this.groupBox1.Controls.Add(this.GmailSuperTeamApi);
		this.groupBox1.Controls.Add(this.DichVuGmailApi);
		this.groupBox1.Controls.Add(this.oGmailSuper);
		this.groupBox1.Controls.Add(this.oXacMinh);
		this.groupBox1.Controls.Add(this.oDichVuGmail);
		this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox1.ForeColor = System.Drawing.Color.Blue;
		this.groupBox1.Location = new System.Drawing.Point(7, 16);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox1.Size = new System.Drawing.Size(268, 226);
		this.groupBox1.TabIndex = 24;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Cau hinh Mail";
		this.ckbVeriAccount.AutoSize = true;
		this.ckbVeriAccount.Location = new System.Drawing.Point(9, 183);
		this.ckbVeriAccount.Name = "ckbVeriAccount";
		this.ckbVeriAccount.Size = new System.Drawing.Size(79, 17);
		this.ckbVeriAccount.TabIndex = 8;
		this.ckbVeriAccount.Text = "Reg NVR";
		this.ckbVeriAccount.UseVisualStyleBackColor = true;
		this.GmailSuperTeamApi.Location = new System.Drawing.Point(100, 68);
		this.GmailSuperTeamApi.Name = "GmailSuperTeamApi";
		this.GmailSuperTeamApi.Size = new System.Drawing.Size(161, 20);
		this.GmailSuperTeamApi.TabIndex = 3;
		this.DichVuGmailApi.Location = new System.Drawing.Point(100, 41);
		this.DichVuGmailApi.Name = "DichVuGmailApi";
		this.DichVuGmailApi.Size = new System.Drawing.Size(161, 20);
		this.DichVuGmailApi.TabIndex = 3;
		this.oGmailSuper.AutoSize = true;
		this.oGmailSuper.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oGmailSuper.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oGmailSuper.Location = new System.Drawing.Point(9, 69);
		this.oGmailSuper.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oGmailSuper.Name = "oGmailSuper";
		this.oGmailSuper.Size = new System.Drawing.Size(95, 18);
		this.oGmailSuper.TabIndex = 1;
		this.oGmailSuper.TabStop = true;
		this.oGmailSuper.Text = "GmailSuper";
		this.oGmailSuper.UseVisualStyleBackColor = true;
		this.oDichVuGmail.AutoSize = true;
		this.oDichVuGmail.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oDichVuGmail.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oDichVuGmail.Location = new System.Drawing.Point(10, 43);
		this.oDichVuGmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oDichVuGmail.Name = "oDichVuGmail";
		this.oDichVuGmail.Size = new System.Drawing.Size(83, 18);
		this.oDichVuGmail.TabIndex = 1;
		this.oDichVuGmail.TabStop = true;
		this.oDichVuGmail.Text = "DV Gmail";
		this.oDichVuGmail.UseVisualStyleBackColor = true;
		this.txtHcOtpApi.Location = new System.Drawing.Point(97, 181);
		this.txtHcOtpApi.Name = "txtHcOtpApi";
		this.txtHcOtpApi.Size = new System.Drawing.Size(146, 20);
		this.txtHcOtpApi.TabIndex = 7;
		this.rdoHcOtp.AutoSize = true;
		this.rdoHcOtp.Cursor = System.Windows.Forms.Cursors.Hand;
		this.rdoHcOtp.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.rdoHcOtp.Location = new System.Drawing.Point(5, 181);
		this.rdoHcOtp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.rdoHcOtp.Name = "rdoHcOtp";
		this.rdoHcOtp.Size = new System.Drawing.Size(77, 18);
		this.rdoHcOtp.TabIndex = 6;
		this.rdoHcOtp.TabStop = true;
		this.rdoHcOtp.Text = "HC OTP";
		this.rdoHcOtp.UseVisualStyleBackColor = true;
		this.txtIronSimApi.Location = new System.Drawing.Point(97, 135);
		this.txtIronSimApi.Name = "txtIronSimApi";
		this.txtIronSimApi.Size = new System.Drawing.Size(146, 20);
		this.txtIronSimApi.TabIndex = 7;
		this.rdoIRonSim.AutoSize = true;
		this.rdoIRonSim.Cursor = System.Windows.Forms.Cursors.Hand;
		this.rdoIRonSim.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.rdoIRonSim.Location = new System.Drawing.Point(5, 135);
		this.rdoIRonSim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.rdoIRonSim.Name = "rdoIRonSim";
		this.rdoIRonSim.Size = new System.Drawing.Size(78, 18);
		this.rdoIRonSim.TabIndex = 6;
		this.rdoIRonSim.TabStop = true;
		this.rdoIRonSim.Text = "IRonSim";
		this.rdoIRonSim.UseVisualStyleBackColor = true;
		this.HotmailBoxApi.Location = new System.Drawing.Point(97, 43);
		this.HotmailBoxApi.Name = "HotmailBoxApi";
		this.HotmailBoxApi.Size = new System.Drawing.Size(146, 20);
		this.HotmailBoxApi.TabIndex = 3;
		this.oHotmailBox.AutoSize = true;
		this.oHotmailBox.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oHotmailBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oHotmailBox.Location = new System.Drawing.Point(6, 43);
		this.oHotmailBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oHotmailBox.Name = "oHotmailBox";
		this.oHotmailBox.Size = new System.Drawing.Size(94, 18);
		this.oHotmailBox.TabIndex = 2;
		this.oHotmailBox.TabStop = true;
		this.oHotmailBox.Text = "HotmailBox";
		this.oHotmailBox.UseVisualStyleBackColor = true;
		this.btnLuu.BackColor = System.Drawing.Color.White;
		this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnLuu.ForeColor = System.Drawing.Color.Blue;
		this.btnLuu.Location = new System.Drawing.Point(683, 392);
		this.btnLuu.Name = "btnLuu";
		this.btnLuu.Size = new System.Drawing.Size(135, 40);
		this.btnLuu.TabIndex = 31;
		this.btnLuu.Text = "LƯU CÀI ĐẶT";
		this.btnLuu.UseVisualStyleBackColor = false;
		this.btnLuu.Click += new System.EventHandler(btnLuu_Click);
		this.groupBox8.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.groupBox8.Controls.Add(this.rdoVeriGmail);
		this.groupBox8.Controls.Add(this.oregNVR);
		this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox8.ForeColor = System.Drawing.Color.Blue;
		this.groupBox8.Location = new System.Drawing.Point(713, 18);
		this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox8.Size = new System.Drawing.Size(135, 87);
		this.groupBox8.TabIndex = 27;
		this.groupBox8.TabStop = false;
		this.groupBox8.Text = "Cấu Hình Reg/Veri";
		this.groupBox3.AutoSize = true;
		this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.groupBox3.Controls.Add(this.rdoWarp);
		this.groupBox3.Controls.Add(this.rdoPia);
		this.groupBox3.Controls.Add(this.radioButton2);
		this.groupBox3.Controls.Add(this.o4G);
		this.groupBox3.Controls.Add(this.radioButton1);
		this.groupBox3.Controls.Add(this.radioButton3);
		this.groupBox3.Controls.Add(this.vpnkiwi);
		this.groupBox3.Controls.Add(this.owifi);
		this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox3.ForeColor = System.Drawing.Color.Blue;
		this.groupBox3.Location = new System.Drawing.Point(570, 112);
		this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox3.Size = new System.Drawing.Size(278, 132);
		this.groupBox3.TabIndex = 25;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Cấu Hình IP";
		this.rdoWarp.Cursor = System.Windows.Forms.Cursors.Hand;
		this.rdoWarp.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.rdoWarp.Location = new System.Drawing.Point(113, 43);
		this.rdoWarp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.rdoWarp.Name = "rdoWarp";
		this.rdoWarp.Size = new System.Drawing.Size(97, 18);
		this.rdoWarp.TabIndex = 9;
		this.rdoWarp.Text = "VPN 1.1.1.1";
		this.rdoWarp.UseVisualStyleBackColor = true;
		this.rdoPia.Cursor = System.Windows.Forms.Cursors.Hand;
		this.rdoPia.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.rdoPia.Location = new System.Drawing.Point(113, 89);
		this.rdoPia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.rdoPia.Name = "rdoPia";
		this.rdoPia.Size = new System.Drawing.Size(104, 24);
		this.rdoPia.TabIndex = 10;
		this.rdoPia.Text = "VPN PIA";
		this.rdoPia.UseVisualStyleBackColor = true;
		this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.radioButton2.Location = new System.Drawing.Point(113, 67);
		this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(82, 18);
		this.radioButton2.TabIndex = 8;
		this.radioButton2.Text = "Windscribe";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.radioButton3.Location = new System.Drawing.Point(8, 93);
		this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(127, 18);
		this.radioButton3.TabIndex = 0;
		this.radioButton3.Text = "Proxy IP PORT";
		this.radioButton3.UseVisualStyleBackColor = true;
		this.groupBox7.BackColor = System.Drawing.SystemColors.HighlightText;
		this.groupBox7.Controls.Add(this.btnLuu);
		this.groupBox7.Controls.Add(this.groupBox5);
		this.groupBox7.Controls.Add(this.groupBox4);
		this.groupBox7.Controls.Add(this.groupBox8);
		this.groupBox7.Controls.Add(this.groupBox3);
		this.groupBox7.Controls.Add(this.groupBox9);
		this.groupBox7.Controls.Add(this.groupBox2);
		this.groupBox7.Controls.Add(this.groupBox1);
		this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox7.ForeColor = System.Drawing.Color.Blue;
		this.groupBox7.Location = new System.Drawing.Point(9, 7);
		this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox7.Size = new System.Drawing.Size(866, 461);
		this.groupBox7.TabIndex = 33;
		this.groupBox7.TabStop = false;
		this.groupBox5.AutoSize = true;
		this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.groupBox5.Controls.Add(this.txtSim24Api);
		this.groupBox5.Controls.Add(this.txtHcOtpApi);
		this.groupBox5.Controls.Add(this.rdoHcOtp);
		this.groupBox5.Controls.Add(this.rdo24H);
		this.groupBox5.Controls.Add(this.txtIronSimApi);
		this.groupBox5.Controls.Add(this.rdoIRonSim);
		this.groupBox5.Controls.Add(this.oTempmail);
		this.groupBox5.Controls.Add(this.oOneSecMail);
		this.groupBox5.Controls.Add(this.DongVanFbApi);
		this.groupBox5.Controls.Add(this.HotmailBoxApi);
		this.groupBox5.Controls.Add(this.cboSoNgoai);
		this.groupBox5.Controls.Add(this.oDongVanFb);
		this.groupBox5.Controls.Add(this.oDichVuGmailXacNhan);
		this.groupBox5.Controls.Add(this.oGmailSuperXacNhan);
		this.groupBox5.Controls.Add(this.oHotmailBox);
		this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox5.ForeColor = System.Drawing.Color.Blue;
		this.groupBox5.Location = new System.Drawing.Point(275, 16);
		this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox5.Size = new System.Drawing.Size(287, 239);
		this.groupBox5.TabIndex = 31;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Cấu hình Veri";
		this.txtSim24Api.Location = new System.Drawing.Point(97, 159);
		this.txtSim24Api.Name = "txtSim24Api";
		this.txtSim24Api.Size = new System.Drawing.Size(146, 20);
		this.txtSim24Api.TabIndex = 7;
		this.rdo24H.AutoSize = true;
		this.rdo24H.Cursor = System.Windows.Forms.Cursors.Hand;
		this.rdo24H.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.rdo24H.Location = new System.Drawing.Point(5, 159);
		this.rdo24H.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.rdo24H.Name = "rdo24H";
		this.rdo24H.Size = new System.Drawing.Size(54, 18);
		this.rdo24H.TabIndex = 6;
		this.rdo24H.TabStop = true;
		this.rdo24H.Text = "24H";
		this.rdo24H.UseVisualStyleBackColor = true;
		this.oTempmail.AutoSize = true;
		this.oTempmail.ForeColor = System.Drawing.SystemColors.WindowText;
		this.oTempmail.Location = new System.Drawing.Point(6, 21);
		this.oTempmail.Name = "oTempmail";
		this.oTempmail.Size = new System.Drawing.Size(78, 17);
		this.oTempmail.TabIndex = 4;
		this.oTempmail.TabStop = true;
		this.oTempmail.Text = "Tempmail";
		this.oTempmail.UseVisualStyleBackColor = true;
		this.oOneSecMail.AutoSize = true;
		this.oOneSecMail.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oOneSecMail.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oOneSecMail.Location = new System.Drawing.Point(6, 202);
		this.oOneSecMail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oOneSecMail.Name = "oOneSecMail";
		this.oOneSecMail.Size = new System.Drawing.Size(99, 18);
		this.oOneSecMail.TabIndex = 8;
		this.oOneSecMail.TabStop = true;
		this.oOneSecMail.Text = "OneSecMail";
		this.oOneSecMail.UseVisualStyleBackColor = true;
		this.DongVanFbApi.Location = new System.Drawing.Point(97, 67);
		this.DongVanFbApi.Name = "DongVanFbApi";
		this.DongVanFbApi.Size = new System.Drawing.Size(146, 20);
		this.DongVanFbApi.TabIndex = 3;
		this.cboSoNgoai.AutoSize = true;
		this.cboSoNgoai.Cursor = System.Windows.Forms.Cursors.Hand;
		this.cboSoNgoai.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.cboSoNgoai.Location = new System.Drawing.Point(176, 114);
		this.cboSoNgoai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.cboSoNgoai.Name = "cboSoNgoai";
		this.cboSoNgoai.Size = new System.Drawing.Size(82, 18);
		this.cboSoNgoai.TabIndex = 3;
		this.cboSoNgoai.Text = "Số ngoại";
		this.cboSoNgoai.UseVisualStyleBackColor = true;
		this.oDongVanFb.AutoSize = true;
		this.oDongVanFb.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oDongVanFb.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oDongVanFb.Location = new System.Drawing.Point(5, 67);
		this.oDongVanFb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oDongVanFb.Name = "oDongVanFb";
		this.oDongVanFb.Size = new System.Drawing.Size(98, 18);
		this.oDongVanFb.TabIndex = 2;
		this.oDongVanFb.TabStop = true;
		this.oDongVanFb.Text = "DongVanFB";
		this.oDongVanFb.UseVisualStyleBackColor = true;
		this.oDichVuGmailXacNhan.AutoSize = true;
		this.oDichVuGmailXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oDichVuGmailXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oDichVuGmailXacNhan.Location = new System.Drawing.Point(5, 114);
		this.oDichVuGmailXacNhan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oDichVuGmailXacNhan.Name = "oDichVuGmailXacNhan";
		this.oDichVuGmailXacNhan.Size = new System.Drawing.Size(111, 18);
		this.oDichVuGmailXacNhan.TabIndex = 2;
		this.oDichVuGmailXacNhan.TabStop = true;
		this.oDichVuGmailXacNhan.Text = "Dich Vu Gmail";
		this.oDichVuGmailXacNhan.UseVisualStyleBackColor = true;
		this.oGmailSuperXacNhan.AutoSize = true;
		this.oGmailSuperXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oGmailSuperXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oGmailSuperXacNhan.Location = new System.Drawing.Point(5, 92);
		this.oGmailSuperXacNhan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oGmailSuperXacNhan.Name = "oGmailSuperXacNhan";
		this.oGmailSuperXacNhan.Size = new System.Drawing.Size(130, 18);
		this.oGmailSuperXacNhan.TabIndex = 2;
		this.oGmailSuperXacNhan.TabStop = true;
		this.oGmailSuperXacNhan.Text = "Gmail SuperTeam";
		this.oGmailSuperXacNhan.UseVisualStyleBackColor = true;
		this.groupBox9.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.groupBox9.Controls.Add(this.SoLuong);
		this.groupBox9.Controls.Add(this.ThuMucCover);
		this.groupBox9.Controls.Add(this.MatKhau);
		this.groupBox9.Controls.Add(this.ThuMucAvatar);
		this.groupBox9.Controls.Add(this.oMatKhau);
		this.groupBox9.Controls.Add(this.cboNameUs);
		this.groupBox9.Controls.Add(this.oChangethietbi);
		this.groupBox9.Controls.Add(this.label3);
		this.groupBox9.Controls.Add(this.label2);
		this.groupBox9.Controls.Add(this.label1);
		this.groupBox9.Controls.Add(this.lblSoLuong);
		this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox9.ForeColor = System.Drawing.Color.Blue;
		this.groupBox9.Location = new System.Drawing.Point(8, 266);
		this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox9.Name = "groupBox9";
		this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox9.Size = new System.Drawing.Size(268, 168);
		this.groupBox9.TabIndex = 28;
		this.groupBox9.TabStop = false;
		this.groupBox9.Text = "Cấu Hình Thông Tin";
		this.SoLuong.Location = new System.Drawing.Point(93, 42);
		this.SoLuong.Name = "SoLuong";
		this.SoLuong.Size = new System.Drawing.Size(114, 20);
		this.SoLuong.TabIndex = 9;
		this.ThuMucCover.Location = new System.Drawing.Point(93, 137);
		this.ThuMucCover.Name = "ThuMucCover";
		this.ThuMucCover.Size = new System.Drawing.Size(114, 20);
		this.ThuMucCover.TabIndex = 8;
		this.MatKhau.Location = new System.Drawing.Point(93, 67);
		this.MatKhau.Name = "MatKhau";
		this.MatKhau.Size = new System.Drawing.Size(114, 20);
		this.MatKhau.TabIndex = 8;
		this.ThuMucAvatar.Location = new System.Drawing.Point(93, 112);
		this.ThuMucAvatar.Name = "ThuMucAvatar";
		this.ThuMucAvatar.Size = new System.Drawing.Size(114, 20);
		this.ThuMucAvatar.TabIndex = 8;
		this.oMatKhau.AutoSize = true;
		this.oMatKhau.ForeColor = System.Drawing.Color.Black;
		this.oMatKhau.Location = new System.Drawing.Point(93, 91);
		this.oMatKhau.Name = "oMatKhau";
		this.oMatKhau.Size = new System.Drawing.Size(72, 17);
		this.oMatKhau.TabIndex = 7;
		this.oMatKhau.Text = "Random";
		this.oMatKhau.UseVisualStyleBackColor = true;
		this.oMatKhau.CheckedChanged += new System.EventHandler(oMatKhau_CheckedChanged);
		this.cboNameUs.AutoSize = true;
		this.cboNameUs.Location = new System.Drawing.Point(144, 18);
		this.cboNameUs.Name = "cboNameUs";
		this.cboNameUs.Size = new System.Drawing.Size(95, 17);
		this.cboNameUs.TabIndex = 7;
		this.cboNameUs.Text = "Name Ngoại";
		this.cboNameUs.UseVisualStyleBackColor = true;
		this.oChangethietbi.AutoSize = true;
		this.oChangethietbi.Location = new System.Drawing.Point(10, 18);
		this.oChangethietbi.Name = "oChangethietbi";
		this.oChangethietbi.Size = new System.Drawing.Size(117, 17);
		this.oChangethietbi.TabIndex = 7;
		this.oChangethietbi.Text = "Change Thiết Bị";
		this.oChangethietbi.UseVisualStyleBackColor = true;
		this.label3.AutoSize = true;
		this.label3.ForeColor = System.Drawing.Color.Red;
		this.label3.Location = new System.Drawing.Point(4, 71);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(64, 13);
		this.label3.TabIndex = 3;
		this.label3.Text = "Mật khẩu:";
		this.label2.AutoSize = true;
		this.label2.ForeColor = System.Drawing.Color.Red;
		this.label2.Location = new System.Drawing.Point(4, 140);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(79, 13);
		this.label2.TabIndex = 6;
		this.label2.Text = "Cover Folder";
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.Red;
		this.label1.Location = new System.Drawing.Point(4, 114);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(83, 13);
		this.label1.TabIndex = 3;
		this.label1.Text = "Avatar Folder";
		this.lblSoLuong.AutoSize = true;
		this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblSoLuong.ForeColor = System.Drawing.Color.Red;
		this.lblSoLuong.Location = new System.Drawing.Point(7, 46);
		this.lblSoLuong.Name = "lblSoLuong";
		this.lblSoLuong.Size = new System.Drawing.Size(69, 13);
		this.lblSoLuong.TabIndex = 2;
		this.lblSoLuong.Text = "Số Luồng :";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Silver;
		base.ClientSize = new System.Drawing.Size(876, 467);
		base.Controls.Add(this.groupBox7);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.ForeColor = System.Drawing.Color.Yellow;
		base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		base.Name = "FormCauHinh";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Cài Đặt Cấu Hình Cửu Long Pro";
		base.Load += new System.EventHandler(FormCauHinh_Load);
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.nmrNumberOfFriend).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox8.ResumeLayout(false);
		this.groupBox8.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox7.ResumeLayout(false);
		this.groupBox7.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		this.groupBox9.ResumeLayout(false);
		this.groupBox9.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.SoLuong).EndInit();
		base.ResumeLayout(false);
	}
}
