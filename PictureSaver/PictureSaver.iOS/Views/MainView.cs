using System;
using System.Drawing;
using Foundation;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using PictureSaver.Core.ViewModels;
using MvvmCross.Binding.iOS.Views;
using PictureSaver.iOS.Views.Cells;

namespace PictureSaver.iOS.Views
{
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView() : base(nameof(MainView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxSimpleTableViewSource(TableView, PictureCell.Key);
            source.DeselectAutomatically = true;
            TableView.Source = source;

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            NavigationItem.RightBarButtonItem = addButton;

            var imageLoader = new MvxImageViewLoader(() => TestImage);

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(source).To(vm => vm.Pictures);
            set.Bind(addButton).To(vm => vm.AddCommand);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.PictureSelectedCommand);
            set.Bind(imageLoader).For(i => i.ImageUrl).To(vm => vm.ImageUrl);
            set.Apply();
        }
    }
}
