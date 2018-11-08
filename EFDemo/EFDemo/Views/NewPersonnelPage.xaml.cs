using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EFDemo.Models;

namespace EFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPersonnelPage : ContentPage
    {
        public Personnel Personnel { get; set; }

        public NewPersonnelPage(Department department)
        {
            InitializeComponent();

            Personnel = new Personnel { FirstName = "John", LastName = "Doe", Department = department };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPersonnel", Personnel);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}