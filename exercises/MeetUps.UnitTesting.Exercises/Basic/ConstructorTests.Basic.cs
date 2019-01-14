using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public partial class ConstructorTests
    {
        //Based on the following test cases, build the corresponding constructor
        [Test]
        public void MyClassConstructor_NegativeParam1_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                //Act
                var myClass = new MyClass(-1, null);

                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                //Assert
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail("Exception thrown is not the expected");
            }
        }

        [Test]
        public void MyClassConstructor_NullParam2_ThrowsArgumentNullException()
        {
            try
            {
                //Act
                var myClass = new MyClass(0, null);

                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                //Assert
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail("Exception thrown is not the expected");
            }
        }

        [Test]
        public void MyClassConstructor_EmptyParam2_ThrowsArgumentNullException()
        {
            try
            {
                //Act
                var myClass = new MyClass(0, string.Empty);

                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                //Assert
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail("Exception thrown is not the expected");
            }
        }

        [Test]
        public void MyClassConstructor_ValidParams_ObjectIsConstructed()
        {
            //Arrange
            var param1 = 5;
            var param2 = "param2";

            //Act
            var myClass = new MyClass(param1, param2);

            //Assert
            Assert.AreEqual(param1, myClass.Param1);
            Assert.AreEqual(param2, myClass.Param2);
        }

        //Based on MyClass2's constructor, build the corresponding tests
        [Test]
        public void MyClass2Constructor_NullList1_ThrowsArgumentNullException()
        {
            Assert.Fail();
        }

        [Test]
        public void MyClass2Constructor_EmptyList1_ThrowsArgumentException()
        {
            Assert.Fail();
        }

        [Test]
        public void MyClass2Constructor_ValidList1_ObjectIsConstructed()
        {
            Assert.Fail();
        }
    }

    internal class MyClass
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public MyClass(int param1, string param2)
        {

        }
    }

    internal class MyClass2
    {
        private List<int> _list1;
        public IReadOnlyList<int> List1 => _list1;

        public MyClass2(IEnumerable<int> list1)
        {
            if (list1 == null)
            {
                throw new ArgumentNullException(nameof(list1));
            }

            if (list1.Count() == 0)
            {
                throw new ArgumentException("Cannot be empty", nameof(list1));
            }

            _list1 = list1.ToList();
        }
    }
}