using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace web
{
    public partial class header : System.Web.UI.UserControl
    {
        protected string username;
        protected string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                username = "游客";
            }
            else
            {
                User user = Session["user"] as User;
                username = user.UserName;
                if (user.Role == 1)
                {
                    role = "管理员";
                }
                else
                {
                    role = "普通用户";
                }
            }
        }
    }
}