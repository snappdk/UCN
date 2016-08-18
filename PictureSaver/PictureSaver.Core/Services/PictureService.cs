using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PictureSaver.Core.Models;
using System.Linq;

namespace PictureSaver.Core.Services
{
    public interface IPictureService
    {
        Task<List<PictureDetail>> GetPictures();
        Task<PictureDetail> GetPicture(Guid id);

    }

    public class PictureService : IPictureService
    {
        private List<PictureDetail> _all;

        public PictureService()
        {

            _all = GenerateDummyData();

        }

        public Task<List<PictureDetail>> GetPictures()
        {
            return Task.Run(() => _all);
        }

        public Task<PictureDetail> GetPicture(Guid id)
        {
            return Task.Run(() => _all.FirstOrDefault((p) => p.Id.Equals(id)));
        }

        private List<PictureDetail> GenerateDummyData()
        {
            var tmpList = new List<PictureDetail>();

            tmpList.Add(new PictureDetail() { Title = "Picture #1", Id = Guid.NewGuid() });
            tmpList.Add(new PictureDetail() { Title = "Picture #2", Id = Guid.NewGuid() });
            tmpList.Add(new PictureDetail() { Title = "Picture #3", Id = Guid.NewGuid() });
            tmpList.Add(new PictureDetail() { Title = "Picture #4", Id = Guid.NewGuid() });
            tmpList.Add(new PictureDetail() { Title = "Picture #5", Id = Guid.NewGuid() });

            return tmpList;
        }

    }
}


