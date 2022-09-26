using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace web.PictureListModular
{
    public partial class picture : System.Web.UI.Page
    {
        PictureBLL PBL = new PictureBLL();
        protected string picturestring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                picturestring = PBL.GetPictureListHtml();
            }
        }
    }
}