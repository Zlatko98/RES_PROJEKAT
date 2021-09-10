using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Status { NEPOTVRDJEN, POTVRDJEN, NA_CEKANJU, U_POPRAVCI, TESTIRANJE, ZATVORENO };

    public class Kvar
    {
        string id;
        DateTime datumKvara;
        Status status;
        DateTime datumZatvaranjaKvara;
        string kratakOpis;
        string uzrok;
        string detaljanOpis;
        Akcija akcija;
        string elektricniElement;
        int idElement;

        public Kvar(string kratakOpis, string uzrok, string detaljanOpis, Akcija akcija, string ElektricniElement, int idElement)
        {
            this.id = DateTime.Now.ToString();
            this.datumKvara = DateTime.Now;
            this.status = Status.NEPOTVRDJEN;
            this.kratakOpis = kratakOpis;
            this.uzrok = uzrok;
            this.detaljanOpis = detaljanOpis;
            this.akcija = akcija;
            this.elektricniElement = ElektricniElement;
            this.idElement = idElement;
        }
        public Kvar(string kratakOpis, string uzrok, string detaljanOpis, string ElektricniElement, int idElement)
        {
            this.id = DateTime.Now.ToString();
            this.datumKvara = DateTime.Now;
            this.status = Status.NEPOTVRDJEN;
            this.kratakOpis = kratakOpis;
            this.uzrok = uzrok;
            this.detaljanOpis = detaljanOpis;
            this.elektricniElement = ElektricniElement;
            this.idElement = idElement;
        }

        public Kvar()
        {
            akcija = new Akcija();
        }


        public string Id { get => id; set => id = value; }
        public DateTime DatumKvara { get => datumKvara; set => datumKvara = value; }
        public Status Status { get => status; set => status = value; }
        public DateTime DatumZatvaranjaKvara { get => datumZatvaranjaKvara; set => datumZatvaranjaKvara = value; }
        public string KratakOpis { get => kratakOpis; set => kratakOpis = value; }
        public string Uzrok { get => uzrok; set => uzrok = value; }
        public string DetaljanOpis { get => detaljanOpis; set => detaljanOpis = value; }
        public Akcija Akcija { get => akcija; set => akcija = value; }
        public string ElektricniElement { get => elektricniElement; set => elektricniElement = value; }
        public int IdElement { get => idElement; set => idElement = value; }


        public string FullInfo
        {
            get { return $"{ datumKvara }\t\t\t{ kratakOpis }\t\t\t{ status }"; }

        }

        public string ToWord()
        {
            string ret = "";

            ret += "ID kvara: " + id + "\n";
            ret += "Naziv elementa: " + elektricniElement + "\n";
            ret += "Elektricni element: " + ElektricniElement + "\n";
            ret += "Vreme kreiranja kvara: " + datumKvara + "\n";
            ret += "Vreme zatvaranja kvara: " + datumZatvaranjaKvara + "\n";
            ret += "Izvrsene akcije: " + akcija.Opis + "\n";

            return ret;

        }
    }
}