using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Add(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var addedContext = context.Entry(entity);
                if (entity.DailyPrice > 0)
                {
                    addedContext.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Aracın günlük kiralama bedeli sıfırdan yüksek olmalı");
                }

            }
        }

        public void Delete(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var deletedContext = context.Entry(entity);
                deletedContext.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var updatedContext = context.Entry(entity);
                updatedContext.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Car> GetById(int id)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Car>().Where(p => p.Id == id).ToList();
            }
        }
    }
}
