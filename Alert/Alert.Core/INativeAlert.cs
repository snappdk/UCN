using System;
namespace Alert.Core
{
	public interface INativeAlert
	{
		void ShowAlert (string title, string description);
	}
}

