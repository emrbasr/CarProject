using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEnitiyRepositoryBase<Brand, SqlDbContext>, IBrandDal
    {

    }
}
