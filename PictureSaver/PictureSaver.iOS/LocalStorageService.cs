using System;
using System.IO;
using System.Threading.Tasks;
using PictureSaver.Core.Services;
namespace PictureSaver.iOS
{
    public class LocalStorageService : ILocalStorageService
    {
        public LocalStorageService()
        {
        }

        public async Task<string> SavePictureAsync(Stream stream, string filename)
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

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

