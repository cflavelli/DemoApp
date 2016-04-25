using System;
using System.Collections.Generic;
using System.Linq;

using CustomControls;

using FFImageLoading.Forms.Touch;

using Foundation;

using UIKit;

using Xamarin.Forms;

namespace DemoApp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			CachedImageRenderer.Init ();

			global::Xamarin.Forms.Forms.Init ();

			#if GORILLA

			LoadApplication(
				UXDivers.Artina.Player.iOS.Player.CreateApplication(
					new UXDivers.Artina.Player.Config("Gorilla!")
				)
			);
				
			InfiniteListView a = new InfiniteListView();

			#else

			LoadApplication (new App ());

			#endif

			return base.FinishedLaunching (app, options);
		}
	}
}

