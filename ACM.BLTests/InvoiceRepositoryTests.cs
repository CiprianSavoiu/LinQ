using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Tests
{
    [TestClass()]
    public class InvoiceRepositoryTests
    {
        [TestMethod()]
        public void CalculateMeanTest()
        {
            //Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoiceList = invoiceRepository.Retrieve();
            //Act 
            var actual = invoiceRepository.CalculateMean(invoiceList);

            //Assert
            Assert.AreEqual(6.875M, actual);

        }


        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoiceList = invoiceRepository.Retrieve();
            //Act 
            var actual = invoiceRepository.CalculateTotalAmountInvoiced(invoiceList);

            //Assert
            Assert.AreEqual(1333.14M, actual);

        }

        [TestMethod()]
        public void CalculateTotalUnitsSoldTest()
        {
            //Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoiceList = invoiceRepository.Retrieve();
            //Act 
            var actual = invoiceRepository.CalculateTotalUnitsSold(invoiceList);

            //Assert
            Assert.AreEqual(142, actual);
        }

        [TestMethod()]
        public void GetInvoiceTotalByIsPaidTest()
        {
            //Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoiceList = invoiceRepository.Retrieve();
            //Act 
            var query = invoiceRepository.GetInvoiceTotalByIsPaid(invoiceList);

            //not realy a test
        }

        [TestMethod()]
        public void GetInvoicedTotalByIsPaidInMonthTest()
        {
            //Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoiceList = invoiceRepository.Retrieve();
            //Act 
            var query = invoiceRepository.GetInvoicedTotalByIsPaidInMonth(invoiceList);

            //not realy a test
        }

        [TestMethod()]
        public void CalculateMedianTest()
        {
            //Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoiceList = invoiceRepository.Retrieve();
            //Act 
            var actual = invoiceRepository.CalculateMedian(invoiceList);

            //Assert
            Assert.AreEqual(10, actual);
        }

        [TestMethod()]
        public void CalculateModeTest()
        {
            //Arrange
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            var invoiceList = invoiceRepository.Retrieve();
            //Act 
            var actual = invoiceRepository.CalculateMode(invoiceList);

            //Assert
            Assert.AreEqual(10, actual);
        }
    }
}