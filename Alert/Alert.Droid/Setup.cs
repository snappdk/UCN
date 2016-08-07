using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Alert.Core;
using MvvmCross.Platform;

namespace Alert.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup (Context applicationContext) : base (applicationContext)
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
			Mvx.RegisterSingleton<INativeAlert> (new NativeAndroidAlert ());
		}
	}
}
