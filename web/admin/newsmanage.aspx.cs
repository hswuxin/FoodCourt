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
    public partial class newsmanage : System.Web.UI.Page
    {
        NewsBLL NBL = new NewsBLL();
        protected List<News> news;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("<script>alert('请先登录！');window.location.href='/UserModular/login.aspx'</script>");
            }
            else
            {
                
                    User user = Session["user"] as User;
                    if (user.UserID != 1)
                    {
                        Response.Write("<script>alert('您没有此操作的权限');window.location.href='/default.aspx'</script>");
                    }
                    else
                    {
                        news = NBL.GetAllNews();
                    }
                
            }
        }

        private void BindData()
        {
            NewsList.DataSource = news;
            NewsList.DataBind();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            
            news = NBL.GetNewsByTitleList(SearchBox.Text);
            NewsList.DataSource = news;
            NewsList.DataBind();
        }

        protected void NewsList_PagePropertiesChanged(object sender, EventArgs e)
        {

        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
    }
}