using Core.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDAL : EfEnitiyRepositoryBase<Car, SqlDbContext>, ICarDAL
    {
        public List<CarDetailDto> GetAll()
        {
            using (SqlDbContext context = new SqlDbContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.Id equals c.Id

                             join b in context.Brands
                             on c.Id equals b.BrandId

                             select new CarDetailDto { CarName=p.CarName,
                                 BrandName=b.BrandName,
                                 ColorName=c.Name,
                                 DailyPrice=p.DailyPrice
                             };

               return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
