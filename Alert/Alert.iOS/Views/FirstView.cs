using System;
using Foundation;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Alert.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace Alert.iOS.Views
{
	public partial class FirstView : MvxViewController<FirstViewModel>
	{
		public FirstView () : base (nameof (FirstView), null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var set = this.CreateBindingSet<FirstView, FirstViewModel> ();
			set.Bind (TextLabel).To (vm => vm.Hello);
			set.Bind (InputField).To (vm => vm.Hello);
			set.Bind (AlertButton).To (vm => vm.ShowAlertCommand);
			set.Apply ();
		}
	}
}



