using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class VideoDAL
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        string ConnSql = System.Configuration.ConfigurationManager.ConnectionStrings["FoodCourt"].ConnectionString;

        /// <summary>
        /// 获取视频列表
        /// </summary>
        /// <returns>视频列表</returns>
        public List<Video> GetVideoList()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [video] ORDER BY AddTime DESC";
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<Video> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<Video>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Video video = new Video();
                    video.VideoID = Convert.ToInt32(ds.Tables[0].Rows[i]["VideoID"]);
                    video.VideoTitle = ds.Tables[0].Rows[i]["VideoTitle"].ToString();
                    video.VideoThum = ds.Tables[0].Rows[i]["VideoThum"].ToString();
                    video.VideoURL = ds.Tables[0].Rows[i]["VideoURL"].ToString();
                    video.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"]);
                    LS.Add(video);
                }
            }
            return LS;
        }

        /// <summary>
        /// 根据标题模糊查找视频
        /// </summary>
        /// <param name="videotitle">视频标题</param>
        /// <returns>视频列表</returns>
        public List<Video> GetVideoListByTitle(string videotitle)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = string.Format("SELECT * FROM [video] WHERE VideoTitle LIKE'%{0}%' ORDER BY AddTime DESC", videotitle);
            da.SelectCommand = new SqlCommand(sql, Conn);
            //将数据取出放在中间的DataAdapter中。
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<Video> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<Video>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Video video = new Video();
                    video.VideoID = Convert.ToInt32(ds.Tables[0].Rows[i]["VideoID"]);
                    video.VideoTitle = ds.Tables[0].Rows[i]["VideoTitle"].ToString();
                    video.VideoThum = ds.Tables[0].Rows[i]["VideoThum"].ToString();
                    video.VideoURL = ds.Tables[0].Rows[i]["VideoURL"].ToString();
                    video.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"]);
                    LS.Add(video);
                }
            }
            return LS;
        }

        /// <summary>
        /// 插入一条视频
        /// </summary>
        /// <param name="video">视频实体</param>
        /// <returns>受影响行数</returns>
        public int InsertVideo(Video video)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("INSERT INTO [video] VALUES('{0}','{1}','{2}','{3}')",video.VideoTitle,video.VideoThum,video.VideoURL,video.AddTime);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据ID查找视频
        /// </summary>
        /// <param name="videoid">视频ID</param>
        /// <returns>视频实体</returns>
        public Video GetVideoByID(int videoid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [video] WHERE VideoID=" + videoid;
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            Video video = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                video = new Video();
                video.VideoID = Convert.ToInt32(ds.Tables[0].Rows[0]["VideoID"]);
                video.VideoTitle = ds.Tables[0].Rows[0]["VideoTitle"].ToString();
                video.VideoThum = ds.Tables[0].Rows[0]["VideoThum"].ToString();
                video.VideoURL = ds.Tables[0].Rows[0]["VideoURL"].ToString();
                video.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddTime"]);
            }

            return video;
        }

        /// <summary>
        /// 更新视频
        /// </summary>
        /// <param name="video">视频实体</param>
        /// <returns>受影响行数</returns>
        public int UpdateVideo(Video video)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("UPDATE [video] SET VideoTitle='{0}',VideoThum='{1}',VideoURL='{2}',AddTime='{3}' WHERE VideoID={4}", video.VideoTitle, video.VideoThum, video.VideoURL, video.AddTime,video.VideoID);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据ID删除视频
        /// </summary>
        /// <param name="videoid">视频ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteVideoByID(int videoid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = "DELETE FROM [video] WHERE VideoID=" + videoid;
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }
    }
}
