﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public DateTime ModelYear { get; set; }= DateTime.Now;
        public double DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
