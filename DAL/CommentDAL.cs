using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CommentDAL
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        string ConnSql = System.Configuration.ConfigurationManager.ConnectionStrings["FoodCourt"].ConnectionString;

        /// <summary>
        /// 插入一条评论
        /// </summary>
        /// <param name="comment">评论实体</param>
        /// <returns>受影响行数</returns>
        public int InsertComment(Comment comment)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = string.Format("INSERT INTO [comment](UserID,NewsID,CommentContent) VALUES({0},{1},'{2}')", comment.UserID, comment.NewsID, comment.CommentContent);
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据新闻ID获得评论列表
        /// </summary>
        /// <param name="newid">新闻ID</param>
        /// <returns>评论列表</returns>
        public List<Comment> GetCommentByNewsid(int newid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT * FROM [comment] WHERE NewsID=" + newid+" order by AddTime desc";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            List<Comment> LS = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                LS = new List<Comment>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Comment comment = new Comment();
                    comment.CommentID = Convert.ToInt32(ds.Tables[0].Rows[i]["CommentID"]);
                    comment.UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                    comment.NewsID = Convert.ToInt32(ds.Tables[0].Rows[i]["NewsID"]);
                    comment.CommentContent = ds.Tables[0].Rows[i]["CommentContent"].ToString();
                    comment.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["AddTime"]);
                    LS.Add(comment);
                }
            }
            return LS;
        }

        /// <summary>
        /// 根据评论ID删除评论
        /// </summary>
        /// <param name="commentid">评论ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteCommentById(int commentid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = "DELETE FROM [comment] WHERE CommentID=" + commentid;
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据新闻ID删除所有评论
        /// </summary>
        /// <param name="newsid">新闻ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteCommentByNewsID(int newsid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = "DELETE FROM [comment] WHERE NewsID=" + newsid;
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据新闻ID得到评论数
        /// </summary>
        /// <param name="newsid">新闻ID</param>
        /// <returns></returns>
        public int CountCommentByNewsID(int newsid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT count(NewsID) count FROM [comment] WHERE NewsID=" + newsid + " GROUP BY NewsID";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            int result=0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                 result= Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return result;
        }
    }
}
