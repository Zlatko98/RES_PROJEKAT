using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    [TestFixture]
    public class KvarTest
    {
        Akcija akcija = new Akcija();

        [Test]
        [TestCase("kratak opis", "uzrok", "detaljan opis", "elektricni element", 1)]
        public void KvarKonstruktor(string kratakOpis, string uzrok, string detaljanOpis, string ElektricniElement, int idElement)
        {
            Kvar kvar = new Kvar(kratakOpis, uzrok, detaljanOpis, akcija, ElektricniElement, idElement);

            Assert.AreEqual(kvar.Status, Status.NEPOTVRDJEN);
            Assert.AreEqual(kvar.Id, DateTime.Now.ToString());
        }

    }

}
