using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ElektricniElement
    {
        int id;
        string naziv;
        string tip;
        string lokacija;
        double xKoordinata;
        double yKoordinata;
        string naponskiNivo;

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Tip { get => tip; set => tip = value; }
        public string Lokacija { get => lokacija; set => lokacija = value; }
        public double XKoordinata { get => xKoordinata; set => xKoordinata = value; }
        public double YKoordinata { get => yKoordinata; set => yKoordinata = value; }
        public string NaponskiNivo { get => naponskiNivo; set => naponskiNivo = value; }


        public ElektricniElement() { }

        public string GetIDnaziv
        {
            get { return $"{ id }\t\t\t\t { naziv }"; }

        }

    }
}
