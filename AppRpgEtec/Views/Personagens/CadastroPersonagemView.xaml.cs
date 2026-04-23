using System.Runtime.CompilerServices;
using AppRpgEtec.ViewsModels;
using AppRpgEtec.ViewsModels.Usuarios;

namespace AppRpgEtec.Views.Personagens;

public partial class CadastroPersonagemView : ContentPage
{
	private CadastroPersoagemViewModel cadViewModel;
	public CadastroPersonagemView()
	{
		InitializeComponent();
		
		cadViewModel = new CadastroPersoagemViewModel();
		BindingContext = cadViewModel;
		Title = "Novo personagem";
	}
}