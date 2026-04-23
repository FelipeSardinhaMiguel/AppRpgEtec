using AppRpgEtec.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Windows.Input;
using AppRpgEtec.Models;
using AppRpgEtec.Views.Usuarios;
using AppRpgEtec.Views.Personagens;

namespace AppRpgEtec.ViewsModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand AutenticarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }

        public UsuarioViewModel()
        {
                uService = new UsuarioService();
                InicializarCommands();
        }
        public void InicializarCommands()
        {
                AutenticarCommand = new Command(async () => await AutenticarUsuario());
                RegistrarCommand = new Command(async () => await RegistrarUsuario());
                DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }

        #region AtributosPropriedades
        //As propriedades serão chamadas na View futuramente

        private string login = string.Empty;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Password;

                Usuario uAutenticacao = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticacao.Token))
                {
                    string mensagem = $"bem -vindo(a) {uAutenticacao.Username}.";

                    Preferences.Set("UsuarioId", uAutenticacao.Id);
                    Preferences.Set("UsuarioUsername", uAutenticacao.Username);
                    Preferences.Set("UsuarioPerfil", uAutenticacao.Perfil);
                    Preferences.Set("Usuariotoken", uAutenticacao.Token);

                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "Ok");

                   Application.Current.MainPage = new AppShell();
                   //Application.Current.MainPage = new Views.Armas.ListagemView();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        #region Métodos
        public async Task RegistrarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = login;
                u.PasswordString = Password;

                Usuario uRegistrado = await uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.Id != 0)
                {
                    string mensagem = $"Usuario Id {uRegistrado.Id} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + "Detalhes" + ex.InnerException, "Ok");  
            }
        }

        #endregion

        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new CadastroView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

    }
}