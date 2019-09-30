using GRC.DataAccess;
using Microsoft.EntityFrameworkCore;
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
            var options = new DbContextOptionsBuilder<GrcContext>()
                .UseSqlServer(conStr, opt => {
                    opt.EnableRetryOnFailure();
                    opt.CommandTimeout(15);
                }).Options;

            return new GrcContext(options);
        }
    }
}
