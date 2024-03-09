using Microsoft.Data.SqlClient;
using Eticket.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Eticket.Repository
{
    public class userRegisterRepo
    {
        SqlConnection con;
        SqlCommand cmd;
        public userRegisterRepo()
        {
            con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=ECommerce_Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        public bool create(string Username, string Password, string ConfirmPassword)
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into login values('{Username}', '{Password} ','{ConfirmPassword}')";
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



    }
}
