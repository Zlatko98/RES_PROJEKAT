using BazaPodataka;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public class KvarServis : IKvarServis
    {
        IBaza _baza;

        public KvarServis(IBaza baza)
        {
            this._baza = baza;
        }

        public void DodajKvar(string kratakOpis, string uzrok, string detaljanOpis, DateTime vreme, string akcija, string elektricniElement)
        {
            Akcija akcija1 = new Akcija(akcija, vreme);

            string el = elektricniElement.Remove(1, 4);

            string[] parts = el.Split(' ');

            int idElement = Int32.Parse(parts[0]);
            string elElement = parts[1];

            Kvar kvar = new Kvar(kratakOpis, uzrok, detaljanOpis, akcija1, elElement, idElement);

            kvar.Id = CreateID(kvar.Id);

            _baza.DodajKvar(kvar);
        }

        public void AzurirajKvar(string id, string kratakOpis, string uzrok, string detaljanOpis, Status status, DateTime vreme, string akcija, string elektricniElement)
        {
            Kvar kvar = new Kvar();

            string el = elektricniElement.Remove(1, 4);

            string[] parts = el.Split(' ');

            int idElement = Int32.Parse(parts[0]);
            string elElement = parts[1];

            kvar.Id = id;
            kvar.KratakOpis = kratakOpis;
            kvar.Uzrok = uzrok;
            kvar.DetaljanOpis = detaljanOpis;
            kvar.Status = status;
            kvar.Akcija.Vreme = vreme;
            kvar.Akcija.Opis = akcija;
            kvar.ElektricniElement = elektricniElement;
            kvar.IdElement = idElement;

            _baza.AzurirajKvar(kvar);
        }

        public List<ElektricniElement> GetElektricniElementi()
        {
            return _baza.GetElektricniElementi();
        }

        public List<Kvar> GetKvarovi(DateTime date1, DateTime date2)
        {
            return _baza.GetKvarovi(date1, date2);
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

        public string CreateID(string kvarID)
        {
            return _baza.CreateID(kvarID);
        }

    }
}
