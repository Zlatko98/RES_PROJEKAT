using Common;
using NUnit.Framework;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTest
{
    [TestFixture]
    public class FactoryTest
    {
        [Test]
        public void CreateBazaTest()
        {
            var baza = Factory.CreateBaza();

            Assert.AreEqual(true, baza is IBaza);
        }
        [Test]
        public void CreateKvarServis()
        {
            var kvarServis = Factory.CreateKvarServis();

            Assert.AreEqual(true, kvarServis is IKvarServis);
        }
        [Test]
        public void CreateExportServis()
        {
            var exportServis = Factory.CreateExportServis();

            Assert.AreEqual(true, exportServis is IExport);
        }

    }
}