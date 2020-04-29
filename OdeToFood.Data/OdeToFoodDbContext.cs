using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    // Code First Approach
    // DbContext ~~ Database
    // DbSet ~~ Table

    // dotnet ef dbcontext list|info|scaffold
    // list - lists all dbcontext present in the project
    // scaffold - Point to existing DB and generate code to match DB
    // info - Gets info about a context type
    // Data Source=NDI-LAP-837\SQLEXPRESS;Integrated Security=True
    // SSMS string POO POO ~~ Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

    // dotnet ef migrations add | list | remove | script
    // Add a new migration
    // List available migrations
    // Remove the last migration
    // Script Generates an sql script from migrations
    public class OdeToFoodDbContext: DbContext
    {
        // As we have configured this dbcontext in startup.js
        // and in that it is passing (options) into the constructor
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            :base(options)
        {
            // base const will figure out itself what to do with option
        }

        // this DbContext is in diff project OdeToFood.Data proj thus will
        // connection info and startup conifg about provider are in CoreWebApp proj


        // While info use:
        // dotnet ef dbcontext info -s ..\CoreWebApp\CoreWebApp.csproj
        //Provider name: Microsoft.EntityFrameworkCore.SqlServer
        //Database name: OdeToFood
        //Data source: NDI-LAP-837\SQLEXPRESS
        //Options: MaxPoolSize=128

        // While creating migrations we have to use:
        // dotnet ef migrations add <mig_name> -s ..\CoreWebApp\CoreWebApp.csproj
        // Now look at OdeToFood.Data project

        // to update Database for changes:
        // dotnet ef database update -s ..\CoreWebApp\CoreWebApp.csproj

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
