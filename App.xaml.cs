using GradesManager.MVVM.Views;

namespace GradesManager;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new BasePageView();
	}
}
