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
    public class CustomerRepositoryTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
        public void FindTestExistingCustomer()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();
            
            //Act
            var result = customerRepository.Find(customerList, 2);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod()]
        public void FindTestNotFound()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();

            //Act 
            var result = customerRepository.Find(customerList, 42);
            
            //Assert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void SortByNameTest()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();
            //Act 
            var result = customerRepository.SortByName(customerList);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().CustomerId);
            Assert.AreEqual("Baggins", result.First().LastName);
            Assert.AreEqual("Bilbo", result.First().FirstName);
        }


        [TestMethod]
        public void SortByNameInReverseTest()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();
            //Act 
            var result = customerRepository.SortByNameInReverse(customerList);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Last().CustomerId);
            Assert.AreEqual("Baggins", result.Last().LastName);
            Assert.AreEqual("Bilbo", result.Last().FirstName);
        }

        [TestMethod]
        public void SortByTypeTest()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();
            //Act 
            var result = customerRepository.SortByType(customerList);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.Last().CustomerTypeId);
        }


        [TestMethod]
        public void GetNamesTest()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();
            //Act 
            var query = customerRepository.GetNames(customerList);
            //Analyze
            foreach (var item in query)
            {
                TestContext.WriteLine(item);
            }
            //Assert
            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetNamesAndEmailTest()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();
            //Act 
            var query = customerRepository.GetNamesAndEmail(customerList);
            //Analyze
           
        }


        [TestMethod]
        public void GetNamesAndTypeTest()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();

            CustomerTypeRepository typerRepository = new CustomerTypeRepository();
            var customerTypeList = typerRepository.Retrieve();
            //Act 
            var query = customerRepository.GetNamesAndType(customerList, customerTypeList);
            
            
            //NOT REALLY A TEST

        }

        [TestMethod]
        public void GetOverdueCustomersTest()
        {
            //Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();

            //Act 
            var query = customerRepository.GetOrvedueCustomers(customerList);

            //Analyze
            foreach (var item in query)
            {
                TestContext.WriteLine(item.LastName + ", " + item.FirstName);
            }

            //Assert
            Assert.IsNotNull(query);

        }


    }
}