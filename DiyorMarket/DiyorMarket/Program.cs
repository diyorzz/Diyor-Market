using DiyorMarket.Extensions;
using DiyorMarket.Middlewares;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace DiyorMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            builder.Services.AddControllers()
                .AddNewtonsoftJson()
                .AddXmlSerializerFormatters();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
            builder.Services.ConfigureLogger();
            builder.Services.ConfigureRipositories();
            builder.Services.ConfigureDatabaseContext();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options => options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "MarketUz-api",
                    ValidAudience = "MarketUz",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("login marketuzbbbbbbbbb"))
                });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                builder.Services.SeedDatabase(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHendlerMiddlewares>();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}