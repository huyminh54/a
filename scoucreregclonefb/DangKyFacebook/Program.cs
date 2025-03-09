using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DeviceId;

namespace DangKyFacebook;

internal static class Program
{
	private static string text;

	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new applite());
	}

	private static void check()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		string text = "https://docs.google.com/spreadsheets/d/1zfPJVRmDgEWPVhwcDfgvbVpRTyHzJySf6jSpeuEAebM/edit?gid=0#gid=0";
		HttpClient val = new HttpClient();
		try
		{
			HttpResponseMessage result = val.GetAsync(text).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (result2 != "" && result2.Contains(Program.text))
				{
					Application.Run(new applite());
					return;
				}
				MessageBox.Show("Chưa mua key");
				Clipboard.SetText(Program.text);
				Environment.Exit(0);
			}
			else
			{
				MessageBox.Show("Lỗi key");
				Clipboard.SetText(Program.text);
				Environment.Exit(0);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static string Md5Encode(string string_0)
	{
		HashAlgorithm hashAlgorithm = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(string_0);
		byte[] array = hashAlgorithm.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("X2"));
		}
		return stringBuilder.ToString();
	}

	static Program()
	{
		text = Md5Encode(new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
			.AddSystemDriveSerialNumber()
			.ToString());
	}
}
