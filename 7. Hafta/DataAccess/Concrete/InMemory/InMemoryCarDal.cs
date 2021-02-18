using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 300,ModelYear = 2009,Description = "Kırmızı"},
                new Car(){Id = 2,BrandId = 2,ColorId = 2,DailyPrice = 100,ModelYear = 2002,Description = "Mavi"},
                new Car(){Id = 3,BrandId = 3,ColorId = 3,DailyPrice = 500,ModelYear = 2006,Description = "Turuncu"}
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteToCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(deleteToCar);
        }

        public void Update(Car car)
        {
            Car updateToCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            updateToCar.ColorId = car.ColorId;
            updateToCar.DailyPrice = car.DailyPrice;
            updateToCar.BrandId = car.BrandId;
            updateToCar.ModelYear = car.ModelYear;
            updateToCar.Description = car.Description;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }
    }
}
