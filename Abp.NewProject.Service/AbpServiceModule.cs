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
            //context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            //{
            //    options.AddAssemblyResource(
            //        typeof(BookResource),
            //        typeof(BookDomainSharedModule).Assembly,
            //        typeof(BookApplicationContractsModule).Assembly,
            //        typeof(BookWebHostModule).Assembly
            //    );
            //});
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            
            ConfigureAutoMapper();
            //ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpServiceModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}XXG.Study.ABPNext.Book.Domain", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}XXG.Study.ABPNext.Book.Application.Contracts", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpServiceModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}{0}XXG.Study.ABPNext.Book.Web", Path.DirectorySeparatorChar)));
                });
            }
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Book API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
            //services.AddMvcCore()
            //    .AddApiExplorer();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    //app.UseErrorPage();
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseVirtualFiles();
            //app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            //app.UseAbpRequestLocalization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API");
            });

            //app.UseAuditing();

            //app.UseMvcWithDefaultRouteAndArea();
        }
    }
}