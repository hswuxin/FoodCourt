using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Carousel
    {
        //轮播图ID
        private int carouselID;

        public int CarouselID
        {
            get { return carouselID; }
            set { carouselID = value; }
        }
        //跳转地址
        private string linkURL;

        public string LinkURL
        {
            get { return linkURL; }
            set { linkURL = value; }
        }
        //图片地址
        private string imgURL;

        public string ImgURL
        {
            get { return imgURL; }
            set { imgURL = value; }
        }
        //标题
        private string carouselTitle;

        public string CarouselTitle
        {
            get { return carouselTitle; }
            set { carouselTitle = value; }
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
