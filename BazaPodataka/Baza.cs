using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class Baza : IBaza
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

        public void DodajKvar(IKvar kvar)
        {
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

        public void AzurirajKvar(IKvar kvar)
        {
            Konektovanje();

            if (kvar.Status == Status.ZATVORENO)
            {
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    string q = "update [Kvarovi]  set status ='" + kvar.Status + "', kratakOpis='" + kvar.KratakOpis + "', detaljanOpis='" + kvar.DetaljanOpis + "', opisAkcije = '" + kvar.Akcija + "', datumZatvaranjaKvara = '" + DateTime.Now + "' where Id ='" + kvar.Id + "'";
                    SqlCommand com = new SqlCommand(q, Con);
                    com.ExecuteNonQuery();
                }
            }
            else
            {
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    string q = "update [Kvarovi]  set status ='" + kvar.Status + "', kratakOpis='" + kvar.KratakOpis + "', detaljanOpis='" + kvar.DetaljanOpis + "', opisAkcije = '" + kvar.Akcija + "' where Id ='" + kvar.Id + "'";
                    SqlCommand com = new SqlCommand(q, Con);
                    com.ExecuteNonQuery();
                }
            }

            Diskonektovanje();
        }

        public List<Kvar> GetKvarovi(DateTime date1, DateTime date2)
        {
            Konektovanje();
            List<Kvar> kvarovi = new List<Kvar>();
            string query = "select * from [Kvarovi] where datumKvara between '" + date1 + "' and '" + date2 + "'";
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
                    Kvar k = new Kvar();

                    k.DatumKvara = DateTime.Parse(reader["datumKvara"].ToString());

                    k.Id = reader["Id"].ToString();

                    k.Status = (Status)Enum.Parse(typeof(Status), reader["status"].ToString());
                    k.DetaljanOpis = reader["detaljanOpis"].ToString();
                    k.KratakOpis = reader["kratakOpis"].ToString();
                    k.Uzrok = reader["uzrok"].ToString();
                    k.Akcija.Vreme = DateTime.Parse(reader["vremeAkcije"].ToString());
                    k.Akcija.Opis = reader["opisAkcije"].ToString();

                    kvarovi.Add(k);
                }
            }
            else
            {
                kvarovi = null;
            }

            reader.Close();
            Diskonektovanje();
            return kvarovi;
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
            string query = "select top 1 Id from [Kvarovi] order by datumKvara desc";
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

        public List<ElektricniElement> GetElektricniElementi()
        {
            Konektovanje();
            List<ElektricniElement> elektricniElementi = new List<ElektricniElement>();
            string query = "select * from [ElektricniElementi]";
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
                    ElektricniElement e = new ElektricniElement();

                    e.Id = (int)reader["idElement"];
                    e.Naziv = reader["naziv"].ToString();
                    e.Lokacija = reader["lokacija"].ToString();
                    e.Tip = reader["tip"].ToString();
                    e.XKoordinata = float.Parse(reader["xKoordinata"].ToString());
                    e.YKoordinata = float.Parse(reader["yKoordinata"].ToString());
                    e.NaponskiNivo = reader["naponskiNivo"].ToString();

                    elektricniElementi.Add(e);
                }
            }
            else
            {
                elektricniElementi = null;
            }

            reader.Close();
            Diskonektovanje();
            return elektricniElementi;
        }
    }
}
