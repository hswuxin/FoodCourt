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
    public partial class picedit : System.Web.UI.Page
    {
        PictureBLL PBL = new PictureBLL();
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
                    Picture pic = PBL.GetPictureById(Convert.ToInt32(Request.QueryString["id"]));
                    pictitle.Text = pic.PicTitle;
                    piccontent.Text = pic.PicContent;
                    Label2.Text = pic.PicThumURL;
                    Label1.Text = pic.PicURL;
                    picaddtime.Text = pic.AddTime.ToString();
                }
                if (Request.QueryString["type"] == "delete" && Request.QueryString["id"] != null)
                {
                    //删除图片
                    Picture pic = PBL.GetPictureById(Convert.ToInt32(Request.QueryString["id"]));
                    File.Delete(Server.MapPath(pic.PicThumURL));
                    File.Delete(Server.MapPath(pic.PicURL));

                    if (PBL.DeletePicture(Convert.ToInt32(Request.QueryString["id"])) != 0)
                    {
                        Response.Write("<script>alert('删除成功！');window.location.href='/admin/picturemanage.aspx'</script>");
                    }
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
                    FilePath = Path.Combine(Server.MapPath("/PictureListModular/gallery/"), FileName);
                    FileUpload1.SaveAs(FilePath);
                    PnlCrop.Visible = true;
                    Imgtocrop.ImageUrl = "/PictureListModular/gallery/" + FileName;
                    Label1.Text = "/PictureListModular/gallery/" + FileName;
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

        protected void PnlCrop_DataBinding(object sender, EventArgs e)
        {

        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            string croppedFileName = string.Empty;
            string croppedFilePath = string.Empty;
            string fileName = Path.GetFileName(Imgtocrop.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("/PictureListModular/gallery"), fileName);
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
                    croppedFilePath = Path.Combine(Server.MapPath("/PictureListModular/gallery/thum/"), croppedFileName);
                    bitmap.Save(croppedFilePath);//保存裁剪的图片到Images文件夹
                    orgimg.Dispose();//释放图片资源
                    bitmap = null;
                    //File.Delete(filePath);
                    PnlCrop.Visible = false;
                    lblMsg.Text = "裁剪成功";
                    lblMsg.ForeColor = Color.Green;
                    Imgcroped.ImageUrl = "/PictureListModular/gallery/thum/" + croppedFileName;
                    Label2.Text = Imgcroped.ImageUrl;
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
            if (Label1.Text=="" || Label2.Text == "")
            {
                Response.Write("<script>alert('请上传图片！')</script>");
                return;
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<script>alert('未查询到图片！')</script>");
                return;
            }
            Picture picture = new Picture();
            picture.PicID=Convert.ToInt32(Request.QueryString["id"]);
            picture.PicTitle = pictitle.Text;
            picture.PicContent = piccontent.Text;
            picture.PicThumURL = Label2.Text;
            picture.PicURL = Label1.Text;
            picture.AddTime = Convert.ToDateTime(picaddtime.Text);
            if (PBL.UpdatePicture(picture) != 0)
            {
                Response.Write("<script>alert('更新成功！');window.location.href='/admin/picturemanage.aspx'</script>");
            }
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (Label1.Text == "" || Label2.Text == "")
            {
                Response.Write("<script>alert('请上传图片！')</script>");
                return;
            }
            Picture picture = new Picture();
            picture.PicTitle = pictitle.Text;
            picture.PicContent = piccontent.Text;
            picture.PicThumURL = Label2.Text;
            picture.PicURL = Label1.Text;
            picture.AddTime =Convert.ToDateTime(picaddtime.Text);
            if (PBL.InsertPicture(picture) != 0)
            {
                Response.Write("<script>alert('添加成功！');window.location.href='/admin/picturemanage.aspx'</script>");
            }
        }
    }
}