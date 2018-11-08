using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EFDemo.Models;
using EFDemo.ViewModels;
using System.Collections.Generic;

namespace EFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepartmentDetailPage : ContentPage
    {
        DepartmentDetailViewModel viewModel;

        public DepartmentDetailPage(DepartmentDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DepartmentDetailPage()
        {
            InitializeComponent();

            var dept = new Department
            {
                Name = "Unknown",
                Personnel = new List<Personnel>()
            };

            BindingContext = viewModel = new DepartmentDetailViewModel(dept);
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPersonnelPage(viewModel.Department)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Personnel.Count == 0)
                viewModel.LoadPersonnelCommand.Execute(null);
        }
    }
}