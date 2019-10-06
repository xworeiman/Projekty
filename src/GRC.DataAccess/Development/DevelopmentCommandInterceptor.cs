using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace GRC.DataAccess.Development
{
    public class DevelopmentCommandInterceptor : DbCommandInterceptor
    {
        public DevelopmentCommandInterceptor()
        {
        }
        public override InterceptionResult<DbCommand> CommandCreating(CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> result)
        {
            return base.CommandCreating(eventData, result);
        }
        public override void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        {
            base.CommandFailed(command, eventData);
        }
        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            return base.NonQueryExecuted(command, eventData, result);
        }
        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            return base.NonQueryExecuting(command, eventData, result);
        }
        public override object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        {
            return base.ScalarExecuted(command, eventData, result);
        }
        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            return base.ScalarExecuting(command, eventData, result);
        }
        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            return base.ReaderExecuted(command, eventData, result);
        }
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            return base.ReaderExecuting(command, eventData, result);
        }
        public override DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
        {
            return base.CommandCreated(eventData, result);
        }
        //override 
        //public override InterceptionResult ReaderExecuting(
        //  DbCommand command,
        //  CommandEventData eventData,
        //  InterceptionResult result)
        //{
        //    // Manipulate the command text, etc. here...
        //    command.CommandText += " OPTION (OPTIMIZE FOR UNKNOWN)";
        //    return result;
        //}
    }
}