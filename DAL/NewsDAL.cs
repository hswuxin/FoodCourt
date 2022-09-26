using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class NewsDAL
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        string ConnSql = System.Configuration.ConfigurationManager.ConnectionStrings["FoodCourt"].ConnectionString;

        /// <summary>
        /// 得到指定数量的新闻
        /// </summary>
        /// <param name="num">要获得新闻的数量</param>
        /// <returns>新闻列表</returns>
        public List<News> GetNumbedNews(int num)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT TOP " + num + " * FROM [news] ORDER BY NewsAddTime DESC";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<News> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<News>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    News news = new News();
                    news.NewsID = Convert.ToInt32(ds.Tables[0].Rows[i]["NewsID"]);
                    news.NewsTitle = ds.Tables[0].Rows[i]["NewsTitle"].ToString();
                    news.NewsAuthor = ds.Tables[0].Rows[i]["NewsAuthor"].ToString();
                    news.NewsProvince = ds.Tables[0].Rows[i]["NewsProvince"].ToString();
                    news.NewsCuisines = ds.Tables[0].Rows[i]["NewsCuisines"].ToString();
                    news.NewsClass = ds.Tables[0].Rows[i]["NewsClass"].ToString();
                    news.NewsContent = ds.Tables[0].Rows[i]["NewsContent"].ToString();
                    news.NewsAddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["NewsAddTime"]);
                    news.NewsThum = ds.Tables[0].Rows[i]["NewsThum"].ToString();
                    LS.Add(news);
                }
            }
            return LS;
        }

        /// <summary>
        /// 获取所有的新闻
        /// </summary>
        /// <returns>新闻列表</returns>
        public List<News> GetAllNews()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [news] order by NewsAddTime desc";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<News> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<News>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    News news = new News();
                    news.NewsID = Convert.ToInt32(ds.Tables[0].Rows[i]["NewsID"]);
                    news.NewsTitle = ds.Tables[0].Rows[i]["NewsTitle"].ToString();
                    news.NewsAuthor = ds.Tables[0].Rows[i]["NewsAuthor"].ToString();
                    news.NewsProvince = ds.Tables[0].Rows[i]["NewsProvince"].ToString();
                    news.NewsCuisines = ds.Tables[0].Rows[i]["NewsCuisines"].ToString();
                    news.NewsClass = ds.Tables[0].Rows[i]["NewsClass"].ToString();
                    news.NewsContent = ds.Tables[0].Rows[i]["NewsContent"].ToString();
                    news.NewsAddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["NewsAddTime"]);
                    news.NewsThum = ds.Tables[0].Rows[i]["NewsThum"].ToString();
                    LS.Add(news);
                }
            }
            return LS;
        }

        /// <summary>
        /// 根据标题模糊查找
        /// </summary>
        /// <param name="newstitle">标题</param>
        /// <returns>新闻列表</returns>
        public List<News> GetNewsByTitle(string newstitle)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [news] where NewsTitle LIKE'%" + newstitle + "%' ORDER BY NewsAddTime DESC";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<News> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<News>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    News news = new News();
                    news.NewsID = Convert.ToInt32(ds.Tables[0].Rows[i]["NewsID"]);
                    news.NewsTitle = ds.Tables[0].Rows[i]["NewsTitle"].ToString();
                    news.NewsAuthor = ds.Tables[0].Rows[i]["NewsAuthor"].ToString();
                    news.NewsProvince = ds.Tables[0].Rows[i]["NewsProvince"].ToString();
                    news.NewsCuisines = ds.Tables[0].Rows[i]["NewsCuisines"].ToString();
                    news.NewsClass = ds.Tables[0].Rows[i]["NewsClass"].ToString();
                    news.NewsContent = ds.Tables[0].Rows[i]["NewsContent"].ToString();
                    news.NewsAddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["NewsAddTime"]);
                    news.NewsThum = ds.Tables[0].Rows[i]["NewsThum"].ToString();
                    LS.Add(news);
                }
            }
            return LS;
        }

        /// <summary>
        /// 根据分类查新闻
        /// </summary>
        /// <param name="newstitle">标题</param>
        /// <returns>新闻列表</returns>
        public List<News> GetNewsByClass(string newsclass)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [news] WHERE NewsClass ='" + newsclass + "' ORDER BY NewsAddTime DESC";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<News> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<News>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    News news = new News();
                    news.NewsID = Convert.ToInt32(ds.Tables[0].Rows[i]["NewsID"]);
                    news.NewsTitle = ds.Tables[0].Rows[i]["NewsTitle"].ToString();
                    news.NewsAuthor = ds.Tables[0].Rows[i]["NewsAuthor"].ToString();
                    news.NewsProvince = ds.Tables[0].Rows[i]["NewsProvince"].ToString();
                    news.NewsCuisines = ds.Tables[0].Rows[i]["NewsCuisines"].ToString();
                    news.NewsClass = ds.Tables[0].Rows[i]["NewsClass"].ToString();
                    news.NewsContent = ds.Tables[0].Rows[i]["NewsContent"].ToString();
                    news.NewsAddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["NewsAddTime"]);
                    news.NewsThum = ds.Tables[0].Rows[i]["NewsThum"].ToString();
                    LS.Add(news);
                }
            }
            return LS;
        }

        /// <summary>
        /// 根据ID得到新闻
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <returns>新闻</returns>
        public News GetNewsByID(int id)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [news] WHERE NewsID=" + id;
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            News news = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                news = new News();
                news.NewsID = Convert.ToInt32(ds.Tables[0].Rows[0]["NewsID"]);
                news.NewsTitle = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                news.NewsAuthor = ds.Tables[0].Rows[0]["NewsAuthor"].ToString();
                news.NewsProvince = ds.Tables[0].Rows[0]["NewsProvince"].ToString();
                news.NewsCuisines = ds.Tables[0].Rows[0]["NewsCuisines"].ToString();
                news.NewsClass = ds.Tables[0].Rows[0]["NewsClass"].ToString();
                news.NewsContent = ds.Tables[0].Rows[0]["NewsContent"].ToString();
                news.NewsAddTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsAddTime"]);
                news.NewsThum = ds.Tables[0].Rows[0]["NewsThum"].ToString();
            }

            return news;
        }

        /// <summary>
        /// 插入一条新闻
        /// </summary>
        /// <param name="news">新闻</param>
        /// <returns>受影响行数</returns>
        public int InsertNews(News news)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("INSERT INTO [news] VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", news.NewsTitle, news.NewsAuthor, news.NewsProvince, news.NewsCuisines, news.NewsClass, news.NewsContent, news.NewsAddTime, news.NewsThum);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 跟新新闻
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns>受影响行数</returns>
        public int UpdateNews(News news)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("UPDATE [news] SET NewsTitle='{0}',NewsAuthor='{1}',NewsProvince='{2}',NewsCuisines='{3}',NewsClass='{4}',NewsContent='{5}',NewsAddTime='{6}',NewsThum='{7}' WHERE NewsID={8}", news.NewsTitle, news.NewsAuthor, news.NewsProvince, news.NewsCuisines, news.NewsClass, news.NewsContent, news.NewsAddTime, news.NewsThum, news.NewsID);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据ID号删除新闻
        /// </summary>
        /// <param name="newsid">新闻ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteNews(int newsid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = "DELETE FROM [news] WHERE NewsID=" + newsid;
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 获取新闻的数量
        /// </summary>
        /// <returns>新闻数量</returns>
        public int GetNewsNumber()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT count(NewsID) FROM [news] ";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            int result = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return result;
        }

        /// <summary>
        /// 获取charts图表Html串
        /// </summary>
        /// <returns>newlist</returns>
        public List<News> GetChartsHtml()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT NewsCuisines,count(NewsCuisines) as ccount FROM [news] GROUP BY NewsCuisines";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<News> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<News>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    News news = new News();
                    news.NewsCuisines = ds.Tables[0].Rows[i]["NewsCuisines"].ToString();
                    news.NewsClass = ds.Tables[0].Rows[i]["ccount"].ToString();
                    LS.Add(news);
                }
            }
            return LS;
        }
    }
}
