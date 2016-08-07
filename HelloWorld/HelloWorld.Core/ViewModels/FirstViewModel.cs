using HelloWorld.Core.Models;
using HelloWorld.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private IPlaceholderService _placeholderService;
        public override async void Start()
        {
            base.Start();
        }

        public FirstViewModel(IPlaceholderService placeholderService)
        {
            _placeholderService = placeholderService;
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
            System.Diagnostics.Debug.WriteLine("Hello from core");
            Content = "Fetching data..";

            var result = await _placeholderService.GetPhotos();
            
            Photos = new ObservableCollection<Photo>(result);

            Content = result.FirstOrDefault().Title;
        }

        private ObservableCollection<Photo> _photos;
        public ObservableCollection<Photo> Photos
        {
            get { return _photos; }
            set { if (_photos == value) return; _photos = value; RaisePropertyChanged(() => Photos); }
        }


        private string _content;
        public string Content
        {
            get { return _content; }
            set { if (_content == value) return; _content = value; RaisePropertyChanged(() => Content); }
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
            System.Diagnostics.Debug.WriteLine(photo.Title);
        }


    }
}
