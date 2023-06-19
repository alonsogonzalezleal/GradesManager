using GradesManager.MVVM.ViewModels;
namespace GradesManager.MVVM.Views;

public partial class SubjectView : ContentPage
{
	public SubjectView()
	{
		InitializeComponent();
		BindingContext = new SubjectViewModel();
	}
}