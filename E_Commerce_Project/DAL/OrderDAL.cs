using E_Commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E_Commerce_Project.DAL
{
    public class OrderDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public OrderDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        private bool CheckOrderData(Order order)
        {
            return true;
        }
        public int PlaceOrder(Order order)
        {
            bool result = CheckOrderData(order);
            if (result == true)
            {
                string qry = "insert into Orders values(@prodid, @price, @quntity)";

                cmd = new SqlCommand(qry, con);     
                cmd.Parameters.AddWithValue("@prodid", order.ProdId);
                //cmd.Parameters.AddWithValue("@userid", order.UserId);
                cmd.Parameters.AddWithValue("@price", order.Price);
                cmd.Parameters.AddWithValue("@quntity", order.Quntity);
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
        public IEnumerable<Order> ViewOrder(string userid)
        {
            List<Order> plist = new List<Order>();
            string qry = "select p.ProdId,p.ProdName,p.ProdPrice,v.CartId," +
                         " o.OrderId,o.Quntity, o.UserId " +
                         " from Product p inner join ViewCart v " +
                         " on p.ProdId = v.ProdId inner join Orders o " +
                         " on v.ProdId = o.ProdId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Order p = new Order();
                    p.ProdId = Convert.ToInt32(dr["ProdId"]);
                    p.ProdName = dr["ProdName"].ToString();
                    p.Price = Convert.ToDecimal(dr["ProdPrice"]);
                    p.CartId = Convert.ToInt32(dr["CartId"]);
                    p.UserId = Convert.ToInt32(dr["UserId"]);
                    p.OrderId = Convert.ToInt32(dr["OrderId"]);
                    p.Quntity = Convert.ToInt32(dr["Quntity"]);
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;
        }
    }
}
