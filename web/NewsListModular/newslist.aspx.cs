using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace web.ListModular
{
    public partial class newslist : System.Web.UI.Page
    {
        protected string ListString;
        NewsBLL NBL = new NewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //主页搜索重定向
                if (Request.QueryString["title"] != null)
                {
                    if (NBL.HasStringByTitle(Request.QueryString["title"]))
                    {
                        ListString = NBL.GetListStringByTitle(Request.QueryString["title"]);
                    }
                    else
                    {
                        Response.Write("<script>alert('未查找到您要搜索的内容！')</script>");
                    }
                }
                else
                {
                    //调用NewsBLL方法获得新闻的HTML串
                    ListString = NBL.GetListString();
                }
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            //调用模糊查找的方法，如果查不到弹出提示
            if (NBL.HasStringByTitle(SearchBox.Text))
            {
                ListString = NBL.GetListStringByTitle(SearchBox.Text);
            }
            else
            {
                Response.Write("<script>alert('未查找到您要搜索的内容！')</script>");
            }
        }

        protected void All_Click(object sender, EventArgs e)
        {
            //全部
            ListString = NBL.GetListString();
        }

        protected void Stir_Click(object sender, EventArgs e)
        {
            //炒菜
            ListString = NBL.GetListStringByClass(this.Stir.Text);
        }

        protected void Cook_Click(object sender, EventArgs e)
        {
            //煮菜
            ListString = NBL.GetListStringByClass(this.Cook.Text);
        }

        protected void Stew_Click(object sender, EventArgs e)
        {
            //炖菜
            ListString = NBL.GetListStringByClass(this.Stew.Text);
        }



    }
}