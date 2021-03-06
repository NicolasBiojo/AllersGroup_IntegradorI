﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Model;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class ContextTest
    {
        private Context ctx;
        public void SetUp1()
        {
            ctx = new Context();
        }

        [TestMethod]
        public void LoadItemsTest()
        {
            SetUp1();
            Assert.IsNotNull(ctx.Items);

            if (File.Exists(ctx.path + ctx.pathNames[0]))
            {
                Assert.IsTrue(ctx.Items.Count() == 3934);

            }
            else
            {
                Assert.IsTrue(ctx.Items.Count() == 10932);
            }
        }

        [TestMethod]
        public void LoadClientsTest()
        {
            SetUp1();
            Assert.IsNotNull(ctx.Clients);

            if ( File.Exists(ctx.path+ctx.pathNames[1] ))
            {
                Assert.IsTrue(ctx.Clients.Count() == 627);

            }
            else
            {
                Assert.IsTrue(ctx.Clients.Count() == 4334);
            }
        }



        [TestMethod]
        public void LoadTransactionTest()
        {
            SetUp1();
            Assert.IsNotNull(ctx.Transactions);

            if (File.Exists(ctx.path + ctx.pathNames[2]))
            {
                Assert.IsTrue(ctx.Transactions.Count() == 18573);

            }
            else
            {
                Assert.IsTrue(ctx.Transactions.Count() == 21843);
            }
        }



    }        
}
