using System;
using HelloWorld.Core.Services;
using Android.App;
using Android.Content;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using System.Threading.Tasks;

namespace HelloWorld.Droid.Services
{
    public class AlertService : IAlertService
    {
        public AlertService()
        {
        }

        public void ShowAlert(string title, string message)
        {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();

            var tcs = new TaskCompletionSource<bool>();

            Context context = topActivity.Activity;
            var alert = new AlertDialog.Builder(context);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton("Ok", (sender, e) => { tcs.TrySetResult(true); });
            alert.Show();

        }
    }
}

