using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.DAO;
using CMCS.DumblyConcealer.Tasks.BeltBalancer.Entities;
using CMCS.Common;

namespace CMCS.DumblyConcealer.Tasks.BeltBalancer
{
    /// <summary>
    /// 皮带秤接口业务
    /// </summary>
    public class EquBeltBalancerDAO
    {
        private EquBeltBalancerDAO()
        { }

        private static EquBeltBalancerDAO instance;
        CommonDAO commonDAO = CommonDAO.GetInstance();

        public static EquBeltBalancerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new EquBeltBalancerDAO();
            }
            return instance;
        }


        /// <summary>
        /// 插入或修改标签
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="tagValue"></param> 
        /// <param name="symbolName"></param> 
        public CmcsBeltBalancerValue IUTagValue(string tagName, string tagValue, string symbolName)
        {
            CmcsBeltBalancerValue entity = Dbers.GetInstance().SelfDber.Entity<CmcsBeltBalancerValue>("where TagName=:TagName", new { TagName = tagName });
            if (entity == null)
            {
                entity = new CmcsBeltBalancerValue()
                {
                    TagName = tagName,
                    TagValue = tagValue,
                    SymbolName = symbolName,
                    TagTime = DateTime.Now
                };
                Dbers.GetInstance().SelfDber.Insert(entity);
            }
            else
            {
                entity.LastModificAtionTime = DateTime.Now;
                entity.TagTime = DateTime.Now;
                entity.TagName = tagName;
                entity.TagValue = tagValue;
                Dbers.GetInstance().SelfDber.Update(entity);
            }

            return entity;
        }

        /// <summary>
        /// 插入历史
        /// </summary>
        /// <param name="entity"></param> 
        public void InsertTagValueHistory(CmcsBeltBalancerValue entity)
        {
            Dbers.GetInstance().SelfDber.Insert(new CmcsBeltBalancerHistoryValue()
            {
                CreationTime = entity.CreationTime,
                LastModificAtionTime = entity.LastModificAtionTime,
                TagName = entity.TagName,
                TagValue = entity.TagValue,
                TagTime = entity.TagTime,
                SymbolName = entity.SymbolName
            });
        }

    }
}
