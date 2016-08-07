using HelloWorld.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Core.Services
{
    public interface IPlaceholderService
    {
        Task<List<Photo>> GetPhotos();
    }

    public class PlaceholderService : IPlaceholderService
    {
        public async Task<List<Photo>> GetPhotos()
        {
            var webservice = new HttpClient();
            var result = await webservice.GetAsync("http://jsonplaceholder.typicode.com/photos?_start=0&_end=30");
            var content = await result.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Photo>>(content);

            return list;
        }
    }
}
