using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
            CarManager carManager = new CarManager(inMemoryCarDal);
            Console.WriteLine("Memory de bulunan veriler");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Brand Id :" + car.BrandId + " Coler Id :" + car.ColorId + " Daily Price :" + car.DailyPrice + " Model Year :" + car.ModelYear + " Description :" + car.Description);
            }

            //Updated
            Console.WriteLine();
            Console.WriteLine("Güncelleme yapıldıktan sonra veriler");
            Car updateCar = new Car() { Id = 1, BrandId = 4, ColorId = 4, DailyPrice = 700, ModelYear = 1996, Description = "Eflatun" };
            inMemoryCarDal.Update(updateCar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Brand Id :" + car.BrandId + " Coler Id :" + car.ColorId + " Daily Price :" + car.DailyPrice + " Model Year :" + car.ModelYear + " Description :" + car.Description);
            }

            //Added
            Console.WriteLine();
            Console.WriteLine("Ekleme yapıldıktan sonra veriler");
            Car addCar = new Car() { Id = 5, BrandId = 5, ColorId = 5, DailyPrice = 800,ModelYear = 2000, Description = "Mor" };
            inMemoryCarDal.Add(addCar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Brand Id :" + car.BrandId + " Coler Id :" + car.ColorId + " Daily Price :" + car.DailyPrice + " Model Year :" + car.ModelYear + " Description :" + car.Description);
            }
            Console.WriteLine();
            Console.WriteLine("Silme yapıldıktan sonra veriler");
            Car deleteCar = new Car() { Id = 5, BrandId = 5, ColorId = 5, DailyPrice = 800,ModelYear = 2012, Description = "Mor" };
            inMemoryCarDal.Delete(deleteCar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Brand Id :" + car.BrandId + " Coler Id :" + car.ColorId + " Daily Price :" + car.DailyPrice + " Model Year :" + car.ModelYear + " Description :" + car.Description);
            }
        }
    }
}
