// See https://aka.ms/new-console-template for more information

using DAL;
using HotelApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddDbContext<HotelDbContext>();
        //services.AddSingleton<IRepositoryProvider, UnitOfWork>();
        services.AddHostedService<Test>();
    });
    
var app = host.Build();

app.Run();