using HelloWorld.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

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

            TableView.RowHeight = 150;

            this.AutomaticallyAdjustsScrollViewInsets = true;


            var source = new MvxSimpleTableViewSource(this.TableView, PhotoCell.Key );
            TableView.Source = source;
            this.AutomaticallyAdjustsScrollViewInsets = true;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(FetchButton).To(vm => vm.FetchCommand);
            set.Bind(source).To(vm => vm.Photos);
            set.Apply();
        }
    }
}
