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
    public partial class deletecomment : System.Web.UI.Page
    {
        CommentBLL CBL = new CommentBLL();
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
                if (Request.QueryString["id"] != null)
                {
                    CBL.DeleteCommentById(Convert.ToInt32(Request.QueryString["id"]));
                    Response.Write("<script>alert('删除成功！')</script>");
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }
        }
    }
}