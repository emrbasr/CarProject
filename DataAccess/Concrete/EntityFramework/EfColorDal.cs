﻿using DataAccess.Abstract;
using Core.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal :EfEnitiyRepositoryBase<Color,SqlDbContext> ,IColorDal
    {
        
    }
}
