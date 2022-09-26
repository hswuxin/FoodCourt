using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CommentBLL
    {
        CommentDAL CDL = new CommentDAL();
        UserBLL UBL = new UserBLL();

        /// <summary>
        /// 插入一条评论
        /// </summary>
        /// <param name="comment">评论实体</param>
        /// <returns>受影响行数</returns>
        public int InsertComment(Comment comment)
        {
            return CDL.InsertComment(comment);
        }

        /// <summary>
        /// 根据新闻ID获得评论Html串
        /// </summary>
        /// <param name="newsid">新闻ID</param>
        /// <returns>评论Html串</returns>
        //         <div class="row">
        //    <div class="col-md-1 col-xs-2">
        //        <img src="../images/user.png" class="img-circle imgBox" width="64px" height="64px" />
        //    </div>
        //    <div class="col-md-11 col-xs-10">
        //        <a href="#" class="uname">无心</a><span class="urole-user">普通用户</span>
        //        <p class="ctext">
        //        你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜你打我啊阿达吊带袜
        //        </p>
        //        <span class="ctime">2022-12-13 12:13</span><span class="deletebox"><a href="#" class="contentdelete">删除</a></span>
        //    </div>
        //</div>
        //<hr />
        public string GetCommentString(int newsid)
        {
            List<Comment> ls = CDL.GetCommentByNewsid(newsid);
            string commentString = "";
            try
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    User user = UBL.GetUserById(ls.ElementAt(i).UserID);
                    commentString += "<div class='row'>";
                    commentString += "<div class='col-md-1 col-xs-2'>";
                    commentString += "<img src='" + user.UserProURL + "' class='img-circle imgBox' width='64px' height='64px'  />";
                    commentString += "</div>";
                    commentString += "<div class='col-md-11 col-xs-10'>";
                    commentString += "<a href='#' class='uname'>" + user.UserName + "</a>" + "<span class='" + ((user.Role == 1) ? "urole-admin'>管理员</span>" : "urole-user'>普通用户</span>");
                    commentString += "<p class='ctext'>";
                    commentString += ls.ElementAt(i).CommentContent;
                    commentString += "</p>";
                    commentString += "<span class='ctime'>" + ls.ElementAt(i).AddTime + "</span>" + "<span class='deletebox'><a href='/admin/commentmanage.aspx?type=delete&id=" + ls.ElementAt(i).CommentID + "' class='contentdelete'>删除</a></span>";
                        commentString += " </div> </div> <hr />";
                }
            }
            catch (NullReferenceException)
            {
                commentString = "暂无评论！<hr>";
            }
            return commentString;
        }

        /// <summary>
        /// 根据评论ID删除评论
        /// </summary>
        /// <param name="commentid">评论ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteCommentById(int commentid)
        {
            return CDL.DeleteCommentById(commentid);
        }

        /// <summary>
        /// 根据新闻ID得到所有的评论
        /// </summary>
        /// <param name="newsid">新闻ID</param>
        /// <returns>评论列表</returns>
        public List<Comment> GetCommentByNewsId(int newsid)
        {
            return CDL.GetCommentByNewsid(newsid);
        }

        /// <summary>
        /// 根据新闻ID删除所有评论
        /// </summary>
        /// <param name="newsid"></param>
        /// <returns></returns>
        public int DeleteCommentByNewsID(int newsid)
        {
            return CDL.DeleteCommentByNewsID(newsid);
        }

        /// <summary>
        /// 根据新闻ID得到所有评论
        /// </summary>
        /// <param name="newsid">新闻ID</param>
        /// <returns>评论数</returns>
        public int GetCountCommentByNewsID(int newsid)
        {
            return CDL.CountCommentByNewsID(newsid);
        }
    }
}
