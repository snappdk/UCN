﻿using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Alert.Core.ViewModels;


namespace Alert.Droid.Views
{
	[Activity (Label = "View for FirstViewModel")]
	public class FirstView : MvxActivity<FirstViewModel>
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.FirstView);
		}
	}
}
