using HelloWorld.Core.Models;
using HelloWorld.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Platform;
using MvvmCross.Plugins.PictureChooser;
using System;

namespace HelloWorld.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private IFetchManager _placeholderService;
        private IAlertService _alertService;
        private ILocalStorageService _localStorageService;

        public FirstViewModel(IFetchManager fetchManager, IAlertService alertService, ILocalStorageService localStorageService)
        {
            _placeholderService = fetchManager;
            _alertService = alertService;
            _localStorageService = localStorageService;
        }

        private MvxAsyncCommand _fetchCommand;

        public MvxAsyncCommand FetchCommand
        {
            get
            {
                _fetchCommand = _fetchCommand ?? new MvxAsyncCommand(DoFetchCommand);
                return _fetchCommand;
            }
        }

        private async Task DoFetchCommand()
        {
            var result = await _placeholderService.GetPhotos();

            Photos = new ObservableCollection<Photo>(result);
        }

        private ObservableCollection<Photo> _photos;
        public ObservableCollection<Photo> Photos
        {
            get { return _photos; }
            set { if (_photos == value) return; _photos = value; RaisePropertyChanged(() => Photos); }
        }

        private MvxCommand<Photo> _itemSelectedCommand;
        public MvxCommand<Photo> ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<Photo>(DoItemSelectedCommand);
                return _itemSelectedCommand;
            }
        }
        private void DoItemSelectedCommand(Photo photo)
        {
            var bundle = new MvxBundle();
            bundle.Data.Add("Id", photo.Id.ToString());

            ShowViewModel<DetailsViewModel>(bundle);
        }

        private MvxAsyncCommand _addCommand;
        public MvxAsyncCommand AddCommand
        {
            get
            {
                _addCommand = _addCommand ?? new MvxAsyncCommand(DoAddCommand);
                return _addCommand;
            }
        }
        private async Task DoAddCommand()
        {
            var pictureChooserTask = Mvx.Resolve<IMvxPictureChooserTask>();

            var result = await pictureChooserTask.ChoosePictureFromLibraryAsync(1024, 80);

            if (result != null)
            {
                var path = await _localStorageService.SaveAsync(Guid.NewGuid().ToString(), result);

                if (Photos == null)
                {
                    Photos = new ObservableCollection<Photo>();
                }

                Photos.Add(new Photo() { Title = path, ThumbnailUrl = path });
            }

        }
    }
}
