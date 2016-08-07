using MvvmCross.Platform.IoC;
using Alert.Core.ViewModels;
using MvvmCross.Platform;

namespace Alert.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize ()
		{
			CreatableTypes ()
				.EndingWith ("Service")
				.AsInterfaces ()
				.RegisterAsLazySingleton ();


			RegisterAppStart<FirstViewModel> ();
		}
	}
}
