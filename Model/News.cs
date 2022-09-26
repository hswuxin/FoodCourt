using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class News
    {
        //新闻ID
        private int newsID;

        public int NewsID
        {
            get { return newsID; }
            set { newsID = value; }
        }
        //新闻标题
        private string newsTitle;

        public string NewsTitle
        {
            get { return newsTitle; }
            set { newsTitle = value; }
        }
        //新闻作者
        private string newsAuthor;

        public string NewsAuthor
        {
            get { return newsAuthor; }
            set { newsAuthor = value; }
        }
        //省份
        private string newsProvince;

        public string NewsProvince
        {
            get { return newsProvince; }
            set { newsProvince = value; }
        }
        //菜系
        private string newsCuisines;

        public string NewsCuisines
        {
            get { return newsCuisines; }
            set { newsCuisines = value; }
        }
        //附加分类
        private string newsClass;

        public string NewsClass
        {
            get { return newsClass; }
            set { newsClass = value; }
        }
        //内容
        private string newsContent;

        public string NewsContent
        {
            get { return newsContent; }
            set { newsContent = value; }
        }
        //添加时间
        private DateTime newsAddTime;

        public DateTime NewsAddTime
        {
            get { return newsAddTime; }
            set { newsAddTime = value; }
        }

        //缩略图
        private string newsThum;

        public string NewsThum
        {
            get { return newsThum; }
            set { newsThum = value; }
        }
    }
}
