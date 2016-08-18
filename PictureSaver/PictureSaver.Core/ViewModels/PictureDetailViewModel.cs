using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using PictureSaver.Core.Models;
using PictureSaver.Core.Services;

namespace PictureSaver.Core.ViewModels
{
    public class PictureDetailViewModel : MvxViewModel
    {
        private Guid _pictureGuid;

        readonly IPictureService _pictureService;

        public PictureDetailViewModel(IPictureService pictureService)
        {
            this._pictureService = pictureService;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            string id;
            if (parameters.Data.TryGetValue("id", out id))
            {
                _pictureGuid = Guid.Parse(id);
            }
        }

        public override async void Start()
        {
            base.Start();

            CurrentPicture = await _pictureService.GetPicture(_pictureGuid);
        }

        public string Title
        {
            get { return CurrentPicture.Title; }
        }


        private PictureDetail _currentPicture;
        public PictureDetail CurrentPicture
        {
            get { return _currentPicture; }
            set
            {
                _currentPicture = value;

                RaisePropertyChanged(() => Title);
                RaisePropertyChanged(() => CurrentPicture);
            }
        }

    }
}
