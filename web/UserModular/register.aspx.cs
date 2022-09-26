using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Drawing;
using System.IO;

namespace web.UserModular
{
    public partial class register : System.Web.UI.Page
    {
        UserBLL UBL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //获取输入框用户名
            string username = Username.Text;
            //获取输入框密码
            string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");
            //获取城市
            string city = City.Text;
            //获取号码
            string telnumber = TelNumber.Text;
            if (UBL.HasUser(username))
            {
                warning.ForeColor = Color.Red;
                warning.Text = "用户名已存在！";      
            }
            else
            {
                User user = new User();
                user.UserName = username;
                user.Password = password;
                user.City = city;
                user.TelNumber = telnumber;
                user.UserProURL = Label1.Text;
                UBL.InsertUser(user);
                Response.Write("<script>alert('注册成功');window.location.href='/UserModular/login.aspx'</script>");
            }
        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            string FileName = string.Empty;
            string FilePath = string.Empty;
            string Extention = string.Empty;
            if (FileUpload1.HasFile)
            {
                Extention = Path.GetExtension(FileUpload1.FileName).ToLower();
                if (Extention == ".jpg" || Extention == ".bmp" || Extention == ".gif" || Extention == ".jpeg" || Extention == ".png")
                {
                    FileName = Guid.NewGuid().ToString() + Extention;
                    FilePath = Path.Combine(Server.MapPath("/uploads/proflie/"), FileName);
                    FileUpload1.SaveAs(FilePath);
                    Label1.Text = "/uploads/proflie/" + FileName;
                }
                else
                {
                    warning.ForeColor = Color.Red;
                    warning.Text = "只允许上传jpg，bmp，gif，jpeg，png的图片格式";
                }
            }
            else
            {
                warning.ForeColor = Color.Red;
                warning.Text = "没有文件上传";
            }
        }

        
    }
}