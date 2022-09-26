using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Cuisines
    {
        //菜系名
        string newsCuisines;

        public string NewsCuisines
        {
            get { return newsCuisines; }
            set { newsCuisines = value; }
        }
        //描述
        string cuisinesContent;

        public string CuisinesContent
        {
            get { return cuisinesContent; }
            set { cuisinesContent = value; }
        }
    }
}
