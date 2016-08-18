using System;
using System.Threading.Tasks;
using HelloWorld.Core.Services;
using UIKit;
namespace HelloWorld.iOS.Services
{
    public class AlertService : IAlertService
    {
        public void ShowAlert(string title, string message)
        {
            var alert = new UIAlertView(title, message, null, "Ok");
            alert.Show();

        }
    }
}

