using System;
using Microsoft.Extensions.DependencyInjection;
using TSAK.PetShopComp._2021.Domain.IRepositories;
using TSAK.PetShopComp._2021.Domain.Services;
using TSAK.PetShopComp._2021.Infrastructure.DataAccess.Repositories;
using TSAK.PetShopComp._2021.IService;

namespace TSAK.PetShopComp._2021.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepositoryInMemory>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IPetService>();
            
            var menu = new PetMenu(service);
            menu.Start();

            Console.ReadLine();


        }
    }
    
}