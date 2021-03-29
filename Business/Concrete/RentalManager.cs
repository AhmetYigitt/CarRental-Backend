using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        { 
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRented);   
        }

        //public IResult CarDelivery(int carId)
        //{
        //    var updatedRental = (_rentalDal.GetAll(c => c.CarId == carId)).LastOrDefault();
        //    if (updatedRental.ReturnDate != null)
        //    {
        //        return new ErrorResult(Messages.ErrorCarDelivery);
        //    }
        //    updatedRental.ReturnDate = DateTime.Now;
        //    _rentalDal.Update(updatedRental);
        //    return new SuccessResult(Messages.CarDeliverd);
        //}

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentCarDetailDto>> GetRentCarDetail()
        {
            return new SuccessDataResult<List<RentCarDetailDto>>(_rentalDal.GetRentCarDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult CheckCarRentDate(Rental rental)
        {
            var results = _rentalDal.GetRentCarDetails(p => p.CarId == rental.CarId);


            foreach (var result in results)
            {
                if ((rental.RentDate >= result.RentDate && rental.RentDate <= result.ReturnDate) ||
                    (rental.ReturnDate >= result.RentDate && rental.ReturnDate <= result.ReturnDate) ||
                    (result.RentDate >= rental.RentDate && result.RentDate <= rental.ReturnDate))
                {
                    return new ErrorResult(Messages.ReturnDateInavlid);
                }
            }

            return new SuccessResult();
        }
    }
}
