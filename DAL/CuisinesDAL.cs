using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CuisinesDAL
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        string ConnSql = System.Configuration.ConfigurationManager.ConnectionStrings["FoodCourt"].ConnectionString;

        /// <summary>
        /// 得到菜系
        /// </summary>
        /// <returns>菜系列表</returns>
        public List<Cuisines> GetNewsCuisines()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [cuisines]";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<Cuisines> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<Cuisines>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Cuisines cs = new Cuisines();
                    cs.NewsCuisines = ds.Tables[0].Rows[i]["NewsCuisines"].ToString();
                    cs.CuisinesContent = ds.Tables[0].Rows[i]["CuisinesContent"].ToString();
                    LS.Add(cs);
                }
            }
            return LS;
        }

        /// <summary>
        /// 添加菜系
        /// </summary>
        /// <param name="cus">菜系</param>
        /// <returns>受影响行数</returns>
        public int InsertCuisines(Cuisines cus)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = "INSERT INTO [cuisines] VALUES('" + cus.NewsCuisines + "'," + "'')";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 查询是否存在菜系
        /// </summary>
        /// <param name="cuisines">菜系名</param>
        /// <returns></returns>
        public bool HasCuisines(string cuisines)
        {
            bool flag;
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [cuisines] WHERE NewsCuisines='" + cuisines + "'";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}
