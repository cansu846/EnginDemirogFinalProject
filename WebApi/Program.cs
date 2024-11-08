using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Defaultta tan?mlanan configurasyonu bir yukar?da disabele edildi.
        //Olu?tudugumuz Custom Autofac config uuygulamam?za belirtir.
        // Autofac'i servis sa?lay?c? olarak kullanmas?n? sa?l?yoruz.
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        // Autofac mod�llerini ya da �zel konfig�rasyonlar? burada eklenir.
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            // Burada �zel mod�lleri veya servisleri kaydedebilirsiniz.
            containerBuilder.RegisterModule<AutofacBusinessModule>(); // �rnek mod�l
        });


        // Add services to the container.

        builder.Services.AddControllers();

        //Ioc container configuration
        //Singleton t�m bellekte sadece bir tane productManager nesnesi olu?turur.T�m clientlar ayn? nesneye ait referans ula??r.
        //Eger i�erisinde data tutmayacaksa Singleton kullan?l?r.
        //builder.Services.AddSingleton<IProductService, ProductManager>();
        //builder.Services.AddSingleton<IProductDal, EfProductDal>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}