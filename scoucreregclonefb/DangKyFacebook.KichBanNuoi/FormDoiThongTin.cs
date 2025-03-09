using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DangKyFacebook.KichBanNuoi;

public class FormDoiThongTin : Form
{
	private IContainer components = null;

	public FormDoiThongTin()
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
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Name = "FormDoiThongTin";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "FormDoiThongTin";
		base.ResumeLayout(false);
	}
}
