using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class ProvinceInfoDAL
    {
        public List<ProvinceInfo> GetAllProvinceInfo()
        {
            List<ProvinceInfo> list = new List<ProvinceInfo>();
            string sqlcmd = "Select * From ProvinceInfo Order by pinyin";
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd);
            ProvinceInfo province;
            while (reader.Read())
            {
                province=new ProvinceInfo();
                province.Name = reader["Name"].ToString();
                province.Simple = reader["Simple"].ToString();
                list.Add(province);
            }

            return list;
        }
    }
}
