using GRC.DataAccess;
using GRC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static GRC.Test.Utils.DatabaseManager;

namespace GRC.Test.Unit.EntityFramework
{
    public class InMemoryDatabaseTest
    {
        [Fact]
        public void CreateTreeOfProcessWorks()
        {
            //Arrange
            var po = new Domain.Models.Origin();
            var pr = new Domain.Models.Process() { Version = 1, Origin = po, EnterpriseId = "Pr1", State = 0 };
            var spr = new Domain.Models.SubProcess() { Version = 1, Origin = po, EnterpriseId = "SubPr1", State = 0, Parent = pr };
            var st = new Domain.Models.Stage() { Version = 1, Origin = po, EnterpriseId = "St1", State = 0, Parent = spr };
            var cm1 = new Domain.Models.ControlMechanism() { Version = 1, Origin = po, EnterpriseId = "KM1", State = 0 };
            var cm2 = new Domain.Models.ControlMechanism() { Version = 1, Origin = po, EnterpriseId = "KM2", State = 0 };

            var cmrst = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm = cm1, Stage = st };
            var cmrpr = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm = cm1, Process = pr };
            var cmrspr = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm = cm1, SubProcess = spr };
            var invalidNoRelationToProcessTree = new Domain.Models.ControlMechanismRelations() { Version = 1, Origin = po, ControlMechanizm = cm1 };

            //Act
            using (var ctx = GetInMemoryContext())
            {
                //clear tables!
                ctx.Origin.RemoveRange(ctx.Origin);
                ctx.Process.RemoveRange(ctx.Process);
                ctx.SubProcess.RemoveRange(ctx.SubProcess);
                ctx.Stage.RemoveRange(ctx.Stage);
                ctx.ControlMechanism.RemoveRange(ctx.ControlMechanism);
                ctx.ControlMechanismRelations.RemoveRange(ctx.ControlMechanismRelations);
                ctx.SaveChanges();

                ctx.Origin.Add(po);
                ctx.Process.Add(pr);
                ctx.SubProcess.Add(spr);
                ctx.Stage.Add(st);
                ctx.ControlMechanism.AddRange(cm1, cm2);
                ctx.ControlMechanismRelations.AddRange(cmrst, cmrpr, cmrspr, invalidNoRelationToProcessTree);
                ctx.SaveChanges();
            }

            //Assert
            using (var ctx = GetInMemoryContext())
            {
                Assert.True(ctx.ControlMechanismRelations.AnyAsync().Result);
            }
        }
    }
}
