﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDBContext context = new CarDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join k in context.Colors
                             on c.ColorId equals k.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = k.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
                             
            }
        }
    }
}
