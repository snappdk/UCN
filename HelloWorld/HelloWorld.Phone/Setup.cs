using MvvmCross.WindowsUWP.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Windows.UI.Xaml.Controls;

namespace HelloWorld.Phone
{
    public class Setup: MvxWindowsSetup
    {
        public Setup(Frame rootFrame):base(rootFrame)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new HelloWorld.Core.App();
        }
    }
}
