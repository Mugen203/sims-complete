using System;
using ischool_backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ischool_backend.API.ContextFactory;

/// <summary>
/// Factory class for creating DbContext instances at design time for migrations
/// Implements IDesignTimeDbContextFactory to support EF Core CLI tools
/// </summary>
public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    /// <summary>
    /// Creates a new instance of RepositoryContext for use with migrations
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    /// <returns>A configured RepositoryContext instance</returns>
    public RepositoryContext CreateDbContext(string[] args)
    {
        // Build configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  // Set config file location
            .AddJsonFile("appsettings.json")              // Use appsettings.json file
            .Build();

        // Create DbContext options using SQL Server provider
        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"));

        // Return new context instance with configured options
        return new RepositoryContext(builder.Options);
    }
}

