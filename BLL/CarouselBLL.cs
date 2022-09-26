using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CarouselBLL
    {
        CarouselDAL CDL = new CarouselDAL();

        /// <summary>
        /// 得到轮播图字符串
        /// </summary>
        /// <returns>轮播图字符串</returns>
        /// 
        //<div class="item active">
        //     <a href="#">
        //         <img src="/images/东坡肉.jpg" class=".img-responsive" alt="...">
        //     </a>
        //     <div class="carousel-caption">
        //         东坡肉
        //     </div>
        //</div>
        public string GetCarouselString()
        {
            List<Carousel> cs = CDL.GetCarousel();
            string CarouselString = "";
            if (cs.Count != 0)
            {
                for (int i = 0; i < cs.Count; i++)
                {
                    CarouselString += ((i == 1) ? "<div class='item active'>" : "<div class='item'>");
                    CarouselString += "<a href='" + cs.ElementAt(i).LinkURL + "'>";
                    CarouselString += "<img src='" + cs.ElementAt(i).ImgURL + "' class='.img-responsive' alt='" + cs.ElementAt(i).CarouselID + "'></a>";
                    CarouselString += "<div class='carousel-caption'>" + cs.ElementAt(i).CarouselTitle + "</div>";
                    CarouselString += "</div>";
                }
            }
            return CarouselString;
        }
    }
}
