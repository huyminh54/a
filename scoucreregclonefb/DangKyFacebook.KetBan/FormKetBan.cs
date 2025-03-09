using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DangKyFacebook.KetBan;

public class FormKetBan : Form
{
	private IContainer components = null;

	private Label label1;

	private NumericUpDown numericUpDown1;

	private NumericUpDown numericUpDown2;

	private Label label2;

	private NumericUpDown numericUpDown3;

	private NumericUpDown numericUpDown4;

	private Button btnSave;

	public FormKetBan()
	{
		InitializeComponent();
	}

	private void FormKetBan_Load(object sender, EventArgs e)
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
		this.label1 = new System.Windows.Forms.Label();
		this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
		this.label2 = new System.Windows.Forms.Label();
		this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
		this.btnSave = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown4).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(14, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(52, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Số lượng:";
		this.numericUpDown1.Location = new System.Drawing.Point(72, 13);
		this.numericUpDown1.Name = "numericUpDown1";
		this.numericUpDown1.Size = new System.Drawing.Size(68, 20);
		this.numericUpDown1.TabIndex = 1;
		this.numericUpDown2.Location = new System.Drawing.Point(146, 13);
		this.numericUpDown2.Name = "numericUpDown2";
		this.numericUpDown2.Size = new System.Drawing.Size(68, 20);
		this.numericUpDown2.TabIndex = 1;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(37, 41);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(29, 13);
		this.label2.TabIndex = 0;
		this.label2.Text = "Chờ:";
		this.numericUpDown3.Location = new System.Drawing.Point(72, 39);
		this.numericUpDown3.Name = "numericUpDown3";
		this.numericUpDown3.Size = new System.Drawing.Size(68, 20);
		this.numericUpDown3.TabIndex = 1;
		this.numericUpDown4.Location = new System.Drawing.Point(146, 39);
		this.numericUpDown4.Name = "numericUpDown4";
		this.numericUpDown4.Size = new System.Drawing.Size(68, 20);
		this.numericUpDown4.TabIndex = 1;
		this.btnSave.Location = new System.Drawing.Point(72, 65);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(142, 23);
		this.btnSave.TabIndex = 2;
		this.btnSave.Text = "Lưu";
		this.btnSave.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(226, 96);
		base.Controls.Add(this.btnSave);
		base.Controls.Add(this.numericUpDown4);
		base.Controls.Add(this.numericUpDown3);
		base.Controls.Add(this.numericUpDown2);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.numericUpDown1);
		base.Controls.Add(this.label1);
		base.Name = "FormKetBan";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "FormKetBan";
		base.Load += new System.EventHandler(FormKetBan_Load);
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown4).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
