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
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
          
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            var result= new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            return result;
        }

        public IDataResult<List<Car>> GetByDailyPrice(double price)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice == price),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(double min, double max)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p=>p.DailyPrice>=min && p.DailyPrice<=max));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
