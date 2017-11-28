using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class InvoiceRepository
    {
        public List<Invoice> Retrieve()
        {
            List<Invoice> invoiceList = new List<Invoice>
            {
                new Invoice()
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 5, 5),
                    DueDate = new DateTime(2013, 6, 5),
                    IsPaid = null,
                    Amount = 199.99M,
                    NumberOfUnits = 20,
                    DiscountPercent = 0M
                },
                new Invoice()
                {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 7, 10),
                    DueDate = new DateTime(2013, 8, 15),
                    IsPaid = null,
                    Amount = 98.50M,
                    NumberOfUnits = 10,
                    DiscountPercent = 10M
                },
                new Invoice()
                {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2013, 7, 25),
                    DueDate = new DateTime(2013, 8, 25),
                    IsPaid = null,
                    Amount = 250M,
                    NumberOfUnits = 25,
                    DiscountPercent = 10M
                },
                new Invoice()
                {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2013, 9, 19),
                    DueDate = new DateTime(2013, 10, 29),
                    IsPaid = true,
                    Amount = 20M,
                    NumberOfUnits = 2,
                    DiscountPercent = 15M
                },
                new Invoice()
                {
                InvoiceId = 5,
                CustomerId = 1,
                InvoiceDate = new DateTime(2013, 7, 21),
                DueDate = new DateTime(2013, 11, 2),
                IsPaid = true,
                Amount = 225M,
                NumberOfUnits = 28,
                DiscountPercent = 10M
                },
                new Invoice()
                {
                    InvoiceId = 6,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2018, 10, 9),
                    DueDate = new DateTime(2018, 11, 8),
                    IsPaid = false,
                    Amount = 75M,
                    NumberOfUnits = 8,
                    DiscountPercent = 0M
                },
                new Invoice()
                {
                    InvoiceId = 7,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2016, 1, 1),
                    DueDate = new DateTime(2016, 2, 2),
                    IsPaid = null,
                    Amount = 500M,
                    NumberOfUnits = 42,
                    DiscountPercent = 10M
                },
                new Invoice()
                {
                    InvoiceId = 8,
                    CustomerId = 4,
                    InvoiceDate = new DateTime(2017, 9, 9),
                    DueDate = new DateTime(2017, 10, 10),
                    IsPaid = true,
                    Amount = 75M,
                    NumberOfUnits = 7,
                    DiscountPercent = 0M
                }
            };

            return invoiceList;

        }

        public List<Invoice> Retrieve(int customerId)
        {
            var invoiceList = this.Retrieve();
            List<Invoice> filteredList = invoiceList.Where(i => i.CustomerId == customerId).ToList();
            return filteredList;
        }


        public decimal CalculateMean(List<Invoice> invoiceList)
        {
            return invoiceList.Average(inv => inv.DiscountPercent);

        }

        public decimal CalculateMedian(List<Invoice> invoiceList)
        {
            var sortedList = invoiceList.OrderBy(inv => inv.DiscountPercent);
            int count = invoiceList.Count;
            int position = count / 2;

            decimal median;

            if ((count%2) == 0)
            {
                median = (sortedList.ElementAt(position).DiscountPercent +
                          sortedList.ElementAt(position - 1).DiscountPercent) / 2;
            }
            else
            {
                median = sortedList.ElementAt(position).DiscountPercent;
            }
            return median;
        }

        public decimal CalculateMode(List<Invoice> invoiceList)
        {
            var mode = invoiceList.GroupBy(inv => inv.DiscountPercent)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();
            return mode;
        }

        public decimal CalculateTotalAmountInvoiced(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.TotalAmount);
        }

        public int CalculateTotalUnitsSold(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.NumberOfUnits);
        }

        public dynamic GetInvoiceTotalByIsPaid(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(c => c.IsPaid ?? false, 
                                            inv => inv.TotalAmount,
                                            (groupKey, invTotal) => new
                                            {
                                                Key = groupKey,
                                                InvoicedAmount = invTotal.Sum()
                                            });
            foreach (var item in query)
            {
                Console.WriteLine(item.Key + ": " + item.InvoicedAmount);
            }
            return query;
        }

        public dynamic GetInvoicedTotalByIsPaidInMonth(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(inv =>
                                             new
                                                {
                                                     IsPaid = inv.IsPaid ?? false,
                                                     InvoiceMonth = inv.InvoiceDate.ToString("MMMM")
                                                 },
                                            inv => inv.TotalAmount,
                                            (groupKey, invTotal) => new
                                                {
                                                    Key = groupKey,
                                                    InvoicedAmount = invTotal.Sum()
                                                });
            foreach (var item in query)
            {
                Console.WriteLine(item.Key.IsPaid + "/" + item.Key.InvoiceMonth + ": " + item.InvoicedAmount);
            }
            return query;

        }


    }
}
