using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace web.NewsListModular
{
    public partial class newscontent : System.Web.UI.Page
    {
        NewsBLL NBL = new NewsBLL();
        CommentBLL CBL = new CommentBLL();
        //获得的元素
        protected string newsTitle;
        protected string newsAddTime;
        protected string newsAuthor;
        protected string newsContent;
        protected string commentString;
        protected string countcomment;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取http查询字符串
                //根据ID获取新闻
                if (Request.QueryString["id"] != null)
                {
                    News news = new News();
                    news = NBL.GetNewsByID(Convert.ToInt32(Request.QueryString["id"]));
                    newsTitle = news.NewsTitle;
                    newsAddTime = news.NewsAddTime.ToString("yyyy-MM-dd HH:MM:ss");
                    newsAuthor = news.NewsAuthor;
                    newsContent = news.NewsContent;
                    //获取评论Html串
                    commentString = CBL.GetCommentString(Convert.ToInt32(Request.QueryString["id"]));
                    //获取评论数
                    countcomment = CBL.GetCountCommentByNewsID(Convert.ToInt32(Request.QueryString["id"])).ToString();
                }
            }
        }

        protected void commentBtn_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("<script>alert('请先登录！');window.location.href='/UserModular/login.aspx'</script>");
                return;
            }
            if (Request.QueryString["id"] != null)
            {
                User user=Session["user"] as User;
                Comment comment = new Comment();
                comment.UserID = user.UserID;
                comment.NewsID =Convert.ToInt32(Request.QueryString["id"]);
                comment.CommentContent = commentBox.Text;
                comment.AddTime = System.DateTime.Now;
                CBL.InsertComment(comment);
                commentBox.Text = "";
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}