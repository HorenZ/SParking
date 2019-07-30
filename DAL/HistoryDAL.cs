using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class HistoryDAL
    {
        public bool SaveHistory(History his)
        {
            SqlParameter[] paras=new SqlParameter[9];
            paras[0]=new SqlParameter("@PortName",his.PortName);
            paras[1]=new SqlParameter("@StartTime",his.StartTime);
            paras[2] = new SqlParameter("@EndTime", his.EndTime);
            paras[3] = new SqlParameter("@AllTime", his.AllTime);
            paras[4] = new SqlParameter("@Cost", his.Cost);
            paras[5] = new SqlParameter("@PortPrice", his.PortPrice);
            paras[6] = new SqlParameter("@UserName", his.UserName);
            paras[7] = new SqlParameter("@State", his.State);
            paras[8]=new SqlParameter("@CarNum",his.CarNum);
            string sqlcmd =
                "Insert into History Values(@PortName,@StartTime,@EndTime,@AllTime,@Cost,@PortPrice,@UserName,@State,@CarNum)";
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                paras);
            if (i==1)
            {
                return true;
            }

            return false;
        }
    }
}
