﻿using System.Collections.Generic;
using TSAK.PetShopComp._2021.Model;

namespace TSAK.PetShopComp._2021.IService
{
    public interface IInsuranceService
    {
        Insurance GetById(int id);
        
        Insurance Create(Insurance insurance);

        List<Insurance> ReadAll();
        
        Insurance Delete(int id);
        
        Insurance Update(Insurance insurance);
    }
}