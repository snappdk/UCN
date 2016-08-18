using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using PictureSaver.Core;
using MvvmCross.Platform;
using PictureSaver.Core.Services;
using PictureSaver.Droid.Services;
using MvvmCross.Platform.Plugins;

namespace PictureSaver.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.DownloadCache.PluginLoader.Instance.EnsureLoaded();

            Mvx.RegisterType<ILocalStorageService>(() => new LocalStorageService());
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.Register<MvvmCross.Plugins.DownloadCache.PluginLoader, MvvmCross.Plugins.DownloadCache.Droid.Plugin>();
            registry.Register<MvvmCross.Plugins.File.PluginLoader, MvvmCross.Plugins.File.Droid.Plugin>();
            base.AddPluginsLoaders(registry);
        }

    }
}
