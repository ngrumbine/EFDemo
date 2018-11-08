namespace EFDemo
{
    public interface ILocalFileHelper
    {
        string GetLocalFilePath(string filename);
        string GetDatabaseFilePath(string filename);
        string GetCustomFilePath(string folder, string filename);
    }
}
