using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
       // [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        [CacheAspect]
       // [SecuredOperation("car.list")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var results = _carDal.GetCarDetails();

            foreach (var result in results)
            {
                if (result.ImagePath == null)
                {
                    result.ImagePath = @"\Images\default.jpg";
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(results);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            var results = _carDal.GetCarDetails(p => p.BrandId == brandId);

            foreach (var result in results)
            {
                if (result.ImagePath == null)
                {
                    result.ImagePath = @"\Images\default.jpg";
                }
            }
            return new SuccessDataResult<List<CarDetailDto>>(results);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            var results = _carDal.GetCarDetails(p => p.ColorId == colorId);

            foreach (var result in results)
            {
                if (result.ImagePath == null)
                {
                    result.ImagePath = @"\Images\default.jpg";
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(results);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail(int carId)
        {
            var results = _carDal.GetCarDetails(p => p.Id == carId);

            foreach (var result in results)
            {
                if (result.ImagePath == null)
                {
                    result.ImagePath = @"\Images\default.jpg";
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(results);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            var results = _carDal.GetCarDetails(filter => filter.BrandId == brandId && filter.ColorId == colorId);

            foreach (var result in results)
            {
                if (result.ImagePath == null)
                {
                    result.ImagePath = @"\Images\default.jpg";
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(results);
        }
    }
}
