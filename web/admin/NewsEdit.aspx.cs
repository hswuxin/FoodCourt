using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.IO;
using System.Drawing;

namespace web.admin
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        CuisinesBLL CBL = new CuisinesBLL();
        NewsBLL NBL = new NewsBLL();
        CommentBLL CoBL = new CommentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                //填充菜系
                List<Cuisines> lcs = new List<Cuisines>();
                lcs = CBL.GetCuisine();
                for (int i = 0; i < lcs.Count; i++)
                {
                    NewsCuisines.Items.Add(lcs[i].NewsCuisines);
                }
                //如果有查询ID值则绑定数据到控件
                if (Request.QueryString["id"] != null)
                {
                    News news = NBL.GetNewsByID(Convert.ToInt32(Request.QueryString["id"]));
                    NewsTitle.Text = news.NewsTitle;
                    NewsAuthor.Text = news.NewsAuthor;
                    NewsProvince.Text = news.NewsProvince;
                    NewsCuisines.SelectedItem.Text = news.NewsCuisines;
                    NewsClass.Text = news.NewsClass;
                    NewsContent.Text = news.NewsContent;
                    NewsAddTime.Text = news.NewsAddTime.ToString();
                    Label1.Text = news.NewsThum;
                }
                //如果有delete和ID的查询则删除
                if (Request.QueryString["type"] == "delete" && Request.QueryString["id"] != null)
                {
                    if (Convert.ToInt32(Request.QueryString["id"]) != null)
                    {
                        //先删除评论表内容
                        CoBL.DeleteCommentByNewsID(Convert.ToInt32(Request.QueryString["id"]));
                        //删除缩略图
                        News temp = NBL.GetNewsByID(Convert.ToInt32(Request.QueryString["id"]));
                        File.Delete(Server.MapPath(temp.NewsThum));
                        if (NBL.DeleteNews(Convert.ToInt32(Request.QueryString["id"])) != 0)
                        {
                            Response.Write("<script>alert('删除成功！');window.location.href='/admin/newsmanage.aspx'</script>");
                        }
                    }
                }
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            if (Label1.Text == "")
            {
                Response.Write("<script>alert('请上传缩略图！！')</script>");
            }
            else if (NewsContent.Text == "")
            {
                Response.Write("<script>alert('请输入内容！')</script>");
            }
            else
            {
                News news = new News();
                news.NewsTitle = NewsTitle.Text;
                news.NewsAuthor = NewsAuthor.Text;
                news.NewsProvince = NewsProvince.Text;
                news.NewsCuisines = NewsCuisines.SelectedItem.Text;
                news.NewsClass = NewsClass.Text;
                news.NewsContent = NewsContent.Text;
                news.NewsAddTime = Convert.ToDateTime(NewsAddTime.Text);
                news.NewsThum = Label1.Text;
                if (NBL.InsertNews(news) != 0)
                {
                    Response.Write("<script>alert('添加成功');window.location.href='/admin/newsmanage.aspx'</script>");
                }
            }
        }

        protected void imgBtn_Click(object sender, EventArgs e)
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
                    FilePath = Path.Combine(Server.MapPath("/uploads/thum/"), FileName);
                    FileUpload1.SaveAs(FilePath);
                    PnlCrop.Visible = true;
                    Imgtocrop.ImageUrl = "/uploads/thum/" + FileName;
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "只允许上传jpg，bmp，gif，jpeg，png的图片格式";
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "没有文件上传";
            }
        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            string croppedFileName = string.Empty;
            string croppedFilePath = string.Empty;
            string fileName = Path.GetFileName(Imgtocrop.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("/uploads/thum/"), fileName);
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgimg = System.Drawing.Image.FromFile(filePath);

                Rectangle areaToCrop = new Rectangle(Convert.ToInt32(XCoordinate.Value), Convert.ToInt32(YCoordinate.Value), Convert.ToInt32(Width.Value), Convert.ToInt32(Height.Value));
                try
                {
                    Bitmap bitmap = new Bitmap(areaToCrop.Width, areaToCrop.Height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.DrawImage(orgimg, new Rectangle(0, 0, bitmap.Width, bitmap.Height), areaToCrop, GraphicsUnit.Pixel);//按指定大小绘制图像；
                    }
                    croppedFileName = "crop_" + fileName;
                    croppedFilePath = Path.Combine(Server.MapPath("/uploads/thum/crop/"), croppedFileName);
                    bitmap.Save(croppedFilePath);//保存裁剪的图片到Images文件夹
                    orgimg.Dispose();//释放图片资源
                    bitmap = null;
                    File.Delete(filePath);
                    PnlCrop.Visible = false;
                    lblMsg.Text = "裁剪成功";
                    lblMsg.ForeColor = Color.Green;
                    Imgcroped.ImageUrl = "/uploads/thum/crop/" + croppedFileName;
                    Label1.Text = Imgcroped.ImageUrl;
                    btnReset.Visible = true;


                }
                catch (Exception ex)
                {
                    lblMsg.Text = "异常信息为 " + ex.Message.ToString();
                }
                finally
                {
                    fileName = string.Empty;
                    filePath = string.Empty;
                    croppedFileName = string.Empty;
                    croppedFilePath = string.Empty;
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Imgcroped.ImageUrl = "";
            lblMsg.Text = string.Empty;
            btnReset.Visible = false;
        }

        protected void addCuisineBtn_Click(object sender, EventArgs e)
        {
            Cuisines cs = new Cuisines();
            cs.NewsCuisines = addCuisine.Text;
            if (CBL.HasCuisines(addCuisine.Text))
            {
                Response.Write("<script>alert('已存在此菜系！')</script>");
            }
            else
            {
                CBL.InsertCuisines(cs);
                Response.Write("<script>alert('添加成功')");
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('修改失败，没有查询到此次修改的新闻！')</script>");
                return;
            }
            News news = new News();
            news.NewsID = Convert.ToInt32(Request.QueryString["id"]);
            news.NewsTitle = NewsTitle.Text;
            news.NewsAuthor = NewsAuthor.Text;
            news.NewsProvince = NewsProvince.Text;
            news.NewsCuisines = NewsCuisines.SelectedItem.Text;
            news.NewsClass = NewsClass.Text;
            news.NewsContent = NewsContent.Text;
            news.NewsAddTime = Convert.ToDateTime(NewsAddTime.Text);
            news.NewsThum = Label1.Text;
            if (NBL.UpdateNews(news) != 0)
            {
                Response.Write("<script>alert('修改成功');window.location.href='/admin/newsmanage.aspx'</script>");
            }
        }
    }
}