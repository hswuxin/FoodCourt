using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class PictureBLL
    {
        PictureDAL PDL = new PictureDAL();

        /// <summary>
        /// 获取图片列表HTML串
        /// </summary>
        /// <returns>图片列表HTML串</returns>
//        /// 
//<a class="spotlight" href="gallery/california-1751455.jpg">
//            <img class="col-md-6 col-sm-6 col-xs-12 myrow" src="gallery/california-1751455-thumb.jpg">
//        </a>
        public string GetPictureListHtml()
        {
            List<Picture> pl = PDL.GetPictureList();
            string PictureString = "";
            try
            {
                for (int i = 0; i < pl.Count; i++)
                {
                    PictureString += "<a class='spotlight' href='" + pl.ElementAt(i).PicURL + "' data-description='" + pl.ElementAt(i).PicContent + "'>";
                    PictureString += "<img class='col-md-6 col-sm-6 col-xs-12 myrow' src='" + pl.ElementAt(i).PicThumURL + "' alt='" + pl.ElementAt(i).PicTitle + "'>";
                    PictureString += "</a>";
                }
            }
            catch
            {

            }
            return PictureString;
        }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <returns>图片列表</returns>
        public List<Picture> GetPictureList()
        {
            return PDL.GetPictureList();
        }

        /// <summary>
        /// 根据标题模糊查找图片列表
        /// </summary>
        /// <param name="pictitle">图片标题</param>
        /// <returns>图片列表</returns>
        public List<Picture> GetPictureListByTitle(string pictitle)
        {
            return PDL.GetPictureListByTitle(pictitle);
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="picture">图片实体</param>
        /// <returns>受影响行数</returns>
        public int InsertPicture(Picture picture)
        {
            return PDL.InsertPicture(picture);
        }

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="picture">图片实体</param>
        /// <returns>受影响行数</returns>
        public int UpdatePicture(Picture picture)
        {
            return PDL.UpdatePicture(picture);
        }

        /// <summary>
        /// 根据ID获取图片
        /// </summary>
        /// <param name="picid">ID</param>
        /// <returns>图片实体</returns>
        public Picture GetPictureById(int picid)
        {
            return PDL.GetPictureById(picid);
        }

        /// <summary>
        /// 根据ID删除图片
        /// </summary>
        /// <param name="picid">图片ID</param>
        /// <returns>受影响行数</returns>
        public int DeletePicture(int picid)
        {
            return PDL.DeletePicture(picid);
        }
    }
}
