using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, MyCarDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (MyCarDatabaseContext context = new MyCarDatabaseContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 CompanyName = customer.CompanyName
                             };
                return result.ToList();
            }
            
        }
    }
}
