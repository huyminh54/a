using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DangKyFacebook.KichBanNuoi;

public class FormDoiMatKhau : Form
{
	private IContainer components = null;

	private RadioButton radioButton1;

	private RadioButton radioButton2;

	private RadioButton radioButton3;

	private TextBox textBox1;

	private TextBox textBox2;

	private CheckBox checkBox1;

	public FormDoiMatKhau()
	{
		InitializeComponent();
	}

	private void FormDoiMatKhau_Load(object sender, EventArgs e)
	{
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
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		base.SuspendLayout();
		this.radioButton1.AutoSize = true;
		this.radioButton1.Location = new System.Drawing.Point(13, 10);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(80, 17);
		this.radioButton1.TabIndex = 0;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "Ngẫu nhiên";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(13, 33);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(70, 17);
		this.radioButton2.TabIndex = 0;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "Mặc định";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton3.AutoSize = true;
		this.radioButton3.Location = new System.Drawing.Point(13, 56);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(77, 17);
		this.radioButton3.TabIndex = 0;
		this.radioButton3.TabStop = true;
		this.radioButton3.Text = "Danh sách";
		this.radioButton3.UseVisualStyleBackColor = true;
		this.textBox1.Location = new System.Drawing.Point(90, 33);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(203, 20);
		this.textBox1.TabIndex = 1;
		this.textBox2.Location = new System.Drawing.Point(90, 60);
		this.textBox2.Multiline = true;
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(203, 166);
		this.textBox2.TabIndex = 2;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(90, 232);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(74, 17);
		this.checkBox1.TabIndex = 3;
		this.checkBox1.Text = "Đá thiết bị";
		this.checkBox1.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(305, 257);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.radioButton3);
		base.Controls.Add(this.radioButton2);
		base.Controls.Add(this.radioButton1);
		base.Name = "FormDoiMatKhau";
		this.Text = "Đổi mật khâu";
		base.Load += new System.EventHandler(FormDoiMatKhau_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
