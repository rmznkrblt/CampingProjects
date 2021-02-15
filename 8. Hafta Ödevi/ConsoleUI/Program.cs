using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hatalı değer girildi
            Car car1=new Car
            {
                BrandId = 4,ColorId = 1,DailyPrice = 0,Description= "1 hafta alınacak",ModelYear = 2013
            };

            //Doğru değer girildi
            Car car2 = new Car
            {
                BrandId = 4, ColorId = 2, DailyPrice = 110, Description = "1 hafta alınacak", ModelYear = 1999
            };
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
	    carManager.Add(car2);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + Math.Round(car.DailyPrice, 2) + " / " + car.ModelYear + " / " + car.Description);
            }
        }
    }
}
