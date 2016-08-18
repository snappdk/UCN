using System;
using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using PictureSaver.Core.Models;

namespace PictureSaver.iOS.Views.Cells
{
    public partial class PictureCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString(nameof(PictureCell));
        public static readonly UINib Nib;

        static PictureCell()
        {
            Nib = UINib.FromName(nameof(PictureCell), NSBundle.MainBundle);
        }

        public PictureCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PictureCell, PictureDetail>();
                set.Bind(TitleLabel).To(vm => vm.Title);
                set.Apply();
            });
        }
    }
}
