using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class VideoBLL
    {
        VideoDAL VDL = new VideoDAL();

        /// <summary>
        /// 获取视频列表HTML串
        /// </summary>
        /// <returns>列表HTML串</returns>
        /// 
        //<div class="col-md-6">
        //    <video poster="ckin.jpg" src="ckin.mp4" data-ckin="default" data-title="The curious case of Chameleon..."></video>
        //</div>
        public string GetVideoListHtml()
        {
            List<Video> lv = VDL.GetVideoList();
            string videostring = "";
            try
            {
                for (int i = 0; i < lv.Count; i++)
                {
                    videostring += "<div class='col-md-6'>";
                    videostring += "<video poster='" + lv.ElementAt(i).VideoThum + "' src='" + lv.ElementAt(i).VideoURL + "' data-ckin='default' data-color='#848484' data-title='" + lv.ElementAt(i).VideoTitle + "'></video>";
                    videostring += "</div>";
                }
            }
            catch
            {
 
            }
            return videostring;
        }

        /// <summary>
        /// 获取视频列表
        /// </summary>
        /// <returns>视频列表</returns>
        public List<Video> GetVideoList()
        {
            return VDL.GetVideoList();
        }

        /// <summary>
        /// 根据视频标题模糊查找视频
        /// </summary>
        /// <param name="videotitle">视频标题</param>
        /// <returns>视频列表</returns>
        public List<Video> GetVideoListByTitle(string videotitle)
        {
            return VDL.GetVideoListByTitle(videotitle);
        }

        /// <summary>
        /// 插入一条视频
        /// </summary>
        /// <param name="video">视频实体</param>
        /// <returns>受影响行数</returns>
        public int InsertVideo(Video video)
        {
            return VDL.InsertVideo(video);
        }

        /// <summary>
        /// 根据ID获取视频
        /// </summary>
        /// <param name="videoid">视频ID</param>
        /// <returns>视频实体</returns>
        public Video GetVideoByID(int videoid)
        {
            return VDL.GetVideoByID(videoid);
        }

        /// <summary>
        /// 更新视频
        /// </summary>
        /// <param name="video">视频实体</param>
        /// <returns>受影响行数</returns>
        public int UpdateVideo(Video video)
        {
            return VDL.UpdateVideo(video);
        }

        /// <summary>
        /// 根据ID删除视频
        /// </summary>
        /// <param name="videoid">视频ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteVideoByID(int videoid)
        {
            return VDL.DeleteVideoByID(videoid);
        }
    }
}
