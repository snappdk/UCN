using System;
using System.IO;
using System.Threading.Tasks;
using HelloWorld.Core.Services;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace HelloWorld.Droid.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        public async Task<string> SaveAsync(string filename, Stream stream)
        {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var dir = topActivity.Activity.FilesDir.Path;

            string path = Path.Combine(dir, filename);

            using (FileStream s = File.OpenWrite(path))
            {
                stream.Position = 0;
                await stream.CopyToAsync(s);
                s.Close();
            }

            return path;
        }
    }
}

