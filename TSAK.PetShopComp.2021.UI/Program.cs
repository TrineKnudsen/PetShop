using System;

namespace TSAK.PetShopComp._2021.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new PetMenu(repo);
            menu.Start();
        }
    }
}