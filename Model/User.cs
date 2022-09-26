using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User
    {
        //用户ID
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        //用户名
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        //密码
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        //城市
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        //电话号码
        private string telNumber;

        public string TelNumber
        {
            get { return telNumber; }
            set { telNumber = value; }
        }
        //身份识别码
        private int role;

        public int Role
        {
            get { return role; }
            set { role = value; }
        }
        //评论识别码
        private int canDiscuss;

        public int CanDiscuss
        {
            get { return canDiscuss; }
            set { canDiscuss = value; }
        }

        //头像
        private string userProURL;

        public string UserProURL
        {
            get { return userProURL; }
            set { userProURL = value; }
        }
        
    }
}
