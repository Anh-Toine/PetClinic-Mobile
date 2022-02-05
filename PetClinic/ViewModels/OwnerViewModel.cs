using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using PetClinic.Models;
using PetClinic.Services.NetworkService;

namespace PetClinic.ViewModels
{
    public class OwnerViewModel : ViewModelBase
    {
        public INetworkService<HttpResponseMessage> networkService;

        public ObservableRangeCollection<Owner> Owners { get; set; }

        public AsyncCommand GetAllOwners { get; }


        public OwnerViewModel()
        {
            networkService = NetworkService.Instance;
            GetAllOwners = new AsyncCommand(GetOwners);
            GetOwners();
        }

        private async Task GetOwners()
        {
            var res = await networkService.GetAsync<List<Owner>>(ApiConstants.CustomerURL());
            if (res != null)
            {
                Owners = new ObservableRangeCollection<Owner>(res);
                OnPropertyChanged("Owners");
            } else
            {
                Owners = new ObservableRangeCollection<Owner>();
            }

            OnPropertyChanged("Owners");
        }

        
    }
}
