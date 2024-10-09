
using Microsoft.EntityFrameworkCore;
using Entities;
using Warehouse.core.ICommon;
using Warehouse.core.IRepository;
using Warehouse.infra.Repository;
using Warehouse.core.IService;
using Warehouse.infra.Service;
using Warehouses.core.IRepository;
using Warehouses.infra.Repository;
using Warehouses.core.IService;
using Warehouses.infra.Service;

namespace Warehouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ModelContext>(x => x.UseOracle(builder.Configuration.GetConnectionString("DBConnectionString")));
            builder.Services.AddScoped<IDbContext,infra.Common.DbContext>();

            //Repository
            builder.Services.AddScoped<IWarehouseRepository,WarehouseRepository>();
            builder.Services.AddScoped<ISupplyDocumentRepository, SupplyDocumentRepository>();
            //Service
            builder.Services.AddScoped<IWarehouseService,WarehouseService>();
            builder.Services.AddScoped<ISupplyDocumentService,SupplyDocumentService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("policy");

            app.MapControllers();

            app.Run();
        }
    }
}
