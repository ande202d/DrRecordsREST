using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class RecordTest
    {
        private Record r1;


        [TestInitialize]
        public void TestInit()
        {
            r1 = new Record("hej med dig", "mit navn er Anders", 27, 28);
        }

        [TestMethod]
        public void TestDuration1()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => r1.DurationInSeconds = 4);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => r1.DurationInSeconds = 5);

            r1.DurationInSeconds = 6;

            Assert.AreEqual(6, r1.DurationInSeconds);
        }

        [TestMethod]
        public void TestYearOfPublication1()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => r1.DurationInSeconds = -1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => r1.DurationInSeconds = 0);

            r1.YearOfPublication = 1;

            Assert.AreEqual(1, r1.YearOfPublication);
        }

        [TestMethod]
        public void TestArtist()
        {
            Assert.ThrowsException<ArgumentException>(() => r1.Artist = "he");
            Assert.ThrowsException<ArgumentNullException>(() => r1.Artist = null);

            r1.Artist = "hej";

            Assert.AreEqual("hej", r1.Artist);
        }

        [TestMethod]
        public void TestTitle()
        {
            Assert.ThrowsException<ArgumentException>(() => r1.Title = "");
            Assert.ThrowsException<ArgumentNullException>(() => r1.Title = null);

            r1.Title = "h";

            Assert.AreEqual("h", r1.Title);
        }
    }
}
