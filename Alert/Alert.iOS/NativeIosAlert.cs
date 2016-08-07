using System;
using Alert.Core;
using UIKit;
namespace Alert.iOS
{
	public class NativeIosAlert : INativeAlert
	{
		public NativeIosAlert ()
		{
		}

		public void ShowAlert (string title, string description)
		{
			var alert = new UIAlertView (title, description, null, "Ok");
			alert.Show ();
		}
	}
}

