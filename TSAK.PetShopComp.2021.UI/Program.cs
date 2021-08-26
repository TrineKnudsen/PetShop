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
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepositoryInMemory>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IPetService>();
            var typeServiceProvider = serviceCollection.BuildServiceProvider();
            var typeService = typeServiceProvider.GetRequiredService<IPetTypeService>();
            
            
            var menu = new PetMenu(service, typeService);
            menu.Start();

            Console.ReadLine();


        }
    }
    
}