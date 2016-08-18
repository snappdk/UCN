using System;
using System.Threading.Tasks;

namespace HelloWorld.Core.Services
{
    public interface IAlertService
    {
        void ShowAlert(string title, string message);
    }
}

