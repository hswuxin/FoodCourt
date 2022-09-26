using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        UserDAL UDL = new UserDAL();

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">传入用户名</param>
        /// <param name="password">传入密码</param>
        /// <returns>用户或null</returns>
        public User Login(string username, string password)
        {
            User user = UDL.GetUserByUsername(username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public User GetUserByUserName(string username)
        {
            return UDL.GetUserByUsername(username);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>受影响行数</returns>
        public int InsertUser(User user)
        {
            return UDL.InsertUser(user);
        }

        /// <summary>
        /// 查询是否存在用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool HasUser(string username)
        {
            return UDL.HasUser(username);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>受影响行数</returns>
        public int UpdateUser(User user)
        {
            return UDL.UpdateUser(user);
        }

        /// <summary>
        /// 根据用户ID取得用户信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns>用户实体</returns>
        public User GetUserById(int userid)
        {
            return UDL.GetUserById(userid);
        }

        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns>用户数量</returns>
        public int GetUserNumber()
        {
            return UDL.GetUserNumber();
        }
    }
}
