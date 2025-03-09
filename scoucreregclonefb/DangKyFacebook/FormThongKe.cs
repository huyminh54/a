using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ThuVienAndroid.Model;

namespace DangKyFacebook;

public class FormThongKe : Form
{
	private bool _autoRefresh;

	private IContainer components = null;

	private DataGridView dtgStatistic;

	private Label label1;

	private Button btnRefresh;

	private CheckBox cboAutoRefresh;

	private Label label2;

	private Label lblLive;

	private Label lblDie;

	private DataGridViewTextBoxColumn STT;

	private DataGridViewTextBoxColumn DeviceId;

	private DataGridViewTextBoxColumn Gmail;

	private DataGridViewTextBoxColumn Live;

	private DataGridViewTextBoxColumn Die;

	private DataGridViewTextBoxColumn Total;

	private Panel panel1;

	private Panel panel2;

	private Panel panel3;

	public FormThongKe()
	{
		InitializeComponent();
	}

	private void FormThongKe_Load(object sender, EventArgs e)
	{
		Refresh();
	}

	public new void Refresh()
	{
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				while (true)
				{
					Invoke((Action)delegate
					{
						int num = 0;
						dtgStatistic.Rows.Clear();
						foreach (CheckDieAccModel current in applite._danhsachthietbi)
						{
							decimal num2 = current.TongAccLive + current.TongAccDie;
							dtgStatistic.Rows.Add();
							dtgStatistic.Rows[num].Cells["STT"].Value = num + 1;
							dtgStatistic.Rows[num].Cells["Gmail"].Value = current.TongAccGmail;
							dtgStatistic.Rows[num].Cells["DeviceId"].Value = "NTD " + current.MaMay.Substring(current.MaMay.Length - 5, 5);
							dtgStatistic.Rows[num].Cells["Live"].Value = ((num2 < 1m) ? "0" : $"{current.TongAccLive}   -   ({Math.Round((decimal)current.TongAccLive / num2 * 100m, 1)}%)");
							dtgStatistic.Rows[num].Cells["Die"].Value = ((num2 < 1m) ? "0" : $"{current.TongAccDie}   -   ({Math.Round((decimal)current.TongAccDie / num2 * 100m, 1)}%)");
							dtgStatistic.Rows[num].Cells["Total"].Value = num2;
							num++;
						}
						GetTotal();
					});
					if (!_autoRefresh)
					{
						break;
					}
					for (int num3 = 5; num3 > 0; num3--)
					{
						int time1 = num3;
						Invoke((Action)delegate
						{
							btnRefresh.Text = $"Refresh sau {time1}s";
						});
						Thread.Sleep(1000);
					}
					Invoke((Action)delegate
					{
						btnRefresh.Text = "Loading...";
					});
				}
				Invoke((Action)delegate
				{
					btnRefresh.Text = "Refresh";
					btnRefresh.Enabled = true;
				});
			}
			catch (Exception)
			{
			}
		})
		{
			IsBackground = true
		};
		thread.Start();
	}

	public void GetTotal()
	{
		Invoke((Action)delegate
		{
			List<CheckDieAccModel> danhsachthietbi = applite._danhsachthietbi;
			int num = danhsachthietbi.Sum((CheckDieAccModel x) => x.TongAccLive);
			int num2 = danhsachthietbi.Sum((CheckDieAccModel x) => x.TongAccDie);
			decimal num3 = num + num2;
			lblLive.Text = ((num3 > 0m) ? $"{num} - {Math.Round((decimal)num / num3 * 100m, 1)}%" : "0 - 0%");
			lblDie.Text = ((num3 > 0m) ? $"{num2} - {Math.Round((decimal)num2 / num3 * 100m, 1)}%" : "0 - 0%");
		});
	}

	private void btnRefresh_Click(object sender, EventArgs e)
	{
		if (!_autoRefresh)
		{
			Refresh();
		}
	}

	private void cboAutoRefresh_CheckedChanged(object sender, EventArgs e)
	{
		_autoRefresh = !_autoRefresh;
		if (_autoRefresh)
		{
			Refresh();
			btnRefresh.Enabled = false;
		}
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
		this.dtgStatistic = new System.Windows.Forms.DataGridView();
		this.label1 = new System.Windows.Forms.Label();
		this.btnRefresh = new System.Windows.Forms.Button();
		this.cboAutoRefresh = new System.Windows.Forms.CheckBox();
		this.label2 = new System.Windows.Forms.Label();
		this.lblLive = new System.Windows.Forms.Label();
		this.lblDie = new System.Windows.Forms.Label();
		this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DeviceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Gmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Live = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Die = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.panel1 = new System.Windows.Forms.Panel();
		this.panel2 = new System.Windows.Forms.Panel();
		this.panel3 = new System.Windows.Forms.Panel();
		((System.ComponentModel.ISupportInitialize)this.dtgStatistic).BeginInit();
		this.panel1.SuspendLayout();
		this.panel2.SuspendLayout();
		this.panel3.SuspendLayout();
		base.SuspendLayout();
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dtgStatistic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dtgStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dtgStatistic.Columns.AddRange(this.STT, this.DeviceId, this.Gmail, this.Live, this.Die, this.Total);
		this.dtgStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dtgStatistic.Location = new System.Drawing.Point(0, 0);
		this.dtgStatistic.Name = "dtgStatistic";
		this.dtgStatistic.Size = new System.Drawing.Size(478, 465);
		this.dtgStatistic.TabIndex = 0;
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Orange;
		this.label1.Location = new System.Drawing.Point(70, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(329, 20);
		this.label1.TabIndex = 1;
		this.label1.Text = "Thống kê tài khoản clone theo từng máy";
		this.btnRefresh.BackColor = System.Drawing.Color.MediumTurquoise;
		this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnRefresh.ForeColor = System.Drawing.Color.Azure;
		this.btnRefresh.Location = new System.Drawing.Point(0, 76);
		this.btnRefresh.Name = "btnRefresh";
		this.btnRefresh.Size = new System.Drawing.Size(478, 49);
		this.btnRefresh.TabIndex = 2;
		this.btnRefresh.Text = "Refresh";
		this.btnRefresh.UseVisualStyleBackColor = false;
		this.btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
		this.cboAutoRefresh.AutoSize = true;
		this.cboAutoRefresh.Location = new System.Drawing.Point(12, 14);
		this.cboAutoRefresh.Name = "cboAutoRefresh";
		this.cboAutoRefresh.Size = new System.Drawing.Size(102, 17);
		this.cboAutoRefresh.TabIndex = 3;
		this.cboAutoRefresh.Text = "Tự động refresh";
		this.cboAutoRefresh.UseVisualStyleBackColor = true;
		this.cboAutoRefresh.CheckedChanged += new System.EventHandler(cboAutoRefresh_CheckedChanged);
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
		this.label2.Location = new System.Drawing.Point(290, 14);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(54, 20);
		this.label2.TabIndex = 4;
		this.label2.Text = "Tổng:";
		this.lblLive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblLive.AutoSize = true;
		this.lblLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblLive.ForeColor = System.Drawing.Color.LimeGreen;
		this.lblLive.Location = new System.Drawing.Point(370, 14);
		this.lblLive.Name = "lblLive";
		this.lblLive.Size = new System.Drawing.Size(59, 20);
		this.lblLive.TabIndex = 4;
		this.lblLive.Text = "lblLive";
		this.lblDie.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblDie.AutoSize = true;
		this.lblDie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDie.ForeColor = System.Drawing.Color.Red;
		this.lblDie.Location = new System.Drawing.Point(370, 44);
		this.lblDie.Name = "lblDie";
		this.lblDie.Size = new System.Drawing.Size(54, 20);
		this.lblDie.TabIndex = 4;
		this.lblDie.Text = "lblDie";
		this.STT.HeaderText = "STT";
		this.STT.Name = "STT";
		this.STT.ReadOnly = true;
		this.STT.Width = 50;
		this.DeviceId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.DeviceId.HeaderText = "Mã Máy";
		this.DeviceId.Name = "DeviceId";
		this.DeviceId.ReadOnly = true;
		this.Gmail.HeaderText = "Gmail";
		this.Gmail.Name = "Gmail";
		this.Gmail.ReadOnly = true;
		this.Gmail.Width = 60;
		this.Live.HeaderText = "Live";
		this.Live.Name = "Live";
		this.Live.ReadOnly = true;
		this.Live.Width = 85;
		this.Die.HeaderText = "Die";
		this.Die.Name = "Die";
		this.Die.ReadOnly = true;
		this.Die.Width = 85;
		this.Total.HeaderText = "Total";
		this.Total.Name = "Total";
		this.Total.ReadOnly = true;
		this.Total.Width = 50;
		this.panel1.Controls.Add(this.lblLive);
		this.panel1.Controls.Add(this.lblDie);
		this.panel1.Controls.Add(this.btnRefresh);
		this.panel1.Controls.Add(this.cboAutoRefresh);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 505);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(478, 125);
		this.panel1.TabIndex = 5;
		this.panel2.Controls.Add(this.label1);
		this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel2.Location = new System.Drawing.Point(0, 0);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(478, 40);
		this.panel2.TabIndex = 6;
		this.panel3.Controls.Add(this.dtgStatistic);
		this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel3.Location = new System.Drawing.Point(0, 40);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(478, 465);
		this.panel3.TabIndex = 7;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(478, 630);
		base.Controls.Add(this.panel3);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.panel1);
		this.MinimumSize = new System.Drawing.Size(494, 669);
		base.Name = "FormThongKe";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Thống kê tài khoản";
		base.Load += new System.EventHandler(FormThongKe_Load);
		((System.ComponentModel.ISupportInitialize)this.dtgStatistic).EndInit();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		this.panel3.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
