﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ClusterTest
    {

        private Cluster<String> Clus;
        private List<String> Left = null;
        private List<String> Right = null;

        public void SetUp1()
        {
            Left = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Coke" };
            Right = new List<string> {"Diapers"};
        }

        public void SetUp2()
        {
            Left = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Right = new List<string> { "Bread", "Eggs" };
        }

        public void SetUp3()
        {
            Left = new List<string> { "Beer", "Diapers", "Bread", "Eggs", "Coke" };
            Right = new List<string> { "Bread", "Diapers","Coke" };
        }

        public void SetUp4()
        {
            Left = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Right = new List<string> { "Bread", "Milk", "Diapers", "Eggs" };
        }

        public void SetUp5()
        {
            Left = new List<string> { "Beer", "Milk", "Diapers", "Bread", "Eggs" };
            Right = new List<string> { "Beer" , "Milk", "Diapers", "Bread", "Eggs" };
        }


        public void Test_Relation_level(List<String> a, List<String> b,double relation)
        {
            double x = Cluster<String>.Relation_level(a, b);
            Assert.AreEqual(relation, x);
        }

        [TestMethod]
        public void Test_Relation_level_size5x1()
        {
            SetUp1();
            Test_Relation_level(Left,Right,1.0);
        }

        [TestMethod]
        public void Test_Relation_level_size5x2()
        {
            SetUp2();
            Test_Relation_level(Left, Right, 1.0);
        }
        [TestMethod]
        public void Test_Relation_level_size5x3()
        {
            SetUp3();
            Test_Relation_level(Left, Right, 1.0);
        }
        [TestMethod]
        public void Test_Relation_level_size5x4()
        {
            SetUp4();
            Test_Relation_level(Left, Right, 1.0);
        }
        [TestMethod]
        public void Test_Relation_level_Equals()
        {
            SetUp5();
            Test_Relation_level(Left, Right, 1.0);
        }

        [TestMethod]
        public void Test_Relation_level_size1x5()
        {
            SetUp1();
            Test_Relation_level(Right, Left, 0.2);
        }

        [TestMethod]
        public void Test_Relation_level_size2x5()
        {
            SetUp2();
            Test_Relation_level(Right, Left, 0.4);
        }

        [TestMethod]
        public void Test_Relation_level_size3x5()
        {
            SetUp3();
            Test_Relation_level(Right, Left, (double)0.6);
        }

        [TestMethod]
        public void Test_Relation_level_size4x5()
        {
            SetUp4();
            Test_Relation_level(Right, Left, (double)0.8);
        }
    }
}