using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllCars();
            GetCarsdetails();
            //GetCarbyBrandId();
           // AddCar();
           // GetAllBrands();
            //GetAllColors();
             //AddBrand();
           //AddColor();

        }

        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 9,ColorName = "Lila" });
            Console.WriteLine("Yeni renk eklendi");
        }

        private static void GetAllColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "/" + color.ColorName);
            }
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 10, BrandName = "Lada" });
            Console.WriteLine("Yeni marka eklendi");
        }

        private static void GetAllBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "//" + brand.BrandName);
            }
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 8, ColorId = 6, DailyPrice = 545, Description = "RANGE ROVER", ModelYear = 2017 });
            Console.WriteLine("Yeni araç eklendi");
        }

        private static void GetCarbyBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var brandid in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(brandid.BrandId + "//" + brandid.Description);
            }
        }

        private static void GetCarsdetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var cardetail in result.Data)
                {
                    Console.WriteLine("CarName " + cardetail.Description + "/ BrandName " + cardetail.BrandName + "/ColorName " + cardetail.ColorName + " /DailyPrice" + cardetail.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Marka Bilgi : " + car.Description);
                Console.WriteLine("Günlük fiyatı: " + car.DailyPrice);
                Console.WriteLine("Model yılı : " + car.ModelYear);

            }
        }
    }
}
