using System.Threading.Tasks;
using Dolittle.Execution;
using Dolittle.Tenancy;
using Microsoft.AspNetCore.Http;

namespace Core
{
    public class ExecutionContextMiddleware
    {
        readonly RequestDelegate _next;
        readonly IExecutionContextManager _contextManager;

        public ExecutionContextMiddleware(RequestDelegate next, IExecutionContextManager contextManager)
        {
            _next = next;
            _contextManager = contextManager;
        }

        public Task InvokeAsync(HttpContext context)
        {
            _contextManager.CurrentFor(TenantId.Development);
            return _next(context);
        }
    }
}