﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length <3)
            {
                Console.WriteLine("acıklama en az 2 karakter olmalıdır ");
            }
            else if (car.DailyPrice < 1 )
            {
                Console.WriteLine("Günlük ücret 0 dan büyük olmalı");
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            Console.WriteLine("Araba silindi");
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}