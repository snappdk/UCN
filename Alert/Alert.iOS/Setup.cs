using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform.Platform;
using Alert.Core;
using UIKit;
using MvvmCross.Platform;

namespace Alert.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup (MvxApplicationDelegate applicationDelegate, UIWindow window) : base (applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new App ();
		}

		protected override IMvxTrace CreateDebugTrace ()
		{
			return new DebugTrace ();
		}

		protected override void InitializeLastChance ()
		{
			base.InitializeLastChance ();

			Mvx.RegisterSingleton<INativeAlert> (new NativeIosAlert ());
		}
	}
}
