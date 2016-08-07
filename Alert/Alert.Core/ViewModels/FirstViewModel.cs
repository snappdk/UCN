using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Alert.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		readonly INativeAlert nativeAlert;

		public FirstViewModel (INativeAlert nativeAlert)
		{
			this.nativeAlert = nativeAlert;
		}


		private string _hello = "Hello MvvmCross";
		public string Hello {
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged (() => Hello); }
		}


		private MvxCommand _showAlertCommand;
		public ICommand ShowAlertCommand {
			get {
				_showAlertCommand = _showAlertCommand ?? new MvxCommand (DoShowAlertCommand);
				return _showAlertCommand;
			}
		}
		private void DoShowAlertCommand ()
		{
			nativeAlert.ShowAlert ("Advarsel!", "Du har trykket på en knap!");
		}
	}
}

