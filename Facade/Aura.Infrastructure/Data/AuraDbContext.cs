using Aura.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aura.Infrastructure.Data
{
    public class AuraDbContext : DbContext
    {
        #region Tables

        public DbSet<TestSuite> TestSuites { get; set; }

        public DbSet<TestCase> TestCases { get; set; }

        public DbSet<TestSuiteTestCaseMapping> TestSuiteTestCaseMappings { get; set; }

        #endregion Tables
    }
}