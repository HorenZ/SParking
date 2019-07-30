using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class PartInfoDAL
    {
        /// <summary>
        /// 获取所有停车场信息
        /// </summary>
        /// <returns>List</returns>
        public List<PartInfo> GetAllPartAddress()
        {
            //1.准备参数
            List<PartInfo> list=new List<PartInfo>();
            //2.SQL语句
            string sqlcmd = "Select * From PartInfo";
            //3.执行底层方法
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd);
            while (reader.Read())
            {
                list.Add(new PartInfo()
                {
                    Address = reader["Address"].ToString(),
                    Choose = Convert.ToBoolean(reader["Choose"]), 
                    Grade = Convert.ToSingle(reader["Grade"]),
                    Name = reader["Name"].ToString(),
                    ParkID = Convert.ToInt32(reader["ParkID"]),
                    Price = Convert.ToDecimal(reader["Price"]),
                    ProvinceID = Convert.ToInt32(reader["ProvinceID"]),
                    State = Convert.ToBoolean(reader["State"])
                });
            }
            //4.返回
            return list;
        }
    }
}
