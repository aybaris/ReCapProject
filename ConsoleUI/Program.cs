using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

           
                CarManager carManager = new CarManager(new EfCarDal());

                foreach (var car in carManager.GetAll())
                {
                    Console.WriteLine("Marka Bilgi : "+car.Description);
                    Console.WriteLine("Günlük fiyatı: "+ car.DailyPrice);
                    Console.WriteLine("Model yılı : " +car.ModelYear);


               
        }

          
        }
    }
}
