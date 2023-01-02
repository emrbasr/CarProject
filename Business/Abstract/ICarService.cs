using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>>GetAll();
        IDataResult<List<Car>>GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetByDailyPrice(double price);
        IDataResult<List<Car>> GetByDailyPrice(double min,double max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int id);

        IResult Add(Car car);
    }
}
