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
    public class DepartmentDetailViewModel : BaseViewModel
    {
        public Department Department { get; set; }

        public ObservableCollection<Personnel> Personnel { get; set; }

        public Command LoadPersonnelCommand { get; set; }

        public DepartmentDetailViewModel(Department dept = null)
        {
            Title = dept?.Name;
            Department = dept;
            Personnel = new ObservableCollection<Personnel>();
            LoadPersonnelCommand = new Command(async () => await ExecuteLoadCommand());

            MessagingCenter.Subscribe<NewPersonnelPage, Personnel>(this, "AddPersonnel", async (obj, item) =>
            {
                var newItem = item as Personnel;
                newItem.Department = null;
                newItem.DepartmentId = Department.Id;
                DataStore.Personnel.Add(newItem);
                await DataStore.SaveChangesAsync();

                await DataStore.Entry(newItem).ReloadAsync();

                Personnel.Add(newItem);
            });
        }

        async Task ExecuteLoadCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Personnel.Clear();
                foreach (var item in await DataStore.Personnel.Where(p=> p.DepartmentId == Department.Id).ToListAsync())
                {
                    Personnel.Add(item);
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
