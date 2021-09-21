using BazaPodataka;
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
    }
}
