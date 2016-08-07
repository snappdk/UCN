using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using HelloWorld.Core.Models;

namespace HelloWorld.iOS.Views
{
    public partial class PhotoCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("PhotoCell");
        public static readonly UINib Nib;

        static PhotoCell()
        {
            Nib = UINib.FromName("PhotoCell", NSBundle.MainBundle);
        }

        protected PhotoCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var loader = new MvxImageViewLoader(() => this.ThumbnailImage);

                var set = this.CreateBindingSet<PhotoCell, Photo>();
                set.Bind(TitleLabel).To(vm => vm.Title);
                set.Bind(loader).To(vm => vm.ThumbnailUrl);
                set.Apply();
            });

        }
    }
}
