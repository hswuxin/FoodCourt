using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CarouselDAL
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        string ConnSql = System.Configuration.ConfigurationManager.ConnectionStrings["FoodCourt"].ConnectionString;

        /// <summary>
        /// 获取轮播列表
        /// </summary>
        /// <returns>轮播列表</returns>
        public List<Carousel> GetCarousel()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [carousel]";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<Carousel> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<Carousel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Carousel cs = new Carousel();
                    cs.CarouselID = Convert.ToInt32(ds.Tables[0].Rows[i]["CarouselID"]);
                    cs.LinkURL = ds.Tables[0].Rows[i]["LinkURL"].ToString();
                    cs.ImgURL = ds.Tables[0].Rows[i]["ImgURL"].ToString();
                    cs.CarouselTitle = ds.Tables[0].Rows[i]["CarouselTitle"].ToString();
                    cs.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"]);
                    LS.Add(cs);
                }
            }
            return LS;
        }
    }
}
