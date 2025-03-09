using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DangKyFacebook.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = (resourceMan = new ResourceManager("DangKyFacebook.Properties.Resources", typeof(Resources).Assembly));
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap _1
	{
		get
		{
			object @object = ResourceManager.GetObject("1", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap _48791_play_player_icon
	{
		get
		{
			object @object = ResourceManager.GetObject("48791_play_player_icon", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap NutPlay
	{
		get
		{
			object @object = ResourceManager.GetObject("NutPlay", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal Resources()
	{
	}
}
