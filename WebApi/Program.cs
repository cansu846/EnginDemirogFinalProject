using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers;
using Business.DependencyResolvers.Autofac;
using Core.Extentions;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Defaultta tan?mlanan configurasyonu bir yukar?da disabele edildi.
        //Olu?tudugumuz Custom Autofac config uuygulamam?za belirtir.
        // Autofac'i servis sa?lay?c? olarak kullanmas?n? sa?l?yoruz.
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        // Autofac modüllerini ya da özel konfigürasyonlar? burada eklenir.
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            // Burada özel modülleri veya servisleri kaydedebilirsiniz.
            containerBuilder.RegisterModule<AutofacBusinessModule>(); // Örnek modül
        });


        // Add services to the container.

        builder.Services.AddControllers();

        //Ioc container configuration
        //Singleton tüm bellekte sadece bir tane productManager nesnesi olu?turur.Tüm clientlar ayn? nesneye ait referans ula??r.
        //Eger içerisinde data tutmayacaksa Singleton kullan?l?r.
        //builder.Services.AddSingleton<IProductService, ProductManager>();
        //builder.Services.AddSingleton<IProductDal, EfProductDal>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        //Added Jwt configuration

        

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
                ValidAudience = builder.Configuration["TokenOptions:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });
        builder.Services.AddDependencyResolvers(new ICoreModule[] {
        
            new CoreModule()
        });
           
        //Jwt configuration end


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}