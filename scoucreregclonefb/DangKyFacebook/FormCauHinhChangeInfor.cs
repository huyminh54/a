using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DangKyFacebook.KetBan;
using DangKyFacebook.KichBanNuoi;

namespace DangKyFacebook;

public class FormCauHinhChangeInfor : Form
{
	private IContainer components = null;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private GroupBox DOITHONGTIN;

	private CheckBox oDoimatkhau;

	private CheckBox oThemmailmoi;

	private CheckBox oCongviec;

	private CheckBox otieusubanthan;

	private CheckBox oBat2fa;

	private CheckBox oDangxuatthietbicu;

	private CheckBox oavatar;

	private CheckBox oQuequan;

	private CheckBox othanhphohientai;

	private CheckBox otruonghoc;

	private CheckBox ocover;

	private CheckBox oXoathietbitincay;

	private CheckBox odoiten;

	private Button NUTLUU;

	private GroupBox groupBox2;

	private CheckBox checkBox23;

	private CheckBox checkBox22;

	private CheckBox checkBox21;

	private CheckBox checkBox20;

	private CheckBox checkBox19;

	private CheckBox checkBox18;

	private CheckBox checkBox17;

	private CheckBox checkBox16;

	private CheckBox checkBox15;

	private CheckBox checkBox14;

	private CheckBox checkBox13;

	private CheckBox checkBox12;

	private CheckBox checkBox11;

	private CheckBox checkBox10;

	private CheckBox checkBox9;

	private CheckBox checkBox8;

	private CheckBox checkBox7;

	private CheckBox checkBox6;

	private CheckBox checkBox5;

	private CheckBox checkBox4;

	private CheckBox checkBox3;

	private CheckBox checkBox2;

	private CheckBox checkBox1;

	private CheckBox oKetban;

	private CheckBox checkBox24;

	private LinkLabel lblFormKetBan;

	private LinkLabel lblChangePass;

	private LinkLabel lblDoiThongTin;

	private LinkLabel oUpcover;

	private LinkLabel thanhphohientai;

	private LinkLabel Truonghoc;

	private LinkLabel Congviec;

	private LinkLabel Doiten;

	private LinkLabel ThemMailmoi;

	private LinkLabel tieusubanthan;

	private LinkLabel Quequan;

	private GroupBox groupBox3;

	private LinkLabel linkLabel10;

	private LinkLabel docthongbao;

	private CheckBox checkBox29;

	private CheckBox checkBox37;

	private GroupBox groupBox5;

	private LinkLabel GmailSuperTeam1;

	private LinkLabel DongVanFB1;

	private LinkLabel HotmailBox1;

	private LinkLabel HotmailBox;

	private RadioButton oTempmail;

	private RadioButton oDongVanFb;

	private RadioButton oGmailSuperXacNhan;

	private RadioButton oHotmailBox;

	public FormCauHinhChangeInfor()
	{
		InitializeComponent();
	}

	private void FormCauHinhChangeInfor_Load(object sender, EventArgs e)
	{
	}

	private void lblFormKetBan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		FormKetBan formKetBan = new FormKetBan();
		formKetBan.Show();
	}

	private void lblChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		FormDoiMatKhau formDoiMatKhau = new FormDoiMatKhau();
		formDoiMatKhau.Show();
	}

	private void lblDoiThongTin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		FormDoiThongTin formDoiThongTin = new FormDoiThongTin();
		formDoiThongTin.Show();
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
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.linkLabel10 = new System.Windows.Forms.LinkLabel();
		this.docthongbao = new System.Windows.Forms.LinkLabel();
		this.checkBox29 = new System.Windows.Forms.CheckBox();
		this.checkBox37 = new System.Windows.Forms.CheckBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.lblFormKetBan = new System.Windows.Forms.LinkLabel();
		this.checkBox24 = new System.Windows.Forms.CheckBox();
		this.checkBox23 = new System.Windows.Forms.CheckBox();
		this.checkBox22 = new System.Windows.Forms.CheckBox();
		this.checkBox21 = new System.Windows.Forms.CheckBox();
		this.checkBox20 = new System.Windows.Forms.CheckBox();
		this.checkBox19 = new System.Windows.Forms.CheckBox();
		this.checkBox18 = new System.Windows.Forms.CheckBox();
		this.checkBox17 = new System.Windows.Forms.CheckBox();
		this.checkBox16 = new System.Windows.Forms.CheckBox();
		this.checkBox15 = new System.Windows.Forms.CheckBox();
		this.checkBox14 = new System.Windows.Forms.CheckBox();
		this.checkBox13 = new System.Windows.Forms.CheckBox();
		this.checkBox12 = new System.Windows.Forms.CheckBox();
		this.checkBox11 = new System.Windows.Forms.CheckBox();
		this.checkBox10 = new System.Windows.Forms.CheckBox();
		this.checkBox9 = new System.Windows.Forms.CheckBox();
		this.checkBox8 = new System.Windows.Forms.CheckBox();
		this.checkBox7 = new System.Windows.Forms.CheckBox();
		this.checkBox6 = new System.Windows.Forms.CheckBox();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.oKetban = new System.Windows.Forms.CheckBox();
		this.NUTLUU = new System.Windows.Forms.Button();
		this.DOITHONGTIN = new System.Windows.Forms.GroupBox();
		this.tieusubanthan = new System.Windows.Forms.LinkLabel();
		this.Quequan = new System.Windows.Forms.LinkLabel();
		this.thanhphohientai = new System.Windows.Forms.LinkLabel();
		this.Truonghoc = new System.Windows.Forms.LinkLabel();
		this.Congviec = new System.Windows.Forms.LinkLabel();
		this.Doiten = new System.Windows.Forms.LinkLabel();
		this.ThemMailmoi = new System.Windows.Forms.LinkLabel();
		this.oUpcover = new System.Windows.Forms.LinkLabel();
		this.lblDoiThongTin = new System.Windows.Forms.LinkLabel();
		this.lblChangePass = new System.Windows.Forms.LinkLabel();
		this.oXoathietbitincay = new System.Windows.Forms.CheckBox();
		this.odoiten = new System.Windows.Forms.CheckBox();
		this.oThemmailmoi = new System.Windows.Forms.CheckBox();
		this.ocover = new System.Windows.Forms.CheckBox();
		this.oavatar = new System.Windows.Forms.CheckBox();
		this.oQuequan = new System.Windows.Forms.CheckBox();
		this.othanhphohientai = new System.Windows.Forms.CheckBox();
		this.otruonghoc = new System.Windows.Forms.CheckBox();
		this.oCongviec = new System.Windows.Forms.CheckBox();
		this.otieusubanthan = new System.Windows.Forms.CheckBox();
		this.oBat2fa = new System.Windows.Forms.CheckBox();
		this.oDangxuatthietbicu = new System.Windows.Forms.CheckBox();
		this.oDoimatkhau = new System.Windows.Forms.CheckBox();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.GmailSuperTeam1 = new System.Windows.Forms.LinkLabel();
		this.DongVanFB1 = new System.Windows.Forms.LinkLabel();
		this.HotmailBox1 = new System.Windows.Forms.LinkLabel();
		this.HotmailBox = new System.Windows.Forms.LinkLabel();
		this.oTempmail = new System.Windows.Forms.RadioButton();
		this.oDongVanFb = new System.Windows.Forms.RadioButton();
		this.oGmailSuperXacNhan = new System.Windows.Forms.RadioButton();
		this.oHotmailBox = new System.Windows.Forms.RadioButton();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.DOITHONGTIN.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.groupBox5.SuspendLayout();
		base.SuspendLayout();
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl1.Location = new System.Drawing.Point(0, 0);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(1256, 491);
		this.tabControl1.TabIndex = 0;
		this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
		this.tabPage1.Controls.Add(this.groupBox3);
		this.tabPage1.Controls.Add(this.groupBox2);
		this.tabPage1.Controls.Add(this.NUTLUU);
		this.tabPage1.Controls.Add(this.DOITHONGTIN);
		this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, 0);
		this.tabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.tabPage1.Location = new System.Drawing.Point(4, 22);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(1248, 465);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Cáu hình chung";
		this.groupBox3.BackColor = System.Drawing.Color.LightGray;
		this.groupBox3.Controls.Add(this.linkLabel10);
		this.groupBox3.Controls.Add(this.docthongbao);
		this.groupBox3.Controls.Add(this.checkBox29);
		this.groupBox3.Controls.Add(this.checkBox37);
		this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.groupBox3.ForeColor = System.Drawing.Color.Red;
		this.groupBox3.Location = new System.Drawing.Point(8, 6);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(208, 444);
		this.groupBox3.TabIndex = 40;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "TƯƠNG TÁC";
		this.linkLabel10.AutoSize = true;
		this.linkLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel10.Location = new System.Drawing.Point(37, 53);
		this.linkLabel10.Name = "linkLabel10";
		this.linkLabel10.Size = new System.Drawing.Size(61, 13);
		this.linkLabel10.TabIndex = 14;
		this.linkLabel10.TabStop = true;
		this.linkLabel10.Text = "Xem Reel";
		this.docthongbao.AutoSize = true;
		this.docthongbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.docthongbao.Location = new System.Drawing.Point(36, 34);
		this.docthongbao.Name = "docthongbao";
		this.docthongbao.Size = new System.Drawing.Size(95, 13);
		this.docthongbao.TabIndex = 31;
		this.docthongbao.TabStop = true;
		this.docthongbao.Text = "Đọc  thông báo";
		this.checkBox29.AutoSize = true;
		this.checkBox29.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox29.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox29.Location = new System.Drawing.Point(19, 53);
		this.checkBox29.Name = "checkBox29";
		this.checkBox29.Size = new System.Drawing.Size(15, 14);
		this.checkBox29.TabIndex = 9;
		this.checkBox29.UseVisualStyleBackColor = true;
		this.checkBox37.AutoSize = true;
		this.checkBox37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox37.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox37.Location = new System.Drawing.Point(19, 33);
		this.checkBox37.Name = "checkBox37";
		this.checkBox37.Size = new System.Drawing.Size(15, 14);
		this.checkBox37.TabIndex = 0;
		this.checkBox37.UseVisualStyleBackColor = true;
		this.groupBox2.AutoSize = true;
		this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
		this.groupBox2.Controls.Add(this.lblFormKetBan);
		this.groupBox2.Controls.Add(this.checkBox24);
		this.groupBox2.Controls.Add(this.checkBox23);
		this.groupBox2.Controls.Add(this.checkBox22);
		this.groupBox2.Controls.Add(this.checkBox21);
		this.groupBox2.Controls.Add(this.checkBox20);
		this.groupBox2.Controls.Add(this.checkBox19);
		this.groupBox2.Controls.Add(this.checkBox18);
		this.groupBox2.Controls.Add(this.checkBox17);
		this.groupBox2.Controls.Add(this.checkBox16);
		this.groupBox2.Controls.Add(this.checkBox15);
		this.groupBox2.Controls.Add(this.checkBox14);
		this.groupBox2.Controls.Add(this.checkBox13);
		this.groupBox2.Controls.Add(this.checkBox12);
		this.groupBox2.Controls.Add(this.checkBox11);
		this.groupBox2.Controls.Add(this.checkBox10);
		this.groupBox2.Controls.Add(this.checkBox9);
		this.groupBox2.Controls.Add(this.checkBox8);
		this.groupBox2.Controls.Add(this.checkBox7);
		this.groupBox2.Controls.Add(this.checkBox6);
		this.groupBox2.Controls.Add(this.checkBox5);
		this.groupBox2.Controls.Add(this.checkBox4);
		this.groupBox2.Controls.Add(this.checkBox3);
		this.groupBox2.Controls.Add(this.checkBox2);
		this.groupBox2.Controls.Add(this.checkBox1);
		this.groupBox2.Controls.Add(this.oKetban);
		this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox2.ForeColor = System.Drawing.Color.Red;
		this.groupBox2.Location = new System.Drawing.Point(223, 6);
		this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox2.Size = new System.Drawing.Size(264, 444);
		this.groupBox2.TabIndex = 34;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Cấu hình Veri";
		this.lblFormKetBan.AutoSize = true;
		this.lblFormKetBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblFormKetBan.Location = new System.Drawing.Point(28, 34);
		this.lblFormKetBan.Name = "lblFormKetBan";
		this.lblFormKetBan.Size = new System.Drawing.Size(51, 13);
		this.lblFormKetBan.TabIndex = 31;
		this.lblFormKetBan.TabStop = true;
		this.lblFormKetBan.Text = "Kết bạn";
		this.lblFormKetBan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lblFormKetBan_LinkClicked);
		this.checkBox24.AutoSize = true;
		this.checkBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox24.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox24.Location = new System.Drawing.Point(173, 285);
		this.checkBox24.Name = "checkBox24";
		this.checkBox24.Size = new System.Drawing.Size(71, 17);
		this.checkBox24.TabIndex = 30;
		this.checkBox24.Text = "Kết Bạn";
		this.checkBox24.UseVisualStyleBackColor = true;
		this.checkBox23.AutoSize = true;
		this.checkBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox23.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox23.Location = new System.Drawing.Point(173, 262);
		this.checkBox23.Name = "checkBox23";
		this.checkBox23.Size = new System.Drawing.Size(71, 17);
		this.checkBox23.TabIndex = 29;
		this.checkBox23.Text = "Kết Bạn";
		this.checkBox23.UseVisualStyleBackColor = true;
		this.checkBox22.AutoSize = true;
		this.checkBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox22.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox22.Location = new System.Drawing.Point(173, 239);
		this.checkBox22.Name = "checkBox22";
		this.checkBox22.Size = new System.Drawing.Size(71, 17);
		this.checkBox22.TabIndex = 28;
		this.checkBox22.Text = "Kết Bạn";
		this.checkBox22.UseVisualStyleBackColor = true;
		this.checkBox21.AutoSize = true;
		this.checkBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox21.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox21.Location = new System.Drawing.Point(173, 216);
		this.checkBox21.Name = "checkBox21";
		this.checkBox21.Size = new System.Drawing.Size(71, 17);
		this.checkBox21.TabIndex = 27;
		this.checkBox21.Text = "Kết Bạn";
		this.checkBox21.UseVisualStyleBackColor = true;
		this.checkBox20.AutoSize = true;
		this.checkBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox20.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox20.Location = new System.Drawing.Point(173, 195);
		this.checkBox20.Name = "checkBox20";
		this.checkBox20.Size = new System.Drawing.Size(71, 17);
		this.checkBox20.TabIndex = 26;
		this.checkBox20.Text = "Kết Bạn";
		this.checkBox20.UseVisualStyleBackColor = true;
		this.checkBox19.AutoSize = true;
		this.checkBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox19.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox19.Location = new System.Drawing.Point(173, 172);
		this.checkBox19.Name = "checkBox19";
		this.checkBox19.Size = new System.Drawing.Size(71, 17);
		this.checkBox19.TabIndex = 25;
		this.checkBox19.Text = "Kết Bạn";
		this.checkBox19.UseVisualStyleBackColor = true;
		this.checkBox18.AutoSize = true;
		this.checkBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox18.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox18.Location = new System.Drawing.Point(173, 149);
		this.checkBox18.Name = "checkBox18";
		this.checkBox18.Size = new System.Drawing.Size(71, 17);
		this.checkBox18.TabIndex = 24;
		this.checkBox18.Text = "Kết Bạn";
		this.checkBox18.UseVisualStyleBackColor = true;
		this.checkBox17.AutoSize = true;
		this.checkBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox17.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox17.Location = new System.Drawing.Point(173, 126);
		this.checkBox17.Name = "checkBox17";
		this.checkBox17.Size = new System.Drawing.Size(71, 17);
		this.checkBox17.TabIndex = 23;
		this.checkBox17.Text = "Kết Bạn";
		this.checkBox17.UseVisualStyleBackColor = true;
		this.checkBox16.AutoSize = true;
		this.checkBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox16.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox16.Location = new System.Drawing.Point(173, 102);
		this.checkBox16.Name = "checkBox16";
		this.checkBox16.Size = new System.Drawing.Size(71, 17);
		this.checkBox16.TabIndex = 22;
		this.checkBox16.Text = "Kết Bạn";
		this.checkBox16.UseVisualStyleBackColor = true;
		this.checkBox15.AutoSize = true;
		this.checkBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox15.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox15.Location = new System.Drawing.Point(173, 78);
		this.checkBox15.Name = "checkBox15";
		this.checkBox15.Size = new System.Drawing.Size(71, 17);
		this.checkBox15.TabIndex = 21;
		this.checkBox15.Text = "Kết Bạn";
		this.checkBox15.UseVisualStyleBackColor = true;
		this.checkBox14.AutoSize = true;
		this.checkBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox14.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox14.Location = new System.Drawing.Point(173, 55);
		this.checkBox14.Name = "checkBox14";
		this.checkBox14.Size = new System.Drawing.Size(71, 17);
		this.checkBox14.TabIndex = 20;
		this.checkBox14.Text = "Kết Bạn";
		this.checkBox14.UseVisualStyleBackColor = true;
		this.checkBox13.AutoSize = true;
		this.checkBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox13.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox13.Location = new System.Drawing.Point(173, 32);
		this.checkBox13.Name = "checkBox13";
		this.checkBox13.Size = new System.Drawing.Size(71, 17);
		this.checkBox13.TabIndex = 19;
		this.checkBox13.Text = "Kết Bạn";
		this.checkBox13.UseVisualStyleBackColor = true;
		this.checkBox12.AutoSize = true;
		this.checkBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox12.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox12.Location = new System.Drawing.Point(7, 55);
		this.checkBox12.Name = "checkBox12";
		this.checkBox12.Size = new System.Drawing.Size(15, 14);
		this.checkBox12.TabIndex = 18;
		this.checkBox12.UseVisualStyleBackColor = true;
		this.checkBox11.AutoSize = true;
		this.checkBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox11.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox11.Location = new System.Drawing.Point(7, 80);
		this.checkBox11.Name = "checkBox11";
		this.checkBox11.Size = new System.Drawing.Size(15, 14);
		this.checkBox11.TabIndex = 17;
		this.checkBox11.UseVisualStyleBackColor = true;
		this.checkBox10.AutoSize = true;
		this.checkBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox10.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox10.Location = new System.Drawing.Point(7, 103);
		this.checkBox10.Name = "checkBox10";
		this.checkBox10.Size = new System.Drawing.Size(71, 17);
		this.checkBox10.TabIndex = 16;
		this.checkBox10.Text = "Kết Bạn";
		this.checkBox10.UseVisualStyleBackColor = true;
		this.checkBox9.AutoSize = true;
		this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox9.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox9.Location = new System.Drawing.Point(7, 126);
		this.checkBox9.Name = "checkBox9";
		this.checkBox9.Size = new System.Drawing.Size(71, 17);
		this.checkBox9.TabIndex = 15;
		this.checkBox9.Text = "Kết Bạn";
		this.checkBox9.UseVisualStyleBackColor = true;
		this.checkBox8.AutoSize = true;
		this.checkBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox8.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox8.Location = new System.Drawing.Point(7, 149);
		this.checkBox8.Name = "checkBox8";
		this.checkBox8.Size = new System.Drawing.Size(71, 17);
		this.checkBox8.TabIndex = 14;
		this.checkBox8.Text = "Kết Bạn";
		this.checkBox8.UseVisualStyleBackColor = true;
		this.checkBox7.AutoSize = true;
		this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox7.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox7.Location = new System.Drawing.Point(7, 170);
		this.checkBox7.Name = "checkBox7";
		this.checkBox7.Size = new System.Drawing.Size(71, 17);
		this.checkBox7.TabIndex = 13;
		this.checkBox7.Text = "Kết Bạn";
		this.checkBox7.UseVisualStyleBackColor = true;
		this.checkBox6.AutoSize = true;
		this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox6.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox6.Location = new System.Drawing.Point(7, 193);
		this.checkBox6.Name = "checkBox6";
		this.checkBox6.Size = new System.Drawing.Size(71, 17);
		this.checkBox6.TabIndex = 12;
		this.checkBox6.Text = "Kết Bạn";
		this.checkBox6.UseVisualStyleBackColor = true;
		this.checkBox5.AutoSize = true;
		this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox5.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox5.Location = new System.Drawing.Point(7, 216);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(71, 17);
		this.checkBox5.TabIndex = 11;
		this.checkBox5.Text = "Kết Bạn";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.checkBox4.AutoSize = true;
		this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox4.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox4.Location = new System.Drawing.Point(7, 239);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(71, 17);
		this.checkBox4.TabIndex = 10;
		this.checkBox4.Text = "Kết Bạn";
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox3.AutoSize = true;
		this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox3.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox3.Location = new System.Drawing.Point(7, 262);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(71, 17);
		this.checkBox3.TabIndex = 9;
		this.checkBox3.Text = "Kết Bạn";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox2.AutoSize = true;
		this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox2.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox2.Location = new System.Drawing.Point(7, 285);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(71, 17);
		this.checkBox2.TabIndex = 8;
		this.checkBox2.Text = "Kết Bạn";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.checkBox1.ForeColor = System.Drawing.Color.RoyalBlue;
		this.checkBox1.Location = new System.Drawing.Point(7, 308);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(71, 17);
		this.checkBox1.TabIndex = 7;
		this.checkBox1.Text = "Kết Bạn";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.oKetban.AutoSize = true;
		this.oKetban.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oKetban.ForeColor = System.Drawing.Color.RoyalBlue;
		this.oKetban.Location = new System.Drawing.Point(7, 32);
		this.oKetban.Name = "oKetban";
		this.oKetban.Size = new System.Drawing.Size(15, 14);
		this.oKetban.TabIndex = 6;
		this.oKetban.UseVisualStyleBackColor = true;
		this.NUTLUU.BackColor = System.Drawing.Color.Blue;
		this.NUTLUU.Font = new System.Drawing.Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel, 0);
		this.NUTLUU.ForeColor = System.Drawing.SystemColors.ButtonFace;
		this.NUTLUU.Location = new System.Drawing.Point(1078, 401);
		this.NUTLUU.Name = "NUTLUU";
		this.NUTLUU.Size = new System.Drawing.Size(162, 56);
		this.NUTLUU.TabIndex = 33;
		this.NUTLUU.Text = "LƯU CÀI ĐẶT";
		this.NUTLUU.UseVisualStyleBackColor = false;
		this.DOITHONGTIN.BackColor = System.Drawing.Color.LightGray;
		this.DOITHONGTIN.Controls.Add(this.tieusubanthan);
		this.DOITHONGTIN.Controls.Add(this.Quequan);
		this.DOITHONGTIN.Controls.Add(this.thanhphohientai);
		this.DOITHONGTIN.Controls.Add(this.Truonghoc);
		this.DOITHONGTIN.Controls.Add(this.Congviec);
		this.DOITHONGTIN.Controls.Add(this.Doiten);
		this.DOITHONGTIN.Controls.Add(this.ThemMailmoi);
		this.DOITHONGTIN.Controls.Add(this.oUpcover);
		this.DOITHONGTIN.Controls.Add(this.lblDoiThongTin);
		this.DOITHONGTIN.Controls.Add(this.lblChangePass);
		this.DOITHONGTIN.Controls.Add(this.oXoathietbitincay);
		this.DOITHONGTIN.Controls.Add(this.odoiten);
		this.DOITHONGTIN.Controls.Add(this.oThemmailmoi);
		this.DOITHONGTIN.Controls.Add(this.ocover);
		this.DOITHONGTIN.Controls.Add(this.oavatar);
		this.DOITHONGTIN.Controls.Add(this.oQuequan);
		this.DOITHONGTIN.Controls.Add(this.othanhphohientai);
		this.DOITHONGTIN.Controls.Add(this.otruonghoc);
		this.DOITHONGTIN.Controls.Add(this.oCongviec);
		this.DOITHONGTIN.Controls.Add(this.otieusubanthan);
		this.DOITHONGTIN.Controls.Add(this.oBat2fa);
		this.DOITHONGTIN.Controls.Add(this.oDangxuatthietbicu);
		this.DOITHONGTIN.Controls.Add(this.oDoimatkhau);
		this.DOITHONGTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.DOITHONGTIN.ForeColor = System.Drawing.Color.Red;
		this.DOITHONGTIN.Location = new System.Drawing.Point(494, 6);
		this.DOITHONGTIN.Name = "DOITHONGTIN";
		this.DOITHONGTIN.Size = new System.Drawing.Size(248, 444);
		this.DOITHONGTIN.TabIndex = 0;
		this.DOITHONGTIN.TabStop = false;
		this.DOITHONGTIN.Text = "ĐỔI THÔNG TIN";
		this.tieusubanthan.AutoSize = true;
		this.tieusubanthan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.tieusubanthan.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.tieusubanthan.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.tieusubanthan.Location = new System.Drawing.Point(34, 306);
		this.tieusubanthan.Name = "tieusubanthan";
		this.tieusubanthan.Size = new System.Drawing.Size(109, 13);
		this.tieusubanthan.TabIndex = 39;
		this.tieusubanthan.TabStop = true;
		this.tieusubanthan.Text = "Tiểu Sử bản Thân";
		this.Quequan.AutoSize = true;
		this.Quequan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Quequan.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.Quequan.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.Quequan.Location = new System.Drawing.Point(35, 283);
		this.Quequan.Name = "Quequan";
		this.Quequan.Size = new System.Drawing.Size(64, 13);
		this.Quequan.TabIndex = 38;
		this.Quequan.TabStop = true;
		this.Quequan.Text = "Quê Quán";
		this.thanhphohientai.AutoSize = true;
		this.thanhphohientai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.thanhphohientai.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.thanhphohientai.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.thanhphohientai.Location = new System.Drawing.Point(34, 260);
		this.thanhphohientai.Name = "thanhphohientai";
		this.thanhphohientai.Size = new System.Drawing.Size(121, 13);
		this.thanhphohientai.TabIndex = 37;
		this.thanhphohientai.TabStop = true;
		this.thanhphohientai.Text = "Thành Phố Hiện Tại";
		this.Truonghoc.AutoSize = true;
		this.Truonghoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Truonghoc.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.Truonghoc.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.Truonghoc.Location = new System.Drawing.Point(36, 237);
		this.Truonghoc.Name = "Truonghoc";
		this.Truonghoc.Size = new System.Drawing.Size(74, 13);
		this.Truonghoc.TabIndex = 36;
		this.Truonghoc.TabStop = true;
		this.Truonghoc.Text = "Trường Học";
		this.Congviec.AutoSize = true;
		this.Congviec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Congviec.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.Congviec.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.Congviec.Location = new System.Drawing.Point(36, 214);
		this.Congviec.Name = "Congviec";
		this.Congviec.Size = new System.Drawing.Size(65, 13);
		this.Congviec.TabIndex = 35;
		this.Congviec.TabStop = true;
		this.Congviec.Text = "Công Viêc";
		this.Doiten.AutoSize = true;
		this.Doiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Doiten.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.Doiten.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.Doiten.Location = new System.Drawing.Point(36, 168);
		this.Doiten.Name = "Doiten";
		this.Doiten.Size = new System.Drawing.Size(48, 13);
		this.Doiten.TabIndex = 34;
		this.Doiten.TabStop = true;
		this.Doiten.Text = "Đỗi tên";
		this.ThemMailmoi.AutoSize = true;
		this.ThemMailmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.ThemMailmoi.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.ThemMailmoi.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.ThemMailmoi.Location = new System.Drawing.Point(36, 146);
		this.ThemMailmoi.Name = "ThemMailmoi";
		this.ThemMailmoi.Size = new System.Drawing.Size(89, 13);
		this.ThemMailmoi.TabIndex = 33;
		this.ThemMailmoi.TabStop = true;
		this.ThemMailmoi.Text = "Thêm Mail Mới";
		this.oUpcover.AutoSize = true;
		this.oUpcover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.oUpcover.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.oUpcover.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.oUpcover.Location = new System.Drawing.Point(36, 122);
		this.oUpcover.Name = "oUpcover";
		this.oUpcover.Size = new System.Drawing.Size(60, 13);
		this.oUpcover.TabIndex = 32;
		this.oUpcover.TabStop = true;
		this.oUpcover.Text = "Up Cover";
		this.lblDoiThongTin.AutoSize = true;
		this.lblDoiThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDoiThongTin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.lblDoiThongTin.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.lblDoiThongTin.Location = new System.Drawing.Point(36, 101);
		this.lblDoiThongTin.Name = "lblDoiThongTin";
		this.lblDoiThongTin.Size = new System.Drawing.Size(88, 13);
		this.lblDoiThongTin.TabIndex = 14;
		this.lblDoiThongTin.TabStop = true;
		this.lblDoiThongTin.Text = "Đỗi Thông Tin";
		this.lblDoiThongTin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lblDoiThongTin_LinkClicked);
		this.lblChangePass.AutoSize = true;
		this.lblChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChangePass.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		this.lblChangePass.LinkColor = System.Drawing.Color.LightSeaGreen;
		this.lblChangePass.Location = new System.Drawing.Point(36, 34);
		this.lblChangePass.Name = "lblChangePass";
		this.lblChangePass.Size = new System.Drawing.Size(82, 13);
		this.lblChangePass.TabIndex = 31;
		this.lblChangePass.TabStop = true;
		this.lblChangePass.Text = "Đổi mật khẩu";
		this.lblChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lblChangePass_LinkClicked);
		this.oXoathietbitincay.AutoSize = true;
		this.oXoathietbitincay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oXoathietbitincay.ForeColor = System.Drawing.Color.LightSeaGreen;
		this.oXoathietbitincay.Location = new System.Drawing.Point(19, 191);
		this.oXoathietbitincay.Name = "oXoathietbitincay";
		this.oXoathietbitincay.Size = new System.Drawing.Size(143, 17);
		this.oXoathietbitincay.TabIndex = 12;
		this.oXoathietbitincay.Text = "Xóa Thiết Bị Tin Cậy";
		this.oXoathietbitincay.UseVisualStyleBackColor = true;
		this.odoiten.AutoSize = true;
		this.odoiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.odoiten.ForeColor = System.Drawing.Color.RoyalBlue;
		this.odoiten.Location = new System.Drawing.Point(19, 168);
		this.odoiten.Name = "odoiten";
		this.odoiten.Size = new System.Drawing.Size(15, 14);
		this.odoiten.TabIndex = 11;
		this.odoiten.UseVisualStyleBackColor = true;
		this.oThemmailmoi.AutoSize = true;
		this.oThemmailmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oThemmailmoi.ForeColor = System.Drawing.Color.RoyalBlue;
		this.oThemmailmoi.Location = new System.Drawing.Point(19, 145);
		this.oThemmailmoi.Name = "oThemmailmoi";
		this.oThemmailmoi.Size = new System.Drawing.Size(15, 14);
		this.oThemmailmoi.TabIndex = 2;
		this.oThemmailmoi.UseVisualStyleBackColor = true;
		this.ocover.AutoSize = true;
		this.ocover.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.ocover.ForeColor = System.Drawing.Color.RoyalBlue;
		this.ocover.Location = new System.Drawing.Point(19, 122);
		this.ocover.Name = "ocover";
		this.ocover.Size = new System.Drawing.Size(15, 14);
		this.ocover.TabIndex = 10;
		this.ocover.UseVisualStyleBackColor = true;
		this.oavatar.AutoSize = true;
		this.oavatar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oavatar.ForeColor = System.Drawing.Color.RoyalBlue;
		this.oavatar.Location = new System.Drawing.Point(19, 101);
		this.oavatar.Name = "oavatar";
		this.oavatar.Size = new System.Drawing.Size(15, 14);
		this.oavatar.TabIndex = 9;
		this.oavatar.UseVisualStyleBackColor = true;
		this.oQuequan.AutoSize = true;
		this.oQuequan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oQuequan.ForeColor = System.Drawing.Color.RoyalBlue;
		this.oQuequan.Location = new System.Drawing.Point(19, 283);
		this.oQuequan.Name = "oQuequan";
		this.oQuequan.Size = new System.Drawing.Size(15, 14);
		this.oQuequan.TabIndex = 8;
		this.oQuequan.UseVisualStyleBackColor = true;
		this.othanhphohientai.AutoSize = true;
		this.othanhphohientai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.othanhphohientai.ForeColor = System.Drawing.Color.RoyalBlue;
		this.othanhphohientai.Location = new System.Drawing.Point(19, 260);
		this.othanhphohientai.Name = "othanhphohientai";
		this.othanhphohientai.Size = new System.Drawing.Size(15, 14);
		this.othanhphohientai.TabIndex = 7;
		this.othanhphohientai.UseVisualStyleBackColor = true;
		this.otruonghoc.AutoSize = true;
		this.otruonghoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.otruonghoc.ForeColor = System.Drawing.Color.RoyalBlue;
		this.otruonghoc.Location = new System.Drawing.Point(19, 237);
		this.otruonghoc.Name = "otruonghoc";
		this.otruonghoc.Size = new System.Drawing.Size(15, 14);
		this.otruonghoc.TabIndex = 6;
		this.otruonghoc.UseVisualStyleBackColor = true;
		this.oCongviec.AutoSize = true;
		this.oCongviec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oCongviec.ForeColor = System.Drawing.Color.RoyalBlue;
		this.oCongviec.Location = new System.Drawing.Point(19, 214);
		this.oCongviec.Name = "oCongviec";
		this.oCongviec.Size = new System.Drawing.Size(15, 14);
		this.oCongviec.TabIndex = 5;
		this.oCongviec.UseVisualStyleBackColor = true;
		this.otieusubanthan.AutoSize = true;
		this.otieusubanthan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.otieusubanthan.ForeColor = System.Drawing.Color.RoyalBlue;
		this.otieusubanthan.Location = new System.Drawing.Point(19, 306);
		this.otieusubanthan.Name = "otieusubanthan";
		this.otieusubanthan.Size = new System.Drawing.Size(15, 14);
		this.otieusubanthan.TabIndex = 4;
		this.otieusubanthan.UseVisualStyleBackColor = true;
		this.oBat2fa.AutoSize = true;
		this.oBat2fa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oBat2fa.ForeColor = System.Drawing.Color.LightSeaGreen;
		this.oBat2fa.Location = new System.Drawing.Point(19, 55);
		this.oBat2fa.Name = "oBat2fa";
		this.oBat2fa.Size = new System.Drawing.Size(71, 17);
		this.oBat2fa.TabIndex = 3;
		this.oBat2fa.Text = "Bật 2FA";
		this.oBat2fa.UseVisualStyleBackColor = true;
		this.oDangxuatthietbicu.AutoSize = true;
		this.oDangxuatthietbicu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oDangxuatthietbicu.ForeColor = System.Drawing.Color.LightSeaGreen;
		this.oDangxuatthietbicu.Location = new System.Drawing.Point(19, 77);
		this.oDangxuatthietbicu.Name = "oDangxuatthietbicu";
		this.oDangxuatthietbicu.Size = new System.Drawing.Size(153, 17);
		this.oDangxuatthietbicu.TabIndex = 1;
		this.oDangxuatthietbicu.Text = "Đăng Xuất Thiết Bị Cũ";
		this.oDangxuatthietbicu.UseVisualStyleBackColor = true;
		this.oDoimatkhau.AutoSize = true;
		this.oDoimatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oDoimatkhau.ForeColor = System.Drawing.Color.RoyalBlue;
		this.oDoimatkhau.Location = new System.Drawing.Point(19, 33);
		this.oDoimatkhau.Name = "oDoimatkhau";
		this.oDoimatkhau.Size = new System.Drawing.Size(15, 14);
		this.oDoimatkhau.TabIndex = 0;
		this.oDoimatkhau.UseVisualStyleBackColor = true;
		this.tabPage2.Controls.Add(this.groupBox5);
		this.tabPage2.Location = new System.Drawing.Point(4, 22);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(1248, 465);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Cấu hình Mail";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.groupBox5.AutoSize = true;
		this.groupBox5.BackColor = System.Drawing.Color.Gainsboro;
		this.groupBox5.Controls.Add(this.GmailSuperTeam1);
		this.groupBox5.Controls.Add(this.DongVanFB1);
		this.groupBox5.Controls.Add(this.HotmailBox1);
		this.groupBox5.Controls.Add(this.HotmailBox);
		this.groupBox5.Controls.Add(this.oTempmail);
		this.groupBox5.Controls.Add(this.oDongVanFb);
		this.groupBox5.Controls.Add(this.oGmailSuperXacNhan);
		this.groupBox5.Controls.Add(this.oHotmailBox);
		this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox5.ForeColor = System.Drawing.Color.Red;
		this.groupBox5.Location = new System.Drawing.Point(9, 6);
		this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.groupBox5.Size = new System.Drawing.Size(310, 444);
		this.groupBox5.TabIndex = 33;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "Cấu hình Veri";
		this.GmailSuperTeam1.AutoSize = true;
		this.GmailSuperTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.GmailSuperTeam1.Location = new System.Drawing.Point(24, 100);
		this.GmailSuperTeam1.Name = "GmailSuperTeam1";
		this.GmailSuperTeam1.Size = new System.Drawing.Size(106, 13);
		this.GmailSuperTeam1.TabIndex = 43;
		this.GmailSuperTeam1.TabStop = true;
		this.GmailSuperTeam1.Text = "Gmail SuperTeam";
		this.DongVanFB1.AutoSize = true;
		this.DongVanFB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.DongVanFB1.Location = new System.Drawing.Point(24, 79);
		this.DongVanFB1.Name = "DongVanFB1";
		this.DongVanFB1.Size = new System.Drawing.Size(74, 13);
		this.DongVanFB1.TabIndex = 42;
		this.DongVanFB1.TabStop = true;
		this.DongVanFB1.Text = "DongVanFB";
		this.HotmailBox1.AutoSize = true;
		this.HotmailBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.HotmailBox1.Location = new System.Drawing.Point(24, 55);
		this.HotmailBox1.Name = "HotmailBox1";
		this.HotmailBox1.Size = new System.Drawing.Size(70, 13);
		this.HotmailBox1.TabIndex = 41;
		this.HotmailBox1.TabStop = true;
		this.HotmailBox1.Text = "HotmailBox";
		this.HotmailBox.AutoSize = true;
		this.HotmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.HotmailBox.Location = new System.Drawing.Point(23, 31);
		this.HotmailBox.Name = "HotmailBox";
		this.HotmailBox.Size = new System.Drawing.Size(60, 13);
		this.HotmailBox.TabIndex = 40;
		this.HotmailBox.TabStop = true;
		this.HotmailBox.Text = "Tempmail";
		this.oTempmail.AutoSize = true;
		this.oTempmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oTempmail.ForeColor = System.Drawing.SystemColors.WindowText;
		this.oTempmail.Location = new System.Drawing.Point(8, 32);
		this.oTempmail.Name = "oTempmail";
		this.oTempmail.Size = new System.Drawing.Size(14, 13);
		this.oTempmail.TabIndex = 4;
		this.oTempmail.TabStop = true;
		this.oTempmail.UseVisualStyleBackColor = true;
		this.oDongVanFb.AutoSize = true;
		this.oDongVanFb.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oDongVanFb.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oDongVanFb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oDongVanFb.Location = new System.Drawing.Point(8, 79);
		this.oDongVanFb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oDongVanFb.Name = "oDongVanFb";
		this.oDongVanFb.Size = new System.Drawing.Size(24, 13);
		this.oDongVanFb.TabIndex = 2;
		this.oDongVanFb.TabStop = true;
		this.oDongVanFb.UseVisualStyleBackColor = true;
		this.oGmailSuperXacNhan.AutoSize = true;
		this.oGmailSuperXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oGmailSuperXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oGmailSuperXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oGmailSuperXacNhan.Location = new System.Drawing.Point(8, 101);
		this.oGmailSuperXacNhan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oGmailSuperXacNhan.Name = "oGmailSuperXacNhan";
		this.oGmailSuperXacNhan.Size = new System.Drawing.Size(24, 13);
		this.oGmailSuperXacNhan.TabIndex = 2;
		this.oGmailSuperXacNhan.TabStop = true;
		this.oGmailSuperXacNhan.UseVisualStyleBackColor = true;
		this.oHotmailBox.AutoSize = true;
		this.oHotmailBox.Cursor = System.Windows.Forms.Cursors.Hand;
		this.oHotmailBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.oHotmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
		this.oHotmailBox.Location = new System.Drawing.Point(8, 55);
		this.oHotmailBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.oHotmailBox.Name = "oHotmailBox";
		this.oHotmailBox.Size = new System.Drawing.Size(24, 13);
		this.oHotmailBox.TabIndex = 2;
		this.oHotmailBox.TabStop = true;
		this.oHotmailBox.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1256, 491);
		base.Controls.Add(this.tabControl1);
		base.Name = "FormCauHinhChangeInfor";
		this.Text = "FormCauHinhChangeInfor";
		base.Load += new System.EventHandler(FormCauHinhChangeInfor_Load);
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.DOITHONGTIN.ResumeLayout(false);
		this.DOITHONGTIN.PerformLayout();
		this.tabPage2.ResumeLayout(false);
		this.tabPage2.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		base.ResumeLayout(false);
	}
}
