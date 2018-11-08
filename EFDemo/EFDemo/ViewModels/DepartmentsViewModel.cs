using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using EFDemo.Models;
using EFDemo.Views;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.ViewModels
{
    public class DepartmentsViewModel : BaseViewModel
    {
        public ObservableCollection<Department> Departments { get; set; }
        public Command LoadDepartmentsCommand { get; set; }

        public DepartmentsViewModel()
        {
            Title = "Departments";
            Departments = new ObservableCollection<Department>();
            LoadDepartmentsCommand = new Command(async () => await ExecuteLoadDeptsCommand());

            MessagingCenter.Subscribe<NewDeptPage, Department>(this, "AddDept", async (obj, item) =>
            {
                var newItem = item as Department;
                Departments.Add(newItem);
                await DataStore.AddAsync(newItem);
                await DataStore.SaveChangesAsync();
            });
        }

        async Task ExecuteLoadDeptsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Departments.Clear();
                var items = await DataStore.Departments.ToListAsync();
                foreach (var item in items)
                {
                    Departments.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}