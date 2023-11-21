
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Service.CMP_SPTS_Email;
using webapi.Service.DayByDay;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.MemoryStorage;



namespace webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(b =>
                {
                    // .AllowAnyOrigin() �����κ�����
                    b.WithOrigins("https://10.163.68.2:5002")
                              .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
                opt.AddPolicy("api", Depart =>
                {
                    Depart.WithOrigins("https://localhost:5002").AllowAnyMethod().AllowAnyHeader().AllowCredentials();

                });
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHangfire(config => {
                config.UseMemoryStorage();
            });
            /*//!   !   !
            //跨域所指向的地址
           *//* string[] urls = new[] { "https://10.163.68.2:5002" }; *//*
            //配置跨域
            builder.Services.AddCors(opt => {
                opt.AddPolicy(name: MyAllowSpecificOrigins, b =>
                {
                    b.WithOrigins("https://10.163.68.2:5002")
                    // .AllowAnyOrigin() 允许任何域名
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });
*/
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //D
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            RecurringJob.AddOrUpdate(() => Day_7_30.TimeFor(), "30 23 * * *");
            //跨域再加上
            app.UseCors("api");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //跨域再加上
            /*        app.UseCors();*/

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}