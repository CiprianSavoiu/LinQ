﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public Customer Find(List<Customer> custmoreList, int customerId)
        {
            Customer foundCustomer = null;
            //foreach (var c in custmoreList)
            //{
            //    if (c.CustomerId == customerId)
            //    {
            //        foundCustomer = c;
            //        break;
            //    }
            //}

            var query = from c in custmoreList
                where c.CustomerId == customerId
                select c;
            foundCustomer = query.First();
            return foundCustomer;
        }


        public List<Customer> Retrieve()
        {
            List<Customer> custList = new List<Customer>
            {new Customer()
                { CustomerId = 1,
                    FirstName="Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId=1},
                new Customer()
                { CustomerId = 2,
                    FirstName="Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId=null},
                new Customer()
                { CustomerId = 3,
                    FirstName="Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId=1},
                new Customer()
                { CustomerId = 4,
                    FirstName="Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId=2}};
            return custList;
        }

    }
}
