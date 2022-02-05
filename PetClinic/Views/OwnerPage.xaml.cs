using System;
using System.Collections.Generic;
using PetClinic.ViewModels;
using Xamarin.Forms;

namespace PetClinic.Views
{
    public partial class OwnerPage : ContentPage
    {
        public OwnerPage()
        {
            InitializeComponent();
            this.BindingContext = new OwnerViewModel();
        }

        private void ToolbarItem_Clicked(object sender,EventArgs e)
        {

        }
    }
}
