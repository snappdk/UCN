using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;
using HelloWorld.Core.Services;
using HelloWorld.Droid.Services;

namespace HelloWorld.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();

        }
        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.Register<MvvmCross.Plugins.DownloadCache.PluginLoader, MvvmCross.Plugins.DownloadCache.Droid.Plugin>();
            registry.Register<MvvmCross.Plugins.File.PluginLoader, MvvmCross.Plugins.File.Droid.Plugin>();

            base.AddPluginsLoaders(registry);
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.DownloadCache.PluginLoader.Instance.EnsureLoaded();

            Mvx.RegisterSingleton<IAlertService>(Mvx.IocConstruct<AlertService>());
            Mvx.RegisterSingleton<ILocalStorageService>(Mvx.IocConstruct<LocalStorageService>());
        }
    }
}
