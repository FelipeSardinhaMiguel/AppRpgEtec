using AppRpgEtec.ViewModels.Disputas;

namespace AppRpgEtec.Views.Disputas;

public partial class ListagemDisputasView : ContentPage
{
	DisputaViewModel viewModel;
	public ListagemDisputasView()
	{
		InitializeComponent();

		viewModel = new DisputaViewModel();
		BindingContext = viewModel;
	}
}