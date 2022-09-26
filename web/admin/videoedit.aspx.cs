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
    public partial class videoedit : System.Web.UI.Page
    {
        VideoBLL VBL = new VideoBLL();
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
                if (Request.QueryString["id"] != null)
                {
                    Video video = VBL.GetVideoByID(Convert.ToInt32(Request.QueryString["id"]));
                    videotitle.Text = video.VideoTitle;
                    videoaddtime.Text = video.AddTime.ToString();
                    Label1.Text = video.VideoThum;
                    Label2.Text = video.VideoURL;
                }
                if (Request.QueryString["type"] == "delete" && Request.QueryString["id"] != null)
                {
                    Video video = VBL.GetVideoByID(Convert.ToInt32(Request.QueryString["id"]));
                    File.Delete(Server.MapPath(video.VideoThum));
                    File.Delete(Server.MapPath(video.VideoURL));
                    if (VBL.DeleteVideoByID(Convert.ToInt32(Request.QueryString["id"])) != 0)
                    {
                        Response.Write("<script>alert('删除成功！');window.location.href='/admin/videomanage.aspx'</script>");
                    }
                }
            }
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (Label1.Text == "")
            {
                Response.Write("<script>alert('请先上传封面！')</script>");
                return;
            }
            if (Label2.Text == "")
            {
                Response.Write("<script>alert('请先上传视频！')</script>");
                return;
            }
            Video video = new Video();
            video.VideoTitle = videotitle.Text;
            video.VideoThum = Label1.Text;
            video.VideoURL = Label2.Text;
            video.AddTime = Convert.ToDateTime(videoaddtime.Text);
            if (VBL.InsertVideo(video) != 0)
            {
                Response.Write("<script>alert('添加成功！');window.location.href='/admin/videomanage.aspx'</script>");
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
                    FilePath = Path.Combine(Server.MapPath("/VideoListModular/imgsrc/"), FileName);
                    FileUpload1.SaveAs(FilePath);
                    PnlCrop.Visible = true;
                    Imgtocrop.ImageUrl = "/VideoListModular/imgsrc/" + FileName;
                }
                else
                {
                    Response.Write("<script>alert('只允许上传jpg，bmp，gif，jpeg，png的图片格式！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('没有文件上传')</script>");
            }
        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            string croppedFileName = string.Empty;
            string croppedFilePath = string.Empty;
            string fileName = Path.GetFileName(Imgtocrop.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("/VideoListModular/imgsrc/"), fileName);
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
                    croppedFilePath = Path.Combine(Server.MapPath("/VideoListModular/imgsrc/thum/"), croppedFileName);
                    bitmap.Save(croppedFilePath);//保存裁剪的图片到Images文件夹
                    orgimg.Dispose();//释放图片资源
                    bitmap = null;
                    File.Delete(filePath);
                    PnlCrop.Visible = false;
                    lblMsg.Text = "裁剪成功";
                    lblMsg.ForeColor = Color.Green;
                    Imgcroped.ImageUrl = "/VideoListModular/imgsrc/thum/" + croppedFileName;
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

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('没有查找到视频！')</script>");
                return;
            }
            if (Label1.Text == "")
            {
                Response.Write("<script>alert('请先上传封面！')</script>");
                return;
            }
            if (Label2.Text == "")
            {
                Response.Write("<script>alert('请先上传视频！')</script>");
                return;
            }
            Video video = new Video();
            video.VideoID = Convert.ToInt32(Request.QueryString["id"]);
            video.VideoTitle = videotitle.Text;
            video.VideoThum = Label1.Text;
            video.VideoURL = Label2.Text;
            video.AddTime = Convert.ToDateTime(videoaddtime.Text);
            if (VBL.UpdateVideo(video) != 0)
            {
                Response.Write("<script>alert('更新成功！');window.location.href='/admin/videomanage.aspx'</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string FileName = string.Empty;
            string FilePath = string.Empty;
            string Extention = string.Empty;
            if (FileUpload2.HasFile)
            {
                Extention = Path.GetExtension(FileUpload2.FileName).ToLower();
                if (Extention == ".mp4")
                {
                    FileName = Guid.NewGuid().ToString() + Extention;
                    FilePath = Path.Combine(Server.MapPath("/VideoListModular/videosrc/"), FileName);
                    FileUpload2.SaveAs(FilePath);
                    Label2.Text = "/VideoListModular/videosrc/" + FileName;
                }
                else
                {
                    Response.Write("<script>alert('只允许上传mp4的图片格式！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('没有文件上传')</script>");
            }
        }
    }
}