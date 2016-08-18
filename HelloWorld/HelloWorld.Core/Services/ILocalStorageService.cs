using System;
using System.Threading.Tasks;
using System.IO;
namespace HelloWorld.Core.Services
{
    public interface ILocalStorageService
    {
        Task<string> SaveAsync(string filename, Stream stream);
    }
}

