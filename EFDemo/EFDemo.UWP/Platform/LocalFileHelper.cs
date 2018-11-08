

using EFDemo.UWP.Platform;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace EFDemo.UWP.Platform
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetCustomFilePath(string folder, string filename)
        {
            string docFolder = ApplicationData.Current.LocalFolder.Path;
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

