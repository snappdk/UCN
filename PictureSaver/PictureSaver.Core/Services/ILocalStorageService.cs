using System;
using System.Threading.Tasks;
using System.IO;
namespace PictureSaver.Core.Services
{
    public interface ILocalStorageService
    {
        Task<string> SavePictureAsync(Stream stream, string filename);
    }
}

