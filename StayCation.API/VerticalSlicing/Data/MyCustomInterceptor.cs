using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;
using StayCation.API.VerticalSlicing.Common.DTOs;
using System.Data.Common;

namespace StayCation.API.VerticalSlicing.Data
{
    public class MyCustomInterceptor : DbCommandInterceptor
    {

        private readonly UserState _userState;
        public MyCustomInterceptor(UserState userState)
        {
            _userState = userState;
        }
        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            
            Log.Information($"User {_userState.UserName} is executing NonQuery: {command.CommandText}", _userState.Id, command.CommandText);

            return base.NonQueryExecuting(command, eventData, result);
        }

        public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            Log.Information($"User {_userState.UserName} executed ReaderAsync: {command.CommandText}", _userState.Id, command.CommandText);

            return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }

        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            return base.ScalarExecuting(command, eventData, result);
        }
    }
}
