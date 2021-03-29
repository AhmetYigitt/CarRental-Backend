using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Entities;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }
        public string CardCvv { get; set; }
        public int AmountPaye { get; set; }
    }
}
