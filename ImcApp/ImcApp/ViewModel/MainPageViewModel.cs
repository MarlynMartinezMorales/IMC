using ImcApp.Model;
using ImcApp.ViewModels;
using System;
using Xamarin.Forms;

namespace ImcApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            LimpiarIU();
        }

        private void CalcularButton_Clicked(object sender, EventArgs e)
        {
            decimal peso;
            decimal estatura;
            bool pesoEsConvertible = decimal.TryParse(PesoEntry.Text, out peso);
            bool estaturaEsConvertible = decimal.TryParse(EstaturaEntry.Text, out estatura);
            if (pesoEsConvertible && estaturaEsConvertible)
            {
                CalculadoraImc cimc = new CalculadoraImc(peso, estatura);
                ImcLabel.Text = string.Format("{0:f4}", cimc.Imc);
                SituacionNutricionalLabel.Text =
                    GetEstadoNutricional(cimc.SituacionNutricional);
            }
            else
            {
                DisplayAlert("Alerta",
                    "El peso y la estatura deben ser valores numericos.",
                    "Aceptar");
            }
        }


        private void LimpiarButton_Clicked(object sender, EventArgs e)
        {
            LimpiarIU();
        }

        private bool CanCalculate()
        {
            return Peso > 0M && Estatura > 0M;
        }


        private void LimpiarIU()
        {
            Peso = 0;
            Estatura = 0;
            Imc = 0;
            SituacionNutricional = string.Empty;
            //PesoEntry.Text = string.Empty;
            //EstaturaEntry.Text = string.Empty;
            //ImcLabel.Text = string.Empty;
            //SituacionNutricionalLabel.Text = string.Empty;
        }


        private string GetEstadoNutricional(CalculadoraImc.EstadoNutricional estado)
        {
            switch (estado)
            {
                case CalculadoraImc.EstadoNutricional.PesoBajo:
                    return App.Current.Resources["TestoPesoBajo"] as string;
                case CalculadoraImc.EstadoNutricional.PesoNormal:
                    return App.Current.Resources["TestoPesoNormal"] as string; ;
                case CalculadoraImc.EstadoNutricional.SobrePeso:
                    return App.Current.Resources["TestoSobrePeso"] as string; ;
                case CalculadoraImc.EstadoNutricional.Obesidad:
                    return App.Current.Resources["TestoObesidad"] as string; ;
                case CalculadoraImc.EstadoNutricional.ObesidadExtrema:
                    return App.Current.Resources["TestoObesidadExtrema"] as string; ;
                default:
                    return string.Empty;
            }
        }
    }
}
