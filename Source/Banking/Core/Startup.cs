using Autofac;
using Dolittle.Booting;
using Dolittle.DependencyInversion.Autofac;
using Dolittle.AspNetCore.Debugging.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
        private BootloaderResult _bootResult;

        public Startup(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDolittleSwagger();

            _bootResult = services.AddDolittle(_loggerFactory);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddDolittle(_bootResult.Assemblies, _bootResult.Bindings);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDolittleSwagger();
            }

            app.UseDolittle();
            app.UseMiddleware<ExecutionContextMiddleware>();
            app.UseMvc();
        }
    }
}