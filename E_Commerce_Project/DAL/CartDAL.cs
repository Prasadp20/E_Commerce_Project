using E_Commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E_Commerce_Project.DAL
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        private bool CheckCartData(Cart cart)
        {
            return true;
        }
        public int AddToCart(Cart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into ViewCart values(@prodid, @userid)";

                cmd = new SqlCommand(qry, con);
                //cmd.Parameters.AddWithValue("@cartid", cart.CartId);
                cmd.Parameters.AddWithValue("@prodid", cart.ProdId);
                cmd.Parameters.AddWithValue("@userid", cart.UserId);

                con.Open();
                int result1 = cmd.ExecuteNonQuery();
                con.Close();
                return result1;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewInCart(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.ProdId, p.ProdName, p.ProdPrice, c.CartId, c.UserId " +
                         " from Product p inner join ViewCart c on c.ProdId = p.ProdId " +
                         " where c.UserId = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProdId = Convert.ToInt32(dr["ProdId"]);
                    p.ProdName = dr["ProdName"].ToString();
                    p.ProdPrice = Convert.ToDecimal(dr["ProdPrice"]);
                    p.CartId = Convert.ToInt32(dr["CartId"]);
                    p.UserId = Convert.ToInt32(dr["UserId"]);
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;
        }

        public int RemoveProduct(int CartId)
        {
            string qry = "delete from Cart where CartId=@cartid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@cartid", CartId);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
