using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Drawing;

namespace web.UserModular
{
    public partial class login : System.Web.UI.Page
    {
        UserBLL UBL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["type"] == "exit")
            {
                Session.Remove("user");
            }
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    Response.Write("<script>alert('您已经登录');window.location.href='/default.aspx'</script>");
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //获取输入框用户名
            string username = Username.Text;
            //获取输入框密码
            string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");
            if (UBL.Login(username, password) != null)
            {
                User u = UBL.Login(username, password);
                //登录的用户保存到session
                Session["user"] = u;
                Response.Write("<script>alert('登录成功');window.location.href='/default.aspx'</script>");
            }
            else
            {
                warning.Text = "用户名或密码错误!";
                warning.ForeColor = Color.Red;
            }
        }

    }
}