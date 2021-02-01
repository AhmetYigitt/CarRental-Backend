using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId=1, ColorId=1, BrandId=1, DailyPrice=1500000, ModelYear=2019, Description="Mercedes Amg"},
                new Car{ CarId=2, ColorId=1, BrandId=2, DailyPrice=2100000, ModelYear=2020, Description="Porsche Taycan"},
                new Car{ CarId=3, ColorId=2, BrandId=2, DailyPrice=350000, ModelYear=2018, Description="Audi A6"},
                new Car{ CarId=4, ColorId=3, BrandId=2, DailyPrice=150000, ModelYear=2017, Description="Renault Clio"},
                new Car{ CarId=5, ColorId=3, BrandId=3, DailyPrice=30000, ModelYear=2000, Description="Tofaş Slx"},
                new Car{ CarId=6, ColorId=4, BrandId=4, DailyPrice=10000, ModelYear=1985, Description="Renault Toros"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        List<Car> ICarDal.GetByBrandId(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        List<Car> ICarDal.GetByColorId(int colorId)
        {
            return _cars.Where(p => p.ColorId == colorId).ToList();
        }
    }
}
