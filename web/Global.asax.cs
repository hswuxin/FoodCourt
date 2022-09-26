using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace web
{
    public class Global : System.Web.HttpApplication
    {
        string sLogFile = AppDomain.CurrentDomain.BaseDirectory + "VisitedLog.txt";//日志文件的路径
        protected void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            // Code that runs on application startup
            //刚启动，为了防止服务器意外死机重启等因素，需要从记录文件中读取数目
            if (!System.IO.File.Exists(sLogFile))
            {
                System.IO.FileStream fsnew = System.IO.File.Create(sLogFile);
                fsnew.Close();
            }
            string[] lines = System.IO.File.ReadAllLines(sLogFile);//读取并得到日志文件的行数
            double iTotalCount = 0;//设置初始访问人数为0
            int iOnline = 0;//设置初始在线人数为0
            if (lines != null && lines.Length > 0)
            {
                Double.TryParse(lines[lines.Length - 1].ToString(), out iTotalCount);
            }
            Application["TotalCount"] = iTotalCount;
            Application["Online"] = iOnline;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            // Code that runs when a new session is started
            Session.Timeout = 10;
            Application.Lock();//锁定变量
            Application["TotalCount"] = System.Convert.ToDouble(Application["TotalCount"]) + 1;//为页面访问量+1
            Application["Online"] = System.Convert.ToInt32(Application["Online"]) + 1;//为页面在线人数+1
            Application.UnLock();//解锁
            if (Convert.ToInt32(Application["TotalCount"]) % 50 == 0) //为了防止服务器死机重启等意外因素丢失数据，我们每隔50个访客更新一下记录文件,这个需要根据访问量调整
            {
                System.IO.StreamWriter rw = System.IO.File.CreateText(sLogFile);
                rw.WriteLine(Application["TotalCount"]);
                rw.Flush();
                rw.Close();
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。
            Application.Lock();
            Application["Online"] = System.Convert.ToInt32(Application["Online"]) - 1;//在线人数减1
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //在应用程序关闭时运行的代码
            //保存当前访问
            System.IO.StreamWriter rw = System.IO.File.CreateText(sLogFile);
            rw.WriteLine(Application["TotalCount"]);
            rw.Flush();
            rw.Close();
        }
    }
}