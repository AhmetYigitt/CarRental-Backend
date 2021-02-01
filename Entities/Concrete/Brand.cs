using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntitie
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

    }
}
