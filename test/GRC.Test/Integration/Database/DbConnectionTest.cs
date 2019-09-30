using GRC.Domain.Models;
using GRC.Domain.Models.Complex;
using GRC.Domain.Models.States;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static GRC.Test.Utils.DatabaseManager;

namespace GRC.Test.Integration.Database
{
    public class SqlServerDatabaseTest
    {
        [Fact]
        public void ConnectionToDatabaseWorks()
        {
            //Arrange
            //Act
            //Assert
            using var ctx = GetRealDbContext();
            Assert.True(ctx.Database.CanConnect());
        }

        [Fact]
        public void CreateTreeOfProcessWorks()
        {
            //Arrange
            var ow = new Owner { OwnerId = 102, OwnerOrganisationUnit = "DBB" };
            var po = new Origin();
            var pr = new Process() { Version = 1, Origin = po, EnterpriseId = "Pr1", Owner = ow, State = MfkStates.Accepted };//OwnerId=100, OwnerOrganisationUnit="DBB" };
            var spr = new Domain.Models.SubProcess() { Version = 1, Origin = po, EnterpriseId = "SubPr1", State = MfkStates.New, Parent = pr, Owner = ow };//OwnerId = 100, OwnerOrganisationUnit = "DBB" };
            var st = new Domain.Models.Stage() { Version = 1, Origin = po, EnterpriseId = "St1", State = MfkStates.New, Parent = spr, Owner = ow };//OwnerId = 100, OwnerOrganisationUnit = "DBB" };
            var cm1 = new Domain.Models.ControlMechanism() { Version = 1, Origin = po, EnterpriseId = "KM1", State = MfkStates.New, Owner = ow };
            var cm2 = new Domain.Models.ControlMechanism() { Version = 1, Origin = po, EnterpriseId = "KM2", State = MfkStates.Removed, Owner = ow };//??? (Owner)ow.Clone() };

            var cmrst = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm=cm1, Stage = st };
            var cmrpr = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm = cm1, Process = pr };
            var cmrspr = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm = cm1, SubProcess = spr };
            //var invalidNoRelationToProcessTree = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm = cm1 };

            //Act
            using (var ctx = GetRealDbContext())
            {
                //clear DB
              
                ctx.Database.ExecuteSqlRaw(@"DELETE FROM [mfk].[ControlMechanismRelations]; 
DELETE FROM [mfk].[ControlMechanism];
DELETE FROM [mfk].[Stage];
DELETE FROM [mfk].[SubProcess];
DELETE FROM [mfk].[Process];
DELETE FROM [mfk].[Origin];
DBCC CHECKIDENT ('[mfk].[ControlMechanismRelations]', RESEED, 0);
DBCC CHECKIDENT ('[mfk].[ControlMechanism]', RESEED, 0);
DBCC CHECKIDENT ('[mfk].[Stage]', RESEED, 999999);
DBCC CHECKIDENT ('[mfk].[SubProcess]', RESEED, 99999);
DBCC CHECKIDENT ('[mfk].[Process]', RESEED, 0);
DBCC CHECKIDENT ('[mfk].[Origin]', RESEED, 0);"
);
                //ctx.Database.ExecuteSqlRaw("DELETE FROM [mfk].[ControlMechanism]");
                //ctx.Database.ExecuteSqlRaw("DELETE FROM [mfk].[Stage]");
                //ctx.Database.ExecuteSqlRaw("DELETE FROM [mfk].[SubProcess]");
                //ctx.Database.ExecuteSqlRaw("DELETE FROM [mfk].[Process]");
                //ctx.Database.ExecuteSqlRaw("DELETE FROM [mfk].[Origin]");
           

                //ctx.Origin.RemoveRange(ctx.Origin);
                //ctx.Process.RemoveRange(ctx.Process);
                //ctx.SubProcess.RemoveRange(ctx.SubProcess);
                //ctx.Stage.RemoveRange(ctx.Stage);
                //ctx.ControlMechanism.RemoveRange(ctx.ControlMechanism);
                //ctx.ControlMechanismRelations.RemoveRange(ctx.ControlMechanismRelations);

                ctx.Origin.Add(po);
                ctx.Process.Add(pr);
                ctx.SubProcess.Add(spr);
                ctx.Stage.Add(st);
                ctx.ControlMechanism.AddRange(cm1, cm2);
                ctx.ControlMechanismRelations.AddRange(cmrst, cmrpr, cmrspr);
                ctx.SaveChanges();
            }

            //Assert
            using (var ctx = GetRealDbContext())
            {
                Assert.True(ctx.ControlMechanismRelations.AnyAsync().Result);
            }
        }
    }
}
