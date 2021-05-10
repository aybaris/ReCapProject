using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId = 1 , BrandId = 1, ColorId=1 , DailyPrice = 250000 , ModelYear = 2021, Description = "Opel Corsa - Beyaz - Yeni Kasa"},
                new Car {CarId = 2 , BrandId = 2, ColorId=2 , DailyPrice = 158000 , ModelYear = 2021, Description = "Renault Kangoo - Füme Gri - Yeni Kasa"},
                new Car {CarId = 3 , BrandId = 2, ColorId=1 , DailyPrice = 129999 , ModelYear = 2021, Description = "Renault Dacia Logan - Beyaz - Yeni Kasa"},
                new Car {CarId = 4 , BrandId = 3, ColorId=3 , DailyPrice = 548000 , ModelYear = 2021, Description = "Volvo - Yeşil  - Yeni Kasa"},
                new Car {CarId = 5 , BrandId = 3, ColorId=4 , DailyPrice = 453700 , ModelYear = 2021, Description = "Volvo - Siyah - Yeni Kasa"},
            };

        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }
    }
}
