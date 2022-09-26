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
    public partial class videomanage : System.Web.UI.Page
    {
        VideoBLL VBL = new VideoBLL();
        protected List<Video> lv;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Write("<script>alert('请先登录！');window.location.href='/UserModular/login.aspx'</script>");
                return;
            }
            User user = Session["user"] as User;
            if (user.UserID != 1)
            {
                Response.Write("<script>alert('您没有此操作的权限');window.location.href='/default.aspx'</script>");
                return;
            }
            lv = VBL.GetVideoList();


        }

        private void BingData()
        {
            VideoList.DataSource = lv;
            VideoList.DataBind();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            lv = VBL.GetVideoListByTitle(SearchBox.Text);
            VideoList.DataSource = lv;
            VideoList.DataBind();
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            BingData();
        }
    }
}