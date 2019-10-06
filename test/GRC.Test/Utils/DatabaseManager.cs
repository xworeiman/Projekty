using GRC.DataAccess;
using GRC.DataAccess.Development;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.Test.Utils
{
    static class DatabaseManager
    {
        static public GrcContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<GrcContext>().UseInMemoryDatabase(databaseName: "GRC").Options;
            return new GrcContext(options);
        }


        static public GrcContext GetRealDbContext()
        {
            var conStr = ConfigurationManager.GetApplicationConfiguration(null).ConnectionString;
            var builder = new DbContextOptionsBuilder<GrcContext>()
                .AddInterceptors(new DevelopmentCommandInterceptor());

            var options = builder.UseSqlServer(conStr, opt => {
                    opt.EnableRetryOnFailure(2);
                    opt.CommandTimeout(15);
                })
                .UseLoggerFactory(new LoggerFactory())
                .Options;
            
            return new GrcContext(options);
        }
    }
}
