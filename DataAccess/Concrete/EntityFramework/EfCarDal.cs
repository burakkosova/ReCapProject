﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto { CarName = car.Name, ColorName = color.Name, DailyPrice = car.DailyPrice, BrandName = brand.Name };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             where car.ColorId == colorId 
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto { CarName = car.Name, ColorName = color.Name, DailyPrice = car.DailyPrice, BrandName = brand.Name };
                return result.ToList();
            }
        }
        
        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             where car.BrandId == brandId 
                             select new CarDetailDto { CarName = car.Name, ColorName = color.Name, DailyPrice = car.DailyPrice, BrandName = brand.Name };
                return result.ToList();
            }
        }
    }
}
