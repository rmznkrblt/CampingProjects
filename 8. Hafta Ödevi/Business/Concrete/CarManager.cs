using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : CarService
    {
        private ICarDal _cars;

        public CarManager(ICarDal cars)
        {
            _cars = cars;
        }

        public List<Car> GetAll()
        {
            return _cars.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _cars.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _cars.GetAll(p => p.ColorId == id);
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _cars.Add(car);
            }
            else
            {
                Console.WriteLine("Lütfen günlük kiralama bedelini sıfırdan büyük giriniz!!!");
            }
        }
    }
}
