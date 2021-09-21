using BazaPodataka;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public class KvarServis
    {
        Baza db = new Baza();

        public void unesiKvar(string kratakOpis, string uzrok, string detaljanOpis, DateTime vreme, string akcija, string elektricniElement)
        {
            db.DodajKvar(kratakOpis, uzrok, detaljanOpis, vreme, akcija, elektricniElement);
        }

        public void azurirajKvar(string id, string kratakOpis, string uzrok, string detaljanOpis, Status status, DateTime vreme, string akcija, string elektricniElement)
        {
            db.AzurirajKvar(id, kratakOpis, uzrok, detaljanOpis, status, vreme, akcija, elektricniElement);
        }

        public List<ElektricniElement> GetElektricniElementi()
        {
            return db.GetElektricniElementi();
        }


        public List<Kvar> GetKvarovi(DateTime date1, DateTime date2)
        {
            return db.GetKvarovi(date1, date2);
        }
    }
}
