using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EFDemo.Models;
using EFDemo.Views;
using EFDemo.ViewModels;

namespace EFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepartmentsPage : ContentPage
    {
        DepartmentsViewModel viewModel;

        public DepartmentsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DepartmentsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Department;
            if (item == null)
                return;

            await Navigation.PushAsync(new DepartmentDetailPage(new DepartmentDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddDept_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewDeptPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Departments.Count == 0)
                viewModel.LoadDepartmentsCommand.Execute(null);
        }
    }
}