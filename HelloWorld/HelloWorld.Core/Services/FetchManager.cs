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
    public interface IFetchManager
    {
        Task<List<Photo>> GetPhotos();
        Task<Photo> GetPhoto(int id);
    }

    public class FetchManager : IFetchManager
    {
        List<Photo> _hackList;

        public async Task<List<Photo>> GetPhotos()
        {
            var webservice = new HttpClient();
            var result = await webservice.GetAsync("http://jsonplaceholder.typicode.com/photos?_start=0&_end=30");
            var content = await result.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Photo>>(content);

            _hackList = list;

            return list;
        }

        public Task<Photo> GetPhoto(int id)
        {
            var photo = _hackList.FirstOrDefault((arg) => arg.Id.Equals(id));

            return Task.Run(() => photo);
        }
    }
}
