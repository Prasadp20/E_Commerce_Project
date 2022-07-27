using E_Commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E_Commerce_Project.DAL
{
    public class UsersDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UsersDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public int UserSignUp(Users users)
        {
            string qry = "insert into Users values(@username, @email, @password, @roleid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", users.UserName);
            cmd.Parameters.AddWithValue("@email", users.Email);
            cmd.Parameters.AddWithValue("@password", users.Password);
            cmd.Parameters.AddWithValue("@roleid", 2);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public Users UserLogin(Users users)
        {
            Users user = new Users();
            string qry = "select * from Users where Email = @email";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", users.Email);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    user.UserId = Convert.ToInt32(dr["UserId"]);
                    user.UserName = dr["UserName"].ToString();
                    user.Email = dr["Email"].ToString();
                    user.Password = dr["Password"].ToString();
                    user.RoleId = Convert.ToInt32(dr["RoleId"]);
                }
            }
            con.Close();
            return user;
        }     
    }
}
