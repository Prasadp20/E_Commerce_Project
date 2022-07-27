using E_Commerce_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E_Commerce_Project.DAL
{
    public class UsersProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UsersProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Product> ProductsList()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
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
                    p.ProdCompanyName = dr["ProdCompanyName"].ToString();
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;
        }
        //public Product AddProductInCart(int ProdId)
        //{
        //    Product p = new Product();
        //    string qry = "select * from Product where ProdId=@prodid";
        //    cmd = new SqlCommand(qry, con);
        //    cmd.Parameters.AddWithValue("@prodid", ProdId);
        //    con.Open();
        //    dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            p.ProdId = Convert.ToInt32(dr["ProdId"]);
        //            p.ProdName = dr["ProdName"].ToString();
        //            p.ProdPrice = Convert.ToDecimal(dr["ProdPrice"]);
        //            p.ProdCompanyName = dr["ProdCompanyName"].ToString();
        //        }
        //    }
        //    con.Close();
        //    return p;
        //}
        //public int RemoveProduct(int ProdId)
        //{
        //    string qry = "delete from Product where ProdId=@prodid";
        //    cmd = new SqlCommand(qry, con);
        //    cmd.Parameters.AddWithValue("@prodid", ProdId);
        //    con.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return result;
        //}
    }
}
