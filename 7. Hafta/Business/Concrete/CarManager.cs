using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
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
    }
}
