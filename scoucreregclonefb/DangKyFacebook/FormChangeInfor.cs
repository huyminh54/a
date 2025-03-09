using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DangKyFacebook;

public class FormChangeInfor : Form
{
	private IContainer components = null;

	private DataGridView dataGridView1;

	private Button btnStart;

	private Button button2;

	private Button button3;

	public FormChangeInfor()
	{
		InitializeComponent();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKyFacebook.FormChangeInfor));
		this.dataGridView1 = new System.Windows.Forms.DataGridView();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.btnStart = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
		base.SuspendLayout();
		this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView1.Location = new System.Drawing.Point(12, 141);
		this.dataGridView1.Name = "dataGridView1";
		this.dataGridView1.Size = new System.Drawing.Size(1328, 492);
		this.dataGridView1.TabIndex = 0;
		this.button2.Location = new System.Drawing.Point(180, 6);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(162, 43);
		this.button2.TabIndex = 2;
		this.button2.Text = "button2";
		this.button2.UseVisualStyleBackColor = true;
		this.button3.Location = new System.Drawing.Point(348, 6);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(162, 43);
		this.button3.TabIndex = 3;
		this.button3.Text = "button3";
		this.button3.UseVisualStyleBackColor = true;
		this.btnStart.BackColor = System.Drawing.Color.White;
		this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnStart.ForeColor = System.Drawing.Color.LightSeaGreen;
		this.btnStart.Image = (System.Drawing.Image)resources.GetObject("btnStart.Image");
		this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnStart.Location = new System.Drawing.Point(12, 6);
		this.btnStart.Name = "btnStart";
		this.btnStart.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
		this.btnStart.Size = new System.Drawing.Size(162, 43);
		this.btnStart.TabIndex = 1;
		this.btnStart.Text = "Bắt đầu";
		this.btnStart.UseVisualStyleBackColor = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1051, 643);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.btnStart);
		base.Controls.Add(this.dataGridView1);
		base.Name = "FormChangeInfor";
		this.Text = "FormChangeInfor";
		((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
		base.ResumeLayout(false);
	}
}
