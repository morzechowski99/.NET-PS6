using Microsoft.Extensions.Configuration;
using PS6.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PS6.DAL
{
    public class ProductDB
    {
        private List<Product> products;
        public void Load(IConfiguration configuration)
        {
            string myCompanyDBcs = configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            products = new List<Product>();
            while (reader.Read())
            {

                int id = Int32.Parse(reader["Id"].ToString());
                string name = reader["name"].ToString();
                decimal price = Decimal.Parse(reader["price"].ToString());
                products.Add(new Product { id = id, name = name, price = price });

            }
            reader.Close(); con.Close();
            
        }
        public List<Product> List()
        {
            return products;
        }
        public void Delete(int id, IConfiguration configuration)
        {
            string myCompanyDBcs = configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = $"DELETE FROM PRODUCT WHERE ID = @pid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException exc)
            {

            }
            finally
            {
                con.Close();
            }
        }
        public void Create(Product p, IConfiguration configuration)
        {
            string myCompanyDBcs = configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = $"INSERT INTO PRODUCT (name,price) VALUES (@pname,@pprice)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pname", p.name);
            cmd.Parameters.AddWithValue("@pprice", p.price);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException exc)
            {
                int a = 5;
            }
            finally
            {
                con.Close();
            }
        }
        public Product GetProduct(int id, IConfiguration configuration)
        {
            string myCompanyDBcs = configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "SELECT * FROM Product WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product p;
            reader.Read();
            if (reader.HasRows == true)
            {
                int idd = Int32.Parse(reader["Id"].ToString());
                string name = reader["name"].ToString();
                decimal price = Decimal.Parse(reader["price"].ToString());
                p = new Product { id = id, name = name, price = price };
                reader.Close();
                con.Close();
                return p;
            }
            return null;
        }
        public void Change(Product p, IConfiguration configuration)
        {
            string myCompanyDBcs = configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = $"UPDATE PRODUCT SET NAME = @PNAME, PRICE = @PPRICE WHERE ID = @PID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PNAME", p.name);
            cmd.Parameters.AddWithValue("@PPRICE", p.price);
            cmd.Parameters.AddWithValue("@PID", p.id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException exc)
            {
                int a = 5;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
