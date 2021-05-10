using Core.DataAccess.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join clr in context.Colors
                             on car.ColorId equals clr.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 ColorName = clr.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
