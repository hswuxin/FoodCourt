using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Picture
    {
        //图片ID
        private int picID;

        public int PicID
        {
            get { return picID; }
            set { picID = value; }
        }
        //图片标题
        private string picTitle;

        public string PicTitle
        {
            get { return picTitle; }
            set { picTitle = value; }
        }
        //图片描述
        private string picContent;

        public string PicContent
        {
            get { return picContent; }
            set { picContent = value; }
        }
        //缩略图
        private string picThumURL;

        public string PicThumURL
        {
            get { return picThumURL; }
            set { picThumURL = value; }
        }
        //大图
        private string picURL;

        public string PicURL
        {
            get { return picURL; }
            set { picURL = value; }
        }
        //添加时间
        private DateTime addTime;

        public DateTime AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }
    }
}
