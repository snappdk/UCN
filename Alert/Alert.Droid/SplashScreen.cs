using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Alert.Droid
{
	[Activity (
		Label = "Alert"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity
	{
		public SplashScreen ()
			: base (Resource.Layout.SplashScreen)
		{
		}
	}
}
