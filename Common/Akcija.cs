using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Akcija
    {
        string opis;
        DateTime vreme;

        public Akcija() { }

        public Akcija(string opis, DateTime vreme)
        {
            this.opis = opis;
            this.vreme = vreme;
        }

        public string Opis { get => opis; set => opis = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
    }
}