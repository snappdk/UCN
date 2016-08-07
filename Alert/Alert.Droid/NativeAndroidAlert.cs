using System;
using Alert.Core;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace Alert.Droid
{
	public class NativeAndroidAlert : INativeAlert
	{
		public NativeAndroidAlert ()
		{
		}

		public void ShowAlert (string title, string description)
		{
			var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity> ();

			var alert = new AlertDialog.Builder (topActivity.Activity);
			alert.SetTitle (title);
			alert.SetMessage (description);
			alert.SetNeutralButton ("Ok", (sender, e) => { });
			alert.Show ();
		}
	}
}

