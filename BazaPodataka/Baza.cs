using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class Baza
    {
        public static string con_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PTB\\source\\repos\\RES_PROJEKAT\\BazaPodataka\\Baza.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(con_string);

        public SqlConnection Con { get => con; set => con = value; }


        public void Konektovanje()
        {
            try
            {
                Con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Diskonektovanje()
        {
            try
            {
                Con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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

            Konektovanje();
            if (Con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into [Kvarovi](Id,datumKvara,status,kratakOpis,uzrok,detaljanOpis,opisAkcije,vremeAkcije,elektricniElement,idElement) " +
                    "values('" + kvar.Id + "','" + kvar.DatumKvara + "','" + kvar.Status.ToString() + "','" + kvar.KratakOpis + "','" + kvar.Uzrok + "','" + kvar.DetaljanOpis + "','" + kvar.Akcija.Opis + "','" + kvar.Akcija.Vreme + "','" + kvar.ElektricniElement + "','" + kvar.IdElement + "')";
                SqlCommand com = new SqlCommand(q, Con);
                com.ExecuteNonQuery();
            }
            else
            {

            }
            Diskonektovanje();
        }

        public string CreateID(string kvarID)
        {
            string retID = "";
            int broj = 0;

            string ID = GetLatestID();

            if (ID == string.Empty)
            {
                retID = kvarID + "_" + broj.ToString();
                return retID;
            }

            string tmp1 = ID.Substring(0, 9);
            string tmp2 = kvarID.Substring(0, 9);

            string[] parts1 = tmp1.Split('-');
            string[] parts2 = tmp2.Split('-');

            if (parts2[2] == parts1[2] && parts2[1] == parts1[1] && parts2[0] == parts1[0])
            {
                broj = Int32.Parse(ID.Substring(ID.Length - 1)) + 1;
            }

            retID = kvarID + "_" + broj.ToString();

            return retID;
        }

        public string GetLatestID()
        {
            Konektovanje();
            string id = "";
            string query = "select top 1 Id from [Kvarovi] order by Id desc";
            SqlCommand com = new SqlCommand(query, Con);

            if (Con.State != System.Data.ConnectionState.Open)
            {
                Con.Open();
            }

            SqlDataReader reader = com.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader["Id"].ToString();
                }
            }

            reader.Close();
            Diskonektovanje();
            return id;

        }
    }
}
