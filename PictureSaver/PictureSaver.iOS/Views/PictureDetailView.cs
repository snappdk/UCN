using System;
using System.Drawing;
using Foundation;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using PictureSaver.Core.ViewModels;

namespace PictureSaver.iOS.Views
{
    public partial class PictureDetailView : MvxViewController<PictureDetailViewModel>
    {
        public PictureDetailView() : base(nameof(PictureDetailView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<PictureDetailView, PictureDetailViewModel>();

            set.Apply();
        }
    }
}