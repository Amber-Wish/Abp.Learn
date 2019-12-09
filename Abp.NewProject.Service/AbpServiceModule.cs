using System.IO;
using Abp.NewProject.Application;
using Abp.NewProject.Domain;
using Abp.NewProject.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Abp.NewProject.Service
{
    [DependsOn(typeof(AbpAutofacModule), 
        //typeof(AbpAspNetCoreMvcModule), 
        typeof(AbpAspNetCoreMvcUiModule),
        typeof(AbpEfCoreModule),typeof(AbpDomainModule),typeof(AbpApplicationModule))]
    public class AbpServiceModule:AbpModule
    {

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpServiceModule>();
            });
        }


        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Book API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API");
            });

            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}