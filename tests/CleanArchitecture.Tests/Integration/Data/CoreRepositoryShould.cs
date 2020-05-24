using DMCIT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DMCIT.Tests.Integration.Data
{
    public class CoreRepositoryShould
    {
        private AppDbContext _db;
        static string connectionString = "Data Source=CNTT-TUANNT\\SQLEXPRESS;Initial Catalog=DMCIT;Integrated Security=True";
        private static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkSqlServer().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString, x => {
                x.MigrationsAssembly("DMCIT.Infrastructure");
                x.CommandTimeout(300);
            }).UseInternalServiceProvider(serviceProvider);
            return builder.Options;
        }

        private EfRepository GetRepository()
        {
            var options = CreateNewContextOptions();
            _db = new AppDbContext(options);
            return new EfRepository(_db);
        }

        private TemplateRepository GetTemplateRepository()
        {
            var options = CreateNewContextOptions();
            _db = new AppDbContext(options);
            
            var ef = new EfRepository(_db);
            var tp = new TemplateRepository(_db, ef, null);

            return tp;
        }

        [Fact]
        public void TestFuncs()
        {
            Assert.True(typeof(int?).GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        //[Fact]
        //public void GetTemplates()
        //{
        //    var rep = GetTemplateRepository();
        //    var message = new CustomerARMessageContentModel();
        //    message.Amount = "123";
        //    message.ReceiptDate = "1231/231/23";
        //    message.Customer = "1212axx";
        //    var rs = rep.ReviewTemplate(20, message.GetValue()).Result;
        //    Trace.TraceInformation(rs);
        //}

        //[Fact]
        //public void TestInstanceGeneric() {
        //    var instance1 = Type.GetType("DMCIT.Core.Entities.Templates.TextParser.TextParser");
        //    var instance = Type.GetType(typeof(TextParser).AssemblyQualifiedName);
        //    Assert.NotNull(instance);
        //}
    }
}
