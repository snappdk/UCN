// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace PictureSaver.iOS.Views
{
	[Register ("MainView")]
	partial class MainView
	{
		[Outlet]
		UIKit.UITableView TableView { get; set; }

		[Outlet]
		UIKit.UIImageView TestImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}

			if (TestImage != null) {
				TestImage.Dispose ();
				TestImage = null;
			}
		}
	}
}
