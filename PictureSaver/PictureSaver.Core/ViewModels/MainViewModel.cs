using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using PictureSaver.Core.Models;
using PictureSaver.Core.Services;
using MvvmCross.Plugins.PictureChooser;
using System.Threading.Tasks;
using System.IO;

namespace PictureSaver.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IPictureService _pictureService;

        public MainViewModel(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public override async void Start()
        {
            base.Start();
            var pictures = await _pictureService.GetPictures();
            Pictures = new ObservableCollection<PictureDetail>(pictures);
        }

        private ObservableCollection<PictureDetail> _pictures = new ObservableCollection<PictureDetail>();
        public ObservableCollection<PictureDetail> Pictures
        {
            get { return _pictures; }
            set { _pictures = value; RaisePropertyChanged(() => Pictures); }
        }

        private MvxAsyncCommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                _addCommand = _addCommand ?? new MvxAsyncCommand(DoAddCommandAsync);
                return _addCommand;
            }
        }
        private async Task DoAddCommandAsync()
        {
            var pictureChooser = Mvx.Resolve<IMvxPictureChooserTask>();

            var result = await pictureChooser.ChoosePictureFromLibraryAsync(1024, 80);

            if (result != null)
            {
                using (var stream = new MemoryStream())
                {
                    await result.CopyToAsync(stream);

                    var localStorage = Mvx.Resolve<ILocalStorageService>();
                    var path = await localStorage.SavePictureAsync(stream, Guid.NewGuid().ToString());

                    ImageUrl = path;


                }
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; RaisePropertyChanged(() => ImageUrl); }
        }



        private MvxCommand<PictureDetail> _pictureSelectedCommand;
        public ICommand PictureSelectedCommand
        {
            get
            {
                _pictureSelectedCommand = _pictureSelectedCommand ?? new MvxCommand<PictureDetail>(DoPictureSelectedCommand);
                return _pictureSelectedCommand;
            }
        }
        private void DoPictureSelectedCommand(PictureDetail picture)
        {
            var bundle = new MvxBundle();
            bundle.Data.Add("id", picture.Id.ToString());

            ShowViewModel<PictureDetailViewModel>();
        }
    }
}
