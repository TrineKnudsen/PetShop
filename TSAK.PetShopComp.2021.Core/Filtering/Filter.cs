using System;

namespace TSAK.PetShopComp._2021.Filtering
{
    public class Filter
    {
        public int Limit { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
        public string OrderDir { get; set; }
        public int Page { get; set; }
    }
}