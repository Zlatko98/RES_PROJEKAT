using Autofac.Extras.Moq;
using Common;
using Moq;
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
    public class KvarServisTest
    {
        private static readonly object[] testCaseInput =
        {
            new object[] { "kratak opis1", "uzrok1", "detaljan opis1", new DateTime(2021, 1, 1, 00, 00, 10), "akcija1", "0\t\t\t\t transformator" }
        };
        private static readonly object[] testCaseInput2 =
        {
            new object[] { "24-Aug-21 14:14:250", "kratak opis1", "uzrok1", "detaljan opis1", Status.ZATVORENO, new DateTime(2021, 1, 1, 00, 00, 10), "akcija1", "0\t\t\t\t transformator" }
        };
        private static readonly object[] testCaseDate =
        {
            new object[] { new DateTime(2010, 1, 1, 00, 00, 10), new DateTime(2022, 1, 1, 00, 00, 10) }
        };



        [Test]
        [TestCaseSource("testCaseInput")]
        public void DodajKvarTest(string kratakOpis, string uzrok, string detaljanOpis, DateTime vreme, string akcija, string elektricniElement)
        {

            using (var mock = AutoMock.GetLoose())
            {
                Kvar kvar = new Kvar();

                mock.Mock<IBaza>()
                    .Setup(x => x.CreateID(DateTime.Now.ToString()));

                mock.Mock<IBaza>()
                    .Setup(x => x.DodajKvar(kvar));

                var cls = mock.Create<KvarServis>();

                cls.DodajKvar(kratakOpis, uzrok, detaljanOpis, vreme, akcija, elektricniElement);

                mock.Mock<IBaza>()
                    .Verify(x => x.CreateID(DateTime.Now.ToString()), Times.Exactly(1));

                mock.Mock<IBaza>()
                    .Verify(x => x.DodajKvar(It.IsAny<Kvar>()), Times.Exactly(1));

            }

        }

        [Test]
        [TestCaseSource("testCaseInput2")]
        public void AzurirajKvarTest(string id, string kratakOpis, string uzrok, string detaljanOpis, Status status, DateTime vreme, string akcija, string elektricniElement)
        {

            using (var mock = AutoMock.GetLoose())
            {
                Kvar kvar = new Kvar();

                mock.Mock<IBaza>()
                    .Setup(x => x.AzurirajKvar(kvar));

                var cls = mock.Create<KvarServis>();

                cls.AzurirajKvar(id, kratakOpis, uzrok, detaljanOpis, status, vreme, akcija, elektricniElement);

                mock.Mock<IBaza>()
                    .Verify(x => x.AzurirajKvar(It.IsAny<Kvar>()), Times.Exactly(1));

            }
        }

        [Test]
        [TestCaseSource("testCaseDate")]
        public void GetKvaroviTest(DateTime date1, DateTime date2)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBaza>()
                    .Setup(x => x.GetKvarovi(date1, date2))
                    .Returns(GetSampleKvarovi());

                var cls = mock.Create<KvarServis>();
                var expected = GetSampleKvarovi();

                var actual = cls.GetKvarovi(date1, date2);

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].DatumKvara, actual[i].DatumKvara);
                }
            }
        }

        [Test]
        public void GetStatusTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var cls = mock.Create<KvarServis>();

                List<string> statusi = new List<string>();

                statusi = cls.GetStatus();

                foreach (string s in statusi)
                {
                    Assert.AreEqual(true, Enum.IsDefined(typeof(Status), s));
                }

            }
        }

        [Test]
        [TestCase("24-Aug-21 13:59:11")]
        public void CreateIDTest(string id)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Kvar kvar = new Kvar();

                mock.Mock<IBaza>()
                    .Setup(x => x.CreateID(id));

                var cls = mock.Create<KvarServis>();

                cls.CreateID(id);

                mock.Mock<IBaza>()
                    .Verify(x => x.CreateID(id), Times.Exactly(1));
            }
        }
        [Test]
        public void GetElektricniElementi()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBaza>()
                    .Setup(x => x.GetElektricniElementi());

                var cls = mock.Create<KvarServis>();

                cls.GetElektricniElementi();

                mock.Mock<IBaza>()
                    .Verify(x => x.GetElektricniElementi(), Times.Exactly(1));

            }
        }


        #region list
        private static List<Kvar> GetSampleKvarovi()
        {
            List<Kvar> output = new List<Kvar>
            {
                new Kvar
                {
                    DatumKvara = new DateTime(24, 8, 21, 13, 59, 11)
                },
                new Kvar
                {
                    DatumKvara = new DateTime(24, 8, 21, 13, 59, 11)
                },
                new Kvar
                {
                    DatumKvara = new DateTime(24, 8, 21, 13, 59, 11)
                },

            };

            return output;
        }
        #endregion
    }
}
