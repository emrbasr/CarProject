using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEnitiyRepositoryBase<Color, SqlDbContext>, IColorDal
    {

    }
}
