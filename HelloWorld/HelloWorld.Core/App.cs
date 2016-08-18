using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using HelloWorld.Core.Services;

namespace HelloWorld.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IFetchManager>(new FetchManager());

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
