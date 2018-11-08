# EFDemo
Demo of how to integrate EF Core 2.0 into Xamarin Forms Cross Platform 


Quick and dirty explanation...

I added the following Nuget Packages to my .NetStandard Dll for my Xamarin Forms app.

  - Microsoft.Data.Sqlite.Core
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.EntityFrameworkCore.Sqlite
  - Microsoft.EntityFrameworkCore.Tools

Like Mark said, I added a .Net Core Console Application... DbConfig

Then to make it all work i added the following class to my EFDemo poject that allows the migrations to run!

```
      namespace EFDemo.Database
      {
          public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
          {
              public DatabaseContext CreateDbContext(string[] args)
              {
                  Debug.WriteLine(Directory.GetCurrentDirectory() + @"\Config.db");

                  return new DatabaseContext(Directory.GetCurrentDirectory() + @"\Config.db");
              }
          }
      }
```

My DatabaseContext looks like:

```
      namespace EFDemo.Database
      {
          public class DatabaseContext : DbContext
          {
              private string _databasePath;

              public DatabaseContext(string databasePath)
              {
                  _databasePath = databasePath;
                  this.Database.Migrate();
              }

              protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              {
                  optionsBuilder.UseSqlite($"Filename={_databasePath}");
              }

              protected override void OnModelCreating(ModelBuilder modelBuilder)
              {
                  base.OnModelCreating(modelBuilder);

              }

              public virtual DbSet<Models.Department> Departments { get; set; }
              public virtual DbSet<Models.Personnel> Personnel { get; set; }
          }
      }
  ```
In the package manager console then you can run....

`
  add-migration "Initial" -Project EFDemo -StartupProject DbConfig
`

and you can keep running add-migration and it will generate and auto migrate your db!

The kicker is you create a config db in you console app, which i keep included in my solution and check in with my code so it can generate the migrations.
