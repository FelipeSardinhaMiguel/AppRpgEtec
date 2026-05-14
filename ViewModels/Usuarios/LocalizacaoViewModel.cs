using Android.OS;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Text;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class LocalizacaoViewModel : BaseViewModel
    {
        private Map meuMapa;
        public Map MeuMapa
        {
            get => meuMapa;
            set
            {
                if (value != null)
                {
                    meuMapa = value;
                    OnPropertyChanged();
                }
            }
        }
        public async void InicializarMapa()
        {
            try
            {
                Location location = new Location(-23.479816303225597, -46.57923859429801);
                Pin pinJB = new Pin()
                {
                    Type = PinType.Place,
                    Label = "JB Houses",
                    Address = "Av. Roland Garros, 788",
                    Location = location
                };
                Map map = new Map();
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5));
                map.Pins.Add(pinJB);
                map.MoveToRegion(mapSpan);

                MeuMapa = map;
            }
            catch  (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message,"Ok");
            }
        }
    }
}
