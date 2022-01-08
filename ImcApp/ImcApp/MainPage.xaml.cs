using System;
using Xamarin.Forms;
using ImcApp.Model;
using ImcApp.ViewModels; 

namespace ImcApp.Viwe
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent()
            viewModel = new MainPageViewModel();
            BindingContext = viewModel; 
        }
    }

}



