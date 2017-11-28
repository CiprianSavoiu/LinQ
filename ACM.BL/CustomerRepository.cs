 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public List<Customer> Retrieve()
        {
            InvoiceRepository invoiceRepository = new InvoiceRepository();

            List<Customer> custList = new List<Customer>
            {new Customer()
                { CustomerId = 1,
                    FirstName="Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId=1,
                    InvoiceList = invoiceRepository.Retrieve(1)},
                new Customer()
                { CustomerId = 2,
                    FirstName="Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId=null,
                    InvoiceList = invoiceRepository.Retrieve(2)},
                new Customer()
                { CustomerId = 3,
                    FirstName="Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId=2,
                    InvoiceList = invoiceRepository.Retrieve(3)},
                new Customer()
                { CustomerId = 4,
                    FirstName="Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId=4,
                    InvoiceList = invoiceRepository.Retrieve(4)} };
            return custList;
        }



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

            //var query = from c in custmoreList
            //    where c.CustomerId == customerId
            //    select c;
            //foundCustomer = query.First();

            foundCustomer = custmoreList.FirstOrDefault(c => c.CustomerId == customerId);
            

            return foundCustomer;
        }

        public IEnumerable<string> GetNames(List<Customer> customerList)
        {
            var query = customerList.Select(c => c.LastName + "," + c.FirstName);
            return query;
        }

        //dynamic not recommended to use as a return from a function
        public dynamic GetNamesAndEmail(List<Customer> customerList)
        {
            var query = customerList.Select(c => new
            {
                Name = c.LastName + " , " + c.FirstName,
                Email = c.EmailAddress
            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + ":" + item.Email);
            }
            return query;
        }


        public dynamic GetNamesAndId(List<Customer> customersList)
        {
            var query = customersList.OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Select(c => new
                {
                    Name = c.LastName + ", " + c.FirstName,
                    c.CustomerId
                });
            return query;
        }

        public dynamic GetNamesAndType(List<Customer> customerList,
                                        List<CustomerType> customerTypeList)
        {
            var query = customerList.Join(customerTypeList,
                c => c.CustomerTypeId,
                ct => ct.CustomerTypeId,
                (c, ct) => new
                {
                    Name = c.LastName + ", " + c.FirstName,
                    CustomerTypeName = ct.TypeName
                });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " : " + item.CustomerTypeName);
            }

            return query;
        }


        public IEnumerable<Customer> GetOrvedueCustomers(List<Customer> customerList)
        {
            var query = customerList
                .SelectMany(c => c.InvoiceList
                                .Where(i => (i.IsPaid ?? false) == false),
                                (c, i) => c).Distinct();
            return query;

        }


        public IEnumerable<KeyValuePair<string, decimal>> GetInvoiceTotalByCustomerType(List<Customer> customerList, 
                                                        List<CustomerType> customerTypeList)
        {

            var customerTypeQuery = customerList.Join(customerTypeList,
                c => c.CustomerTypeId,
                ct => ct.CustomerTypeId,
                (c, ct) => new
                {
                    CustomerInstance = c,
                    CustomerTypeName = ct.TypeName
                });

            var query = customerTypeQuery.GroupBy(c => c.CustomerTypeName,
                c => c.CustomerInstance.InvoiceList.Sum(inv => inv.TotalAmount),
                (groupKey, invTotal) => new KeyValuePair<string, decimal>(groupKey, invTotal.Sum())
               
            );

            foreach (var item in query)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            return query;
        }


        public IEnumerable<Customer> SortByName(List<Customer> customersList)
        {
            return customersList.OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse(List<Customer> customerList)
        {
            //return customerList.OrderByDescending(c => c.LastName)
            //    .ThenByDescending(c => c.FirstName);

            return SortByName(customerList).Reverse();
        }

        public IEnumerable<Customer> SortByType(List<Customer> customerList)
        {
            return customerList.OrderByDescending(c => c.CustomerTypeId.HasValue)
                .ThenBy(c => c.CustomerTypeId);
        }

        public IEnumerable<Customer> RetrieveEmptyList()
        {
            return Enumerable.Repeat(new Customer(), 5);
        }



    }
}
