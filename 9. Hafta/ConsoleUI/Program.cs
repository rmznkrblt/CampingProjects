using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car
                {Id=4, BrandId = 1, ColorId = 2, DailyPrice = 400, ModelYear = 2012, Description = "1 hafta alınacak"};
            Car car2 = new Car
                { Id = 4, BrandId = 3, ColorId = 4, DailyPrice = 700, ModelYear = 2010, Description = "3 hafta alınacak" };
            
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Veri tabanına Crud işlemleri yapılmadan önceki hali");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " / " +
                                  car.ModelYear + " / " + car.Description);
            }

            Console.WriteLine("\nEklenen veri");
            Add(carManager, car1);

            Console.WriteLine("\nEklenen veri güncellendi");
            Update(carManager, car2);

            Console.WriteLine("\nEklenen veri silindi");
            Delete(carManager, car1);

        }

        private static void Add(CarManager carManager, Car car1)
        {
            carManager.Add(car1);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " / " +
                                  car.ModelYear + " / " + car.Description);
            }
        }
        private static void Delete(CarManager carManager, Car car1)
        {
            carManager.Delete(car1);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " / " +
                                  car.ModelYear + " / " + car.Description);
            }
        }
        private static void Update(CarManager carManager, Car car1)
        {
            carManager.Update(car1);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " / " +
                                  car.ModelYear + " / " + car.Description);
            }
        }
    }
}