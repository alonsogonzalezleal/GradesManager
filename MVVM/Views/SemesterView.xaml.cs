using GradesManager.MVVM.ViewModels;
namespace GradesManager.MVVM.Views;

public partial class SemesterView : ContentPage
{
	public SemesterView()
	{
		InitializeComponent();
        BindingContext = new SemesterViewModel();
    }
}