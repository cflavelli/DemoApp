using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using CustomControls;

using FFImageLoading.Forms.Droid;

namespace DemoApp.Droid
{
	[Activity (Label = "DemoApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			CachedImageRenderer.Init ();

			global::Xamarin.Forms.Forms.Init (this, bundle);

			#if GORILLA
		
			LoadApplication(
				UXDivers.Artina.Player.Droid.Player.CreateApplication (
					ApplicationContext, new UXDivers.Artina.Player.Config("Gorilla!"))
			);
				
			InfiniteListView a = new InfiniteListView();

			#else

			LoadApplication(new App ());

			#endif
		}
	}
}

