using MvvmCross.Platform.IoC;
using PictureSaver.Core.ViewModels;
using MvvmCross.Platform;

namespace PictureSaver.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize ()
		{
			CreatableTypes ()
				.EndingWith ("Service")
				.AsInterfaces ()
				.RegisterAsLazySingleton ();


			RegisterAppStart<MainViewModel> ();
		}
	}
}
