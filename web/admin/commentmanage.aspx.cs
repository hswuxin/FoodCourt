using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace web.admin
{
    public partial class commentmanage : System.Web.UI.Page
    {
        CommentBLL CBL = new CommentBLL();
        NewsBLL NBL = new NewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Write("<script>alert('您未登录，请先登录');window.location.href='/UserModular/login.aspx'</script>");
                    return;
                }
                User user = Session["user"] as User;
                if (user.Role == 0)
                {
                    Response.Write("<script>alert('您没有此操作的权限');window.location.href='/default.aspx'</script>");
                    return;
                }
                if (Request.QueryString["type"] == "delete" & Request.QueryString["id"] != null)
                {
                    if (CBL.DeleteCommentById(Convert.ToInt32(Request.QueryString["id"])) != 0)
                    {
                        Response.Write("<script>alert('删除成功！')</script>");
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                }
                if (Request.QueryString["newids"] != null)
                {
                    try
                    {
                        List<Comment> ls = CBL.GetCommentByNewsId(Convert.ToInt32(Request.QueryString["newids"]));
                        CommentList.DataSource = ls;
                        CommentList.DataBind();
                    }
                    catch
                    {
                        Response.Write("<script>alert('暂无评论！')</script>");
                    }
                }
            }
        }
    }
}