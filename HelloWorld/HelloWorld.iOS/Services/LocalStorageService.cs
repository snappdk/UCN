using System;
using System.IO;
using System.Threading.Tasks;
using HelloWorld.Core.Services;
namespace HelloWorld.iOS.Services
{
    public class LocalStorageService : ILocalStorageService
    {

        public async Task<string> SaveAsync(string filename, Stream stream)
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

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

