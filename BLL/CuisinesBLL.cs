using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CuisinesBLL
    {
        CuisinesDAL CDL = new CuisinesDAL();
        /// <summary>
        /// 得到菜系
        /// </summary>
        /// <returns>菜系列表</returns>
        public List<Cuisines> GetCuisine()
        {
            return CDL.GetNewsCuisines();
        }

        /// <summary>
        /// 插入菜系
        /// </summary>
        /// <param name="cus">菜系</param>
        /// <returns>受影响行数</returns>
        public int InsertCuisines(Cuisines cus)
        {
            return CDL.InsertCuisines(cus);
        }

        /// <summary>
        /// 查询是否存在菜系
        /// </summary>
        /// <param name="cuisines">菜系名</param>
        /// <returns></returns>
        public bool HasCuisines(string cuisines)
        {
            return CDL.HasCuisines(cuisines);
        }
    }
}
