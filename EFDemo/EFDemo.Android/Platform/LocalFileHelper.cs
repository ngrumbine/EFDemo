using EFDemo.Droid.Platform;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace EFDemo.Droid.Platform
{
    using System.IO;

    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetCustomFilePath(string folder, string filename)
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, folder);
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