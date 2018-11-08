namespace EFDemo.Database
{
    using Microsoft.EntityFrameworkCore.Design;
    using System.Diagnostics;
    using System.IO;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            Debug.WriteLine(Directory.GetCurrentDirectory() + @"\Config.db");

            return new DatabaseContext(Directory.GetCurrentDirectory() + @"\Config.db");
        }
    }
}
