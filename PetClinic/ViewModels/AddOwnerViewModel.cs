using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmHelpers.Commands;
using PetClinic.Models;
using PetClinic.Services.NetworkService;
using Xamarin.Forms;

namespace PetClinic.ViewModels
{
    public class AddOwnerViewModel : ViewModelBase
    {
        public INetworkService<HttpResponseMessage> networkService;
        private string firstName, lastName, address, city, telephone;

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string Telephone
        {
            get => telephone;
            set => SetProperty(ref telephone, value);
        }
        

        public AsyncCommand PostOwner { get; }

        public AddOwnerViewModel()
        {
            Title = "Add new owner";

            PostOwner = new AsyncCommand(AddOwner);
        }

        private async Task AddOwner()
        {
            
            if(string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Address) ||
               string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(Telephone))
            {

                return;
            }
            else
            {
                Owner owner = new Owner(FirstName, LastName, Address, City, Telephone);
                await networkService.PostAsync<Owner>(ApiConstants.CustomerURL(),owner);
                await App.Current.MainPage.DisplayAlert(" ", "Successfully added a new ower!", "OK");
            }
        }
    }
}
