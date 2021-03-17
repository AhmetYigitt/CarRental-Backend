using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyCarDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (MyCarDatabaseContext context = new MyCarDatabaseContext())
            {
                
                var result = from car in filter is null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands 
                             on car.BrandId equals brand.Id 
                             join color in context.Colors 
                             on car.ColorId equals color.Id
                                 
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 ImagePath = (from a in context.CarImages where a.CarId == car.Id select a.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }
      
        
    }
}
