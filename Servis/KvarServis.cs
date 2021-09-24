using BazaPodataka;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public class KvarServis : IKvar
    {
        IBaza _baza;

        public KvarServis(IBaza baza)
        {
            _baza = baza;
        }

        public void azurirajKvar(string id, string kratakOpis, string uzrok, string detaljanOpis, Status status, DateTime vreme, string akcija, string elektricniElement)
        {
            _baza.AzurirajKvar(id, kratakOpis, uzrok, detaljanOpis, status, vreme, akcija, elektricniElement);
        }

        public List<ElektricniElement> GetElektricniElementi()
        {
            return _baza.GetElektricniElementi();
        }


        public List<Kvar> GetKvarovi(DateTime date1, DateTime date2)
        {
            return _baza.GetKvarovi(date1, date2);
        }

        public void unesiKvar(string kratakOpis, string uzrok, string detaljanOpis, DateTime vreme, string akcija, string elektricniElement)
        {
            _baza.DodajKvar(kratakOpis, uzrok, detaljanOpis, vreme, akcija, elektricniElement);
        }

        public List<string> GetStatus()
        {
            List<string> list = new List<string>();

            foreach (Status s in Enum.GetValues(typeof(Status)))
            {
                list.Add(s.ToString());
            }
            return list;
        }

        public void CreateID(string kvarID)
        {
            _baza.CreateID(kvarID);
        }
    }
}
