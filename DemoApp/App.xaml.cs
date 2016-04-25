using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DemoApp
{
	public partial class App : Application
	{
		public App ()
		{

			CustomControls.InfiniteListView a = new CustomControls.InfiniteListView ();

			MainPage = new MyListPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

