using System;
using HelloWorld.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.iOS.Views;

namespace HelloWorld.iOS.Views
{
    public partial class DetailsView : MvxViewController
    {
        public DetailsView() : base("DetailsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();



            var imageLoader = new MvxImageViewLoader(() => HeaderImage);

            var set = this.CreateBindingSet<DetailsView, DetailsViewModel>();
            set.Bind(imageLoader).For(loader => loader.ImageUrl).To(vm => vm.Url);
            set.Bind(this).For(vc => vc.AnimatedTitle).To(vm => vm.Title);
            set.Apply();

            NavigationController.NavigationBar.Translucent = false;
        }

        public string AnimatedTitle
        {
            get { return TitleLabel.Text; }
            set
            {
                TitleLabel.Text = value;
                var original = TitleLabel.Layer.Frame;
                TitleLabel.Layer.Frame = new CoreGraphics.CGRect();
                UIView.Animate(5f, () =>
                {
                    TitleLabel.Layer.Frame = original;
                });

            }
        }
    }
}