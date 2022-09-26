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
    public partial class picturemanage : System.Web.UI.Page
    {
        PictureBLL PBL = new PictureBLL();
        protected List<Picture> pl;
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
            pl = PBL.GetPictureList();

        }

        private void BingData()
        {
            PicList.DataSource = pl;
            PicList.DataBind();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            pl = PBL.GetPictureListByTitle(SearchBox.Text);
            PicList.DataSource = pl;
            PicList.DataBind();
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            BingData();
        }
    }
}