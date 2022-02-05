using PetClinic.Services.NetworkService;
using PetClinic.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace PetClinic.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private INetworkService<HttpResponseMessage> networkService;
        public Command LoginCommand { get; }
        public string Username { get; set; }

        public string Password { get; set; }

        public LoginViewModel()
        {
            networkService = NetworkService.Instance;
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            var authenticated = await networkService.LoginAsync(ApiConstants.GetLoginURL(), Username, Password);
            if (authenticated.IsSuccessStatusCode)
            {
                await Shell.Current.GoToAsync($"//{nameof(OwnerPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Login failed", "OK");
            }
           
        }
    }
}
