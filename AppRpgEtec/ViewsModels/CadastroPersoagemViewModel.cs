using AppRpgEtec.Services.Personagens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRpgEtec.ViewsModels
{
    public class CadastroPersoagemViewModel : BaseViewModel
    {
        private PersonagemServices pService;

        public CadastroPersoagemViewModel()
        {
            string token = Preferences.Get("Usuariotoken", string.Empty);
            pService = new PersonagemServices(token);
        }

        private int id;
        private string nome;
        private int pontosvida;
        private int forca;
        private int defesa;
        private int inteligencia;
        private int disputas;
        private int vitorias;
        private int derrotas;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        public int Pontosvida
        {
            get => pontosvida;
            set
            {
                pontosvida = value;
                OnPropertyChanged();
            }
        }

        public int Forca
        {
            get => forca;
            set
            {
                forca = value;
                OnPropertyChanged();
            }
        }

        public int Defesa
        {
            get => defesa;
            set
            {
                defesa = value;
                OnPropertyChanged();
            }
        }

        public int Inteligencia
        {
            get => inteligencia;
            set
            {
                inteligencia = value;
                OnPropertyChanged();
            }
        }

        public int Disputas
        {
            get => disputas;
            set
            {
                disputas = value;
                OnPropertyChanged();
            }
        }

        public int Vitorias
        {
            get => vitorias;
            set
            {
                vitorias = value;
                OnPropertyChanged();
            }
        }

        public int Derrotas
        {
            get => derrotas;
            set
            {
                derrotas = value;
                OnPropertyChanged();
            }
        }
    }
}
