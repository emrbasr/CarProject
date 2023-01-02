using Business.Abstract;
using Business.Contains;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDal;

        public CarManager(ICarDAL carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
           
            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetByDailyPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetByDailyPrice(double min, double max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
