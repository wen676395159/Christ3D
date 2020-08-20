using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Christ3D.Application.Interfaces;
using Christ3D.Domain.CommandHandlers;
using Christ3D.Domain.Commands;
using Christ3D.Domain.EventHandlers;
using Christ3D.Domain.Events.Student;
using Christ3D.Domain.Interfaces;
using Christ3D.DomainCore.Bus;
using Christ3D.Infrastruct.Data.Context;
using Christ3D.Infrastruct.Data.Repository;
using Christ3D.Infrastruct.Data.UnitOfwork;
using Christ3D.UI.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Christ3D.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapperSetup();
            services.AddScoped<IStudentAppService, StudengtAppService>();


            // 注入 Infra - Data 基础设施数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();//上下文
            services.AddMediatR(typeof(Startup));

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();
           services.AddScoped<INotificationHandler<StudentRegisteredEvent>,StudentEventHandler>();
               services.AddScoped<INotificationHandler<StudentUpdatedEvent>,StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentRemovedEvent>,StudentEventHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
