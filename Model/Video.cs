using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Video
    {
        //视频ID
        private int videoID;

        public int VideoID
        {
            get { return videoID; }
            set { videoID = value; }
        }
        //视频标题
        private string videoTitle;

        public string VideoTitle
        {
            get { return videoTitle; }
            set { videoTitle = value; }
        }
        //视频封面
        private string videoThum;

        public string VideoThum
        {
            get { return videoThum; }
            set { videoThum = value; }
        }
        //视频地址
        private string videoURL;

        public string VideoURL
        {
            get { return videoURL; }
            set { videoURL = value; }
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
