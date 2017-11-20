using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.LibraryTests
{
    [TestClass]
    public class BuilderTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void BuildIntegerSequenceTest()
        {
            //Arrange
            Builder listBuilder = new Builder();
            
            //Act
            var result = listBuilder.BuildIntegerSequence();
            
            //Analyze

            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void BuildStringSequenceTest()
        {
            //Arrange
            Builder listBuilder = new Builder();

            //Act
            var result = listBuilder.BuildStringSequence();

            //Analyze

            foreach (var item in result)
            {
                TestContext.WriteLine(item);
            }

            //Assert
            Assert.IsNotNull(result);
            
        }


        [TestMethod]
        public void CompareSequenceTest()
        {
            //Arrange
            Builder listBuilder = new Builder();

            //Act
            var result = listBuilder.CompareSequences();

            //Analyze

            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(result);

        }

    }
}
