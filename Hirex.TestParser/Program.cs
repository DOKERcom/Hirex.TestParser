using DataAccessLayer.DbContexts;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Hirex.TestParser.BLL.Factories.Implementations;
using Hirex.TestParser.BLL.Factories.Interfaces;
using Hirex.TestParser.Factories.Implementations;
using Hirex.TestParser.Factories.Interfaces;
using Hirex.TestParser.Handlers.Implementations;
using Hirex.TestParser.Handlers.Interfaces;
using Hirex.TestParser.Services.Implementations;
using Hirex.TestParser.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hirex.TestParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            services
                .AddSingleton<Executor, Executor>()
                .BuildServiceProvider()
                .GetService<Executor>()
                .Execute();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HirexDbContext>();

            services.AddScoped<IModelToEntityFactory, ModelToEntityFactory>();
            services.AddScoped<IEntityUpdateByModelFactory, EntityUpdateByModelFactory>();

            services.AddScoped<IDesignersRepository, DesignersRepository>();
            services.AddScoped<IWorkRepository, WorkRepository>();
            

            services.AddScoped<IDesignersService, DesignersService>();

            services.AddScoped<IParsingHandler, ParsingHandler>();

            


        }
    }
    public class Executor
    {
        private readonly IParsingHandler _parsingHandler;

        public Executor(IParsingHandler parsingHandler)
        {
            _parsingHandler = parsingHandler;
        }

        public void Execute()
        {
            _parsingHandler.Parse();
        }
    }
}
