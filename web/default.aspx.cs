using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace web
{
    public partial class _default : System.Web.UI.Page
    {
        CarouselBLL CBL = new CarouselBLL();
        NewsBLL NBL = new NewsBLL();
        UserBLL UBL = new UserBLL();
        //轮播图HTML字符串
        protected string CarouselString;
        //后台数据
        protected string usernumber;//用户数量
        protected string newsnumber;//美食数量
        protected string visitednumber;//访问数量
        protected string onlinenumber;
        protected string chartsstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //调用CarouselBLL方法获取轮播图HTML字符串
                CarouselString = CBL.GetCarouselString();
                //调用NewsBLL方法获取实时推送新闻的list
                List<News> chartsNews = NBL.GetNumbedNews(6);
                ChartsList.DataSource = chartsNews;
                ChartsList.DataBind();
                //后台数据
                usernumber = UBL.GetUserNumber().ToString();
                newsnumber = NBL.GetNewsNumber().ToString();
                if (Application["TotalCount"] != null)
                {
                    visitednumber = Application["TotalCount"].ToString();
                }
                if (Application["Online"] != null)
                {
                    onlinenumber = Application["Online"].ToString();
                }
                chartsstring = NBL.GetChartsHtml();
            }
        }

        protected void toSearch_Click(object sender, EventArgs e)
        {
            //重定向到新闻页并附带标题
            Response.Redirect("NewsListModular/newslist.aspx?title=" + SearchBox.Text);
        }
    }
}