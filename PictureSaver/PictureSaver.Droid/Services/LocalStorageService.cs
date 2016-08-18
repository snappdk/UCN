
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using Android.OS;
using MvvmCross.Platform;
using PictureSaver.Core.Services;
using MvvmCross.Platform.Droid.Platform;

namespace PictureSaver.Droid.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        public async Task<string> SavePictureAsync(Stream stream, string filename)
        {
            var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();

            var dir = activity.Activity.FilesDir.Path;


            //var dir =
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

