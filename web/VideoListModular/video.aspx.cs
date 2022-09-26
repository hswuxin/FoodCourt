using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace web.VideoListModular
{
    public partial class video : System.Web.UI.Page
    {
        VideoBLL VBL = new VideoBLL();
        protected string videostring="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                videostring = VBL.GetVideoListHtml();
            }
        }
    }
}