
using EFDemo.iOS.Platform;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace EFDemo.iOS.Platform
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetCustomFilePath(string folder, string filename)
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string libFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", folder);
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);

        }

        public string GetDatabaseFilePath(string filename)
        {
            return this.GetCustomFilePath("Databases", filename);
        }

        public string GetLocalFilePath(string filename)
        {
            return this.GetCustomFilePath("Files", filename);
        }
    }
}