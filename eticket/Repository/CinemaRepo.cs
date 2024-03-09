using Microsoft.Data.SqlClient;
using Eticket.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Eticket.Repository
{
    public class CinemaRepo
    {
        SqlConnection con;
        SqlCommand cmd;

        public CinemaRepo()
        {
            con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=ECommerce_Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        public List<Cinema> getAll()
        {
            List<Cinema> list = new List<Cinema>();
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = "select * from Cinema order by Name asc";
                    cmd = new SqlCommand(_query, con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new Cinema() { Id = Convert.ToInt32(dr["id"]), logo = dr["logo"].ToString(), Name = dr["Name"].ToString(), Description = dr["Description"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log the error or throw it further
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return list;
        }

      public Cinema get_by_id(int id)
        {
            Cinema data = new Cinema();
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"select * from Cinema where Id={id}";
                    cmd = new SqlCommand(_query, con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data = new Cinema() { Id = Convert.ToInt32(dr["id"]), logo = dr["logo"].ToString(), Name = dr["Name"].ToString(), Description = dr["Description"].ToString() };
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return data;
        }

        public bool create(string logo, string Name, string Description)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"insert into Cinema values('{logo}', '{Name}', '{Description}')";
                    cmd = new SqlCommand(_query, con);

                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("An error occurred: " + ex.Message);
                return false; // Return false in case of an exception
            }
        }

        public bool update(int id, string newname,string newlogo, string newDescription)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"update Cinema set Name='{newname}',  logo ='{newlogo}', Description = '{newDescription}' where id={id}";
                    cmd = new SqlCommand(_query, con);

                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log the error or throw it further
                Console.WriteLine("An error occurred: " + ex.Message);
                return false; // Return false in case of an exception
            }
        }

        public bool delete(int id)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"delete from Cinema where Id={id}";
                    cmd = new SqlCommand(_query, con);

                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log the error or throw it further
                Console.WriteLine("An error occurred: " + ex.Message);
                return false; // Return false in case of an exception
            }
        }

    }
}
