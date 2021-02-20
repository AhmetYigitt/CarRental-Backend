using Business.Abstract;
using Business.Constants;
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

            var result = _rentalDal.GetRentCarDetails(p => p.CarId == rental.CarId && p.ReturnDate == null);
            if (result.Count>0)
            {
                return new ErrorResult(Messages.ReturnDateInavlid);
            }

            rental.RentDate = DateTime.Now;
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRented);   
        }

        public IResult CarDelivery(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId);
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.ErrorCarDelivery);
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult(Messages.CarDeliverd);
        }

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
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
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
    }
}
