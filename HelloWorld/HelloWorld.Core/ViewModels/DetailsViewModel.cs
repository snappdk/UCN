using System;
using MvvmCross.Core.ViewModels;
using HelloWorld.Core.Services;
using HelloWorld.Core.Models;

namespace HelloWorld.Core.ViewModels
{
    public class DetailsViewModel : MvxViewModel
    {
        private int _id;
        private IFetchManager _fetchManager;

        public DetailsViewModel(IFetchManager fetchManager)
        {
            _fetchManager = fetchManager;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            string id;
            if (parameters.Data.TryGetValue("Id", out id))
            {
                _id = int.Parse(id);
            }
            else
            {
                throw new ArgumentException("Missing id");
            }


        }

        public override async void Start()
        {
            base.Start();

            CurrentPhoto = await _fetchManager.GetPhoto(_id);
        }

        private Photo _currentPhoto;
        public Photo CurrentPhoto
        {
            get { return _currentPhoto; }
            set
            {
                _currentPhoto = value;

                RaisePropertyChanged(() => CurrentPhoto);
                RaisePropertyChanged(() => Title);
                RaisePropertyChanged(() => Url);
            }
        }

        public string Title { get { return CurrentPhoto.Title; } }

        public string Url { get { return CurrentPhoto.Url; } }
    }
}

