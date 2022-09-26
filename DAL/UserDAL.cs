using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        string ConnSql = System.Configuration.ConfigurationManager.ConnectionStrings["FoodCourt"].ConnectionString;

        /// <summary>
        /// 根据用户名取一个用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>用户</returns>
        public User GetUserByUsername(string username)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from [User] where UserName='" + username + "'";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            User user = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                user = new User();
                user.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                user.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                user.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                user.City = ds.Tables[0].Rows[0]["City"].ToString();
                user.TelNumber = ds.Tables[0].Rows[0]["TelNumber"].ToString();
                user.Role = Convert.ToInt32(ds.Tables[0].Rows[0]["Role"]);
                user.CanDiscuss = Convert.ToInt32(ds.Tables[0].Rows[0]["CanDiscuss"]);
                user.UserProURL = ds.Tables[0].Rows[0]["UserProURL"].ToString();
            }
            return user;
        }

        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>受影响行数</returns>
        public int InsertUser(User user)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = "INSERT INTO [User](UserName,Password,City,TelNumber,UserProURL) values(" + "'" + user.UserName + "','" + user.Password + "','" + user.City + "','" + user.TelNumber + "'";
            if (user.UserProURL == "")
            {
                sql += ",'/images/user.png')";
            }
            else
            {
                sql += ",'" + user.UserProURL + "')";
            }
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 查询是否存在用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool HasUser(string username)
        {
            bool flag = false;
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from [User] where UserName='" + username + "'";
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>受影响行数</returns>
        public int UpdateUser(User user)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            string sql = "UPDATE [User] set Password='" + user.Password + "',City='" + user.City + "',TelNumber='" + user.TelNumber;
            if (user.UserProURL == "")
            {
                sql += "' where UserName='" + user.UserName + "'";
            }
            else
            {
                sql += "',UserProURL='" + user.UserProURL + "' where UserName='" + user.UserName + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 根据用户ID得到用户所有信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns>用户实体</returns>
        public User GetUserById(int userid)
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from [User] where UserID=" + userid;
            da.SelectCommand = new SqlCommand(sql, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);   //将数据填充到数据集DataSet中。
            Conn.Close();
            User user = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                user = new User();
                user.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                user.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                user.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                user.City = ds.Tables[0].Rows[0]["City"].ToString();
                user.TelNumber = ds.Tables[0].Rows[0]["TelNumber"].ToString();
                user.Role = Convert.ToInt32(ds.Tables[0].Rows[0]["Role"]);
                user.CanDiscuss = Convert.ToInt32(ds.Tables[0].Rows[0]["CanDiscuss"]);
                user.UserProURL = ds.Tables[0].Rows[0]["UserProURL"].ToString();
            }
            return user;
        }

        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns>用户数量</returns>
        public int GetUserNumber()
        {
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();	//连接数据库	
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT count(UserID) FROM [User] ";
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
    }
}
