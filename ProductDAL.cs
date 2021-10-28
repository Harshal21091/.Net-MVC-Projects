using InventoryModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL
{
    public class ProductDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString;

        public List<ProductModel> GetProductList()
        {
            SqlConnection con;
            con = new SqlConnection(connStr);
            SqlDataAdapter adapter;
            DataSet ds = new DataSet();
            List<ProductModel> lstProduct = new List<ProductModel>();
            try
            {
                con.Open();

                adapter = new SqlDataAdapter("Get_All_Product_List", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                //fill the dataset
                adapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ProductModel model = new ProductModel();
                    model.PRODUCT_ID = Convert.ToInt32(row["PRODUCT_ID"].ToString());
                    model.PRODUCT_NAME = Convert.ToString(row["PRODUCT_NAME"].ToString());
                    model.ACTUAL_PRICE = Convert.ToInt32(row["ACTUAL_PRICE"].ToString());
                    model.RETAIL_PRICE = Convert.ToInt32(row["RETAIL_PRICE"].ToString());
                    model.CATEGORY = Convert.ToString(row["CATEGORY"].ToString());
                    model.DISCRIPTTION = Convert.ToString(row["DISCRIPTTION"].ToString());

                    lstProduct.Add(model);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProduct;
        }

        public string AddProduct(ProductModel model)
        {
           // string connStr = ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString;
            SqlConnection con;
            con = new SqlConnection(connStr);
            string status = "1";
            try
            {
                if (model.PRODUCT_ID == 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT_UPDATE_PRODUCT_DETAILS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set Output Paramater
                    SqlParameter OutputParam = new SqlParameter("@STATUS", SqlDbType.VarChar);
                    OutputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(OutputParam);

                    cmd.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", SqlDbType.VarChar, 255));
                    cmd.Parameters.Add(new SqlParameter("@ACTUAL_PRICE", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@RETAIL_PRICE", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@CATEGORY", SqlDbType.VarChar, 255));
                    cmd.Parameters.Add(new SqlParameter("@DISCRIPTTION", SqlDbType.VarChar, 255));

                    cmd.Parameters["@PRODUCT_ID"].Value = model.PRODUCT_ID;
                    cmd.Parameters["@PRODUCT_NAME"].Value = model.PRODUCT_NAME;
                    cmd.Parameters["@ACTUAL_PRICE"].Value = model.ACTUAL_PRICE;
                    cmd.Parameters["@RETAIL_PRICE"].Value = model.RETAIL_PRICE;
                    cmd.Parameters["@CATEGORY"].Value = model.CATEGORY;
                    cmd.Parameters["@DISCRIPTTION"].Value = model.DISCRIPTTION;
                    cmd.Parameters["@STATUS"].Value = status;

                    con.Open();

                    cmd.ExecuteNonQuery();
                   
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT_UPDATE_PRODUCT_DETAILS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set Output Paramater
                    SqlParameter OutputParam = new SqlParameter("@STATUS", SqlDbType.VarChar);
                    OutputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(OutputParam);

                    cmd.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", SqlDbType.VarChar, 255));
                    cmd.Parameters.Add(new SqlParameter("@ACTUAL_PRICE", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@RETAIL_PRICE", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@CATEGORY", SqlDbType.VarChar, 255));
                    cmd.Parameters.Add(new SqlParameter("@DISCRIPTTION", SqlDbType.VarChar, 255));

                    cmd.Parameters["@PRODUCT_ID"].Value = model.PRODUCT_ID;
                    cmd.Parameters["@PRODUCT_NAME"].Value = model.PRODUCT_NAME;
                    cmd.Parameters["@ACTUAL_PRICE"].Value = model.ACTUAL_PRICE;
                    cmd.Parameters["@RETAIL_PRICE"].Value = model.RETAIL_PRICE;
                    cmd.Parameters["@CATEGORY"].Value = model.CATEGORY;
                    cmd.Parameters["@DISCRIPTTION"].Value = model.DISCRIPTTION;
                    cmd.Parameters["@STATUS"].Value = status;

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public ProductModel Edit(int id)
        {
            ProductModel model = new ProductModel();
            SqlConnection con;
            con = new SqlConnection(connStr);
            SqlDataAdapter adapter;
            DataSet ds = new DataSet();
            try
            {
                string procedure = "Get_Product_Details";
                con.Open();
                adapter = new SqlDataAdapter(procedure, con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@PRODUCTID", id);
                //fill the dataset
                adapter.Fill(ds);
                
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.PRODUCT_ID = Convert.ToInt32(row["PRODUCT_ID"].ToString());
                    model.PRODUCT_NAME = Convert.ToString(row["PRODUCT_NAME"].ToString());
                    model.ACTUAL_PRICE = Convert.ToInt32(row["ACTUAL_PRICE"].ToString());
                    model.RETAIL_PRICE = Convert.ToInt32(row["RETAIL_PRICE"].ToString());
                    model.CATEGORY = Convert.ToString(row["CATEGORY"].ToString());
                    model.DISCRIPTTION = Convert.ToString(row["DISCRIPTTION"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public string Delete(int id)
        {
            //ProductModel model = new ProductModel();
            SqlConnection con;
            con = new SqlConnection(connStr);
            string status = "1";
            DataSet ds = new DataSet();
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE_PRODUCT", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Set Output Paramater
                SqlParameter OutputParam = new SqlParameter("@STATUS", SqlDbType.Int);
                OutputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(OutputParam);

                cmd.Parameters.Add(new SqlParameter("@PRODUCTID", SqlDbType.NVarChar, 50));
                cmd.Parameters["@PRODUCTID"].Value = id;
                cmd.Parameters["@STATUS"].Value = status;

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

    }
}
