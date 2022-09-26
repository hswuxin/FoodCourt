using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class PictureDAL
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        string ConnSql = System.Configuration.ConfigurationManager.ConnectionStrings["FoodCourt"].ConnectionString;

        /// <summary>
        /// 获取所有的图片
        /// </summary>
        /// <returns>图片列表</returns>
        public List<Picture> GetPictureList()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [picture] ORDER BY AddTime DESC";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<Picture> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<Picture>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Picture pic = new Picture();
                    pic.PicID = Convert.ToInt32(ds.Tables[0].Rows[i]["PicID"]);
                    pic.PicTitle = ds.Tables[0].Rows[i]["PicTitle"].ToString();
                    pic.PicContent = ds.Tables[0].Rows[i]["PicContent"].ToString();
                    pic.PicThumURL = ds.Tables[0].Rows[i]["PicThumURL"].ToString();
                    pic.PicURL = ds.Tables[0].Rows[i]["PicURL"].ToString();
                    pic.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"]);
                    LS.Add(pic);
                }
            }
            return LS;
        }

        /// <summary>
        /// 根据标题模糊查找图片
        /// </summary>
        /// <param name="pictitle"></param>
        /// <returns>图片列表</returns>
        public List<Picture> GetPictureListByTitle(string pictitle)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [picture] WHERE PicTitle LIKE'%"+pictitle+"%'";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<Picture> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<Picture>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Picture pic = new Picture();
                    pic.PicID = Convert.ToInt32(ds.Tables[0].Rows[i]["PicID"]);
                    pic.PicTitle = ds.Tables[0].Rows[i]["PicTitle"].ToString();
                    pic.PicContent = ds.Tables[0].Rows[i]["PicContent"].ToString();
                    pic.PicThumURL = ds.Tables[0].Rows[i]["PicThumURL"].ToString();
                    pic.PicURL = ds.Tables[0].Rows[i]["PicURL"].ToString();
                    pic.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"]);
                    LS.Add(pic);
                }
            }
            return LS;
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="picture">图片实体</param>
        /// <returns>受影响行数</returns>
        public int InsertPicture(Picture picture)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("INSERT INTO [picture] VALUES('{0}','{1}','{2}','{3}','{4}')",picture.PicTitle,picture.PicContent,picture.PicThumURL,picture.PicURL,picture.AddTime);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="picture">图片实体</param>
        /// <returns>受影响行数</returns>
        public int UpdatePicture(Picture picture)   
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("UPDATE picture SET PicTitle='{0}',PicContent='{1}',PicThumURL='{2}',PicURL='{3}',AddTime='{4}' WHERE PicID={5}", picture.PicTitle, picture.PicContent, picture.PicThumURL, picture.PicURL, picture.AddTime,picture.PicID);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据ID查找图片
        /// </summary>
        /// <param name="picid">ID</param>
        /// <returns>图片实体</returns>
        public Picture GetPictureById(int picid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [picture] WHERE PicID=" + picid;
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            Picture pic = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                pic = new Picture();
                pic.PicID = Convert.ToInt32(ds.Tables[0].Rows[0]["PicID"]);
                pic.PicTitle = ds.Tables[0].Rows[0]["PicTitle"].ToString();
                pic.PicContent = ds.Tables[0].Rows[0]["PicContent"].ToString();
                pic.PicThumURL = ds.Tables[0].Rows[0]["PicThumURL"].ToString();
                pic.PicURL = ds.Tables[0].Rows[0]["PicURL"].ToString();
                pic.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddTime"]);
            }

            return pic;
        }


        /// <summary>
        /// 根据ID删除图片
        /// </summary>
        /// <param name="picid">图片ID</param>
        /// <returns>受影响行数</returns>
        public int DeletePicture(int picid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("DELETE FROM [picture] WHERE PicID={0}",picid);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }
    }
}
