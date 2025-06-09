using ProjectCheckPointage.Mobile.ViewModels;

namespace ProjectCheckPointage.Mobile.Views;

public partial class DashboardSuperviseurPage : ContentPage
{
	DashboardSuperviseurViewModel viewModel;

    public DashboardSuperviseurPage()
	{
		InitializeComponent();
		BindingContext = viewModel = new DashboardSuperviseurViewModel();

    }
}