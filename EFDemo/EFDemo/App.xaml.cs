using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EFDemo.Views;
using System.Diagnostics;
using System.Linq;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EFDemo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var dbPath = DependencyService.Get<ILocalFileHelper>().GetDatabaseFilePath("App.db");
            Debug.WriteLine(dbPath);
            using ( var db = new Database.DatabaseContext(dbPath))
            {
                if (!db.Departments.Any())
                {
                    db.Departments.Add(new Models.Department { Name = "Human Resources" });
                    db.Departments.Add(new Models.Department { Name = "Information Technology" });
                }

                db.SaveChanges();

                if (!db.Personnel.Any())
                {
                    db.Personnel.Add(new Models.Personnel { Department = db.Departments.First(d => d.Name == "Human Resources"), FirstName = "Jane", LastName = "Smith" });
                    db.Personnel.Add(new Models.Personnel { Department = db.Departments.First(d => d.Name == "Information Technology"), FirstName = "John", LastName = "Doe" });
                    db.Personnel.Add(new Models.Personnel { Department = db.Departments.First(d => d.Name == "Information Technology"), FirstName = "Mark", LastName = "Jonnson" });
                }

                db.SaveChanges();
            }

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
