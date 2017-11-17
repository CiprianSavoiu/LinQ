using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Library.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        public TestContext TestContext { get; set; }


        [TestMethod()]
        public void ConvertToTitleCaseTest()
        {
            //Arrange
            var source = "the return of the king";
            var expected = "The Return Of The King";

            //Act
            //var result = StringExtensions.ConvertToTitleCase(source);
            var result = source.ConvertToTitleCase();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);

        }
    }
}