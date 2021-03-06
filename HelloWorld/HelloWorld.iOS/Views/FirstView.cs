using HelloWorld.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using HelloWorld.iOS.Services;

namespace HelloWorld.iOS.Views
{
    public partial class FirstView : MvxViewController
    {
        public FirstView() : base("FirstView", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            NavigationItem.RightBarButtonItem = addButton;

            TableView.RowHeight = 150;

            this.AutomaticallyAdjustsScrollViewInsets = true;

            var source = new MvxSimpleTableViewSource(this.TableView, PhotoCell.Key);
            source.DeselectAutomatically = true;

            TableView.Source = source;
            this.AutomaticallyAdjustsScrollViewInsets = true;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(FetchButton).To(vm => vm.FetchCommand);
            set.Bind(source).To(vm => vm.Photos);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
            set.Bind(addButton).To(vm => vm.AddCommand);
            set.Apply();
        }
    }
}
