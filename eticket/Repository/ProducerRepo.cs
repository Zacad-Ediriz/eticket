using Microsoft.Data.SqlClient;
using Eticket.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Eticket.Repository
{
    public class ProducerRepo
    {
        SqlConnection con;
        SqlCommand cmd;

        public ProducerRepo()
        {
            con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=ECommerce_Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        public List<Producer> getAll()
        {
            List<Producer> list = new List<Producer>();
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"select * from Producer order by Fullname asc";
                    cmd = new SqlCommand(_query, con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new Producer() { Id = Convert.ToInt32(dr["id"]), ProfilePictureUrl = dr["ProfilePictureUrl"].ToString(), Fullname = dr["Fullname"].ToString(), Bio = dr["Bio"].ToString() });
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

        public Producer get_by_id(int id)
        {
            Producer data = new Producer();
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"select * from Producer where Id={id}";
                    cmd = new SqlCommand(_query, con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data = new Producer() { Id = Convert.ToInt32(dr["id"]), ProfilePictureUrl = dr["ProfilePictureUrl"].ToString(), Fullname = dr["Fullname"].ToString(), Bio = dr["Bio"].ToString() };
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log the error or throw it further
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return data;
        }

        public bool create(string ProfilePictureUrl, string Fullname, string Bio)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"insert into Producer values('{ProfilePictureUrl}', '{Fullname}', '{Bio}')";
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
                return false; // Return false indicating that the insertion failed
            }
        }

        public bool update(int id, string newlogo, string newname, string newBio)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"update Producer set ProfilePictureUrl='{newlogo}',  Fullname ='{newname}', Bio = '{newBio}' where id={id}";
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
                return false; // Return false indicating that the update operation failed
            }
        }

        public bool delete(int id)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string _query = $"delete from Producer where Id={id}";
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
                return false; // Return false indicating that the delete operation failed
            }
        }

    }
}
