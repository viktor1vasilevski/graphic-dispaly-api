using Data.Repositories;
using EntityModels.Interfaces;
using Main.Interfaces;
using Main.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public static class DependencyContainer
    {
        public static void AddIoCService(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IFileRepository, FileRepository>();
        }
    }
}
