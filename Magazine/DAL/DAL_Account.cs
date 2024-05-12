using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazine.Models;
using System.Data.SqlClient;
using System.Data;
namespace Magazine.DAL
{
    public class DAL_Account
    {
        public static SqlConnection connect()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-F232583;Initial Catalog=pt_magazine;Integrated Security=True";
            return con;
        }

      /*  public List<Sach> getAllSach()
        {
            List<Sach> l = new List<Sach>();

            SqlConnection con = connect();
            con.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_selectAllSach";
            cm.Connection = con;

            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Sach s = new Sach();
                s.id = int.Parse(reader["id"].ToString());
                s.ten = reader["ten"].ToString();
                s.tg = reader["tacgia"].ToString();
                s.nxb = int.Parse(reader["nxb"].ToString());
                l.Add(s);
            }

            con.Close();

            return l;
        }

        public Sach getSachbyId(int id)
        {


            SqlConnection con = connect();
            con.Open();

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_getIdSach";
            cm.Connection = con;
            cm.Parameters.Add(sqlParameter);



            SqlDataReader reader = cm.ExecuteReader();
            Sach s = new Sach();
            while (reader.Read())
            {
                s.id = int.Parse(reader["id"].ToString());
                s.ten = reader["ten"].ToString();
                s.tg = reader["tacgia"].ToString();
                s.nxb = int.Parse(reader["nxb"].ToString());
            }
            con.Close();
            return s;
        }


        public bool updateSach(Sach s)
        {


            SqlConnection con = connect();
            con.Open();

            SqlParameter sqlParameterId = new SqlParameter("@id", s.id);
            SqlParameter sqlParameterTG = new SqlParameter("@tacgia", s.tg);
            SqlParameter sqlParameterTen = new SqlParameter("@ten", s.ten);
            SqlParameter sqlParameterNXB = new SqlParameter("@nxb", s.nxb);

            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_updateSach";
            cm.Connection = con;
            cm.Parameters.Add(sqlParameterId);
            cm.Parameters.Add(sqlParameterTen);
            cm.Parameters.Add(sqlParameterTG);
            cm.Parameters.Add(sqlParameterNXB);

            try
            {
                cm.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }

        }


        public bool delSach(int id)
        {
            List<Sach> l = new List<Sach>();

            SqlConnection con = connect();
            con.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "_getIdSach";
            cm.Connection = con;


            return false;
        } */
    }
}