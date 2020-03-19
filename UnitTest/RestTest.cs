using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using DrRecordsREST.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class RestTest
    {
        private Record r1;
        private RecordsController controller;

        [TestInitialize]
        public void TestInit()
        {
            r1 = new Record("AndersUndervisning", "Anders", 69, 2020);
            controller = new RecordsController();
            controller.Clear();
        }

        [TestMethod]
        public void TestPost1()
        {
            Record rr1 = controller.Post(r1);
            Assert.AreEqual("Anders", rr1.Artist);
        }
        
        [TestMethod]
        public void TestPost2()
        {
            controller.Post(r1);
            controller.Post(r1);
            Record rr1 = controller.Post(r1);
            
            Assert.AreEqual(3, rr1.Id);
        }
        [TestMethod]
        public void TestGetAll()
        {
            controller.Post(r1);
            controller.Post(r1);
            controller.Post(r1);
            
            Assert.AreEqual(3, controller.Get().Count());
        }

        [TestMethod]
        public void TestGetId()
        {
            //Record rec1 = new Record("AndersUndervisning1", "Anders1", 69, 2020);
            //Record rec2 = new Record("AndersUndervisning2", "Anders2", 69, 2020);
            //Record rec3 = new Record("AndersUndervisning3", "Anders3", 69, 2020);

            Record rec4 = new Record("AndersUndervisning4", "Anders4", 69, 2020);
            Record rec5 = new Record("AndersUndervisning4", "Anders4", 69, 2020);
            Record rec6 = new Record("AndersUndervisning4", "Anders4", 69, 2020);
            Record rec7 = new Record("AndersUndervisning4", "Anders4", 69, 2020);

            Record rr1 = controller.Post(rec4);
            Record rr2 = controller.Post(rec5);
            Record rr3 = controller.Post(rec6);
            Record rr4 = controller.Post(rec7);

            Assert.AreEqual(1, controller.Get(1).Id);
        }
    }
}
