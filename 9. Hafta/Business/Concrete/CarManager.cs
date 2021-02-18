using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
         ICarDal _cars;

        public CarManager(ICarDal cars)
        {
            _cars = cars;
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _cars.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _cars.GetAll(p => p.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _cars.GetCarDetails();
        }

        public void Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _cars.Add(car);
            }
            else
            {
                Console.WriteLine("Açıklamayı iki harften fazla giriniz ve günlük kiralama bedelini sıfırdan büyük giriniz.");
            }
        }

        public void Delete(Car car)
        {
            _cars.Delete(car);
        }

        public void Update(Car car)
        {
            _cars.Update(car);
        }
    }
}
