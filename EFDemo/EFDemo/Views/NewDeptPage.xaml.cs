using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EFDemo.Models;

namespace EFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDeptPage : ContentPage
    {
        public Department Department { get; set; }

        public NewDeptPage()
        {
            InitializeComponent();

            Department = new Department
            {
                Name = "Department Name",
                Personnel = new List<Personnel>()
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddDept", Department);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}