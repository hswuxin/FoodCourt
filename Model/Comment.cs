using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Comment
    {
        //评论ID
        private int commentID;

        public int CommentID
        {
            get { return commentID; }
            set { commentID = value; }
        }
        //评论者ID
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        //评论新闻ID
        private int newsID;

        public int NewsID
        {
            get { return newsID; }
            set { newsID = value; }
        }
        //评论内容
        private string commentContent;

        public string CommentContent
        {
            get { return commentContent; }
            set { commentContent = value; }
        }
        //添加时间
        private DateTime addTime;

        public DateTime AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }
    }
}
