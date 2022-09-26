using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class NewsBLL
    {
        NewsDAL NDL = new NewsDAL();

        /// <summary>
        /// 获得指定数量的新闻
        /// </summary>
        /// <param name="num">获得新闻的数量</param>
        /// <returns>新闻列表</returns>
        public List<News> GetNumbedNews(int num)
        {
            return NDL.GetNumbedNews(num);
        }
        /// <summary>
        /// 获取用户更多新闻列表HTML字符串
        /// </summary>
        /// <returns>用户新闻列表HTML字符串</returns>
        //<div class="col-md-4">
        //        <div class="thumbnail">
        //            <a href="/newscontent.aspx?id=">
        //                <img src="/images/红烧茄子.jpg" alt="...">
        //            </a>
        //            <div class="caption captionbox">
        //                <h3>
        //                    Thumbnail label
        //                </h3>
        //                <h4>
        //                    wuxin
        //                </h4>
        //            </div>
        //        </div>
        //    </div>
        public string GetListString()
        {
            List<News> news = NDL.GetAllNews();
            string ListString = "";
            if (news.Count != 0)
            {
                for (int i = 0; i < news.Count; i++)
                {
                    ListString += "<div class='col-md-4'>";
                    ListString += "<div class='thumbnail'>";
                    ListString += "<a href='/NewsListModular/newscontent.aspx?id=" + news.ElementAt(i).NewsID + "'>";
                    ListString += "<img src='" + news.ElementAt(i).NewsThum + "' alt='" + news.ElementAt(i).NewsID + "'>";
                    ListString += "</a>";
                    ListString += "<div class='caption captionbox'>";
                    ListString += "<h3>" + news.ElementAt(i).NewsTitle + "</h3>";
                    ListString += "<h4>" + news.ElementAt(i).NewsAuthor + "</h4>";
                    ListString += "</div></div></div>";
                }
            }
            return ListString;
        }

        /// <summary>
        /// 根据标题得到新闻的html串
        /// </summary>
        /// <param name="newstitle">标题</param>
        /// <returns>带标题的新闻列表html串</returns>
        public string GetListStringByTitle(string newstitle)
        {
            List<News> news = NDL.GetNewsByTitle(newstitle);
            string ListString = "";
            if (news != null)
            {
                for (int i = 0; i < news.Count; i++)
                {
                    ListString += "<div class='col-md-4'>";
                    ListString += "<div class='thumbnail'>";
                    ListString += "<a href='/NewsListModular/newscontent.aspx?id=" + news.ElementAt(i).NewsID + "'>";
                    ListString += "<img src='" + news.ElementAt(i).NewsThum + "' alt='" + news.ElementAt(i).NewsID + "'>";
                    ListString += "</a>";
                    ListString += "<div class='caption captionbox'>";
                    ListString += "<h3>" + news.ElementAt(i).NewsTitle + "</h3>";
                    ListString += "<h4>" + news.ElementAt(i).NewsAuthor + "</h4>";
                    ListString += "</div></div></div>";
                }
            }
            return ListString;
        }

        /// <summary>
        /// 查看是否有输入标题的新闻
        /// </summary>
        /// <param name="newstitle">标题</param>
        /// <returns>bool</returns>
        public bool HasStringByTitle(string newstitle)
        {
            bool flag = false;
            List<News> news = NDL.GetNewsByTitle(newstitle);
            if (news == null)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 根据分类获取新闻
        /// </summary>
        /// <param name="newsclass">分类</param>
        /// <returns>新闻列表</returns>
        public string GetListStringByClass(string newsclass)
        {
            List<News> news = NDL.GetNewsByClass(newsclass);
            string ListString = "";
            if (news != null)
            {
                for (int i = 0; i < news.Count; i++)
                {
                    ListString += "<div class='col-md-4'>";
                    ListString += "<div class='thumbnail'>";
                    ListString += "<a href='/NewsListModular/newscontent.aspx?id=" + news.ElementAt(i).NewsID + "'>";
                    ListString += "<img src='" + news.ElementAt(i).NewsThum + "' alt='" + news.ElementAt(i).NewsID + "'>";
                    ListString += "</a>";
                    ListString += "<div class='caption captionbox'>";
                    ListString += "<h3>" + news.ElementAt(i).NewsTitle + "</h3>";
                    ListString += "<h4>" + news.ElementAt(i).NewsAuthor + "</h4>";
                    ListString += "</div></div></div>";
                }
            }
            return ListString;
        }

        /// <summary>
        /// 根据ID得到新闻
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <returns>新闻</returns>
        public News GetNewsByID(int id)
        {
            return NDL.GetNewsByID(id);
        }

        /// <summary>
        /// 获得所有新闻
        /// </summary>
        /// <returns>新闻列表</returns>
        public List<News> GetAllNews()
        {
            return NDL.GetAllNews();
        }

        /// <summary>
        /// 模糊查找标题得到新闻列表
        /// </summary>
        /// <param name="newstitle">新闻标题</param>
        /// <returns>新闻列表</returns>
        public List<News> GetNewsByTitleList(string newstitle)
        {
            return NDL.GetNewsByTitle(newstitle);
        }

        /// <summary>
        /// 插入一条新闻
        /// </summary>
        /// <param name="news">新闻</param>
        /// <returns>受影响行数</returns>
        public int InsertNews(News news)
        {
            return NDL.InsertNews(news);
        }

        /// <summary>
        /// 更新新闻
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns>受影响行数</returns>
        public int UpdateNews(News news)
        {
            return NDL.UpdateNews(news);
        }

        /// <summary>
        /// 根据ID删除新闻
        /// </summary>
        /// <param name="newsid">新闻ID</param>
        /// <returns>受影响行数</returns>
        public int DeleteNews(int newsid)
        {
            return NDL.DeleteNews(newsid);
        }

        /// <summary>
        /// 获取新闻数量
        /// </summary>
        /// <returns>新闻数量</returns>
        public int GetNewsNumber()
        {
            return NDL.GetNewsNumber();
        }

        
        //{ value: 1048, name: 'Search Engine' },
        /// <summary>
        /// 图表HTML串
        /// </summary>
        /// <returns>图表HTML串</returns>
        public string GetChartsHtml()
        {
            List<News> ls =NDL.GetChartsHtml();
            string chartsstring = "";
            if (ls != null)
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    chartsstring += "{ value:" + ls.ElementAt(i).NewsClass + ", name: '" + ls.ElementAt(i).NewsCuisines + "' },";
                }
            }
            return chartsstring;
        }
    }
}
