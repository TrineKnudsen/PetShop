﻿namespace TSAK.PetShopComp._2021.EF.Entities
{
    public class PetColorEntity
    {
        public int PetId { get; set; }
        public PetEntity Pet { get; set; }
        public int ColorId { get; set; }
        public ColorEntity Color { get; set; }
    }
}