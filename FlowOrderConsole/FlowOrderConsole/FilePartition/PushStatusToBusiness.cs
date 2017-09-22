using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FilePartition
{
    public class PushStatusToBusiness
    {

        public void GoToResearch()
        {
            try
            {
                string sql = string.Empty;
                string sendResult = string.Empty;
                DataTable BackData = null;
                sql = "update FD_PushResultRecords_Temp set sendstatus = '1' where PUSHRESULTRECORDtEMPkEY IN  (select PushResultRecordTempKey from (select *,ROW_NUMBER() OVER(ORDER BY CreateTime ) as numbers from FD_PushResultRecords_Temp )T where sendStatus is null  )";
                if (BaseCode.ExcuteSQL(sql) > 0)
                {
                    sql = "select * from (select *,ROW_NUMBER() OVER(ORDER BY CreateTime ) as numbers from FD_PushResultRecords_Temp )T where  sendStatus = '1' ;";
                    DataTable dt = BaseCode.GetDataTableBySql(sql);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            BaseCode.WriteLog("等待推送给商户的状态条数: " + dt.Rows.Count.ToString() );
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (string.IsNullOrEmpty(dt.Rows[i]["PushUrl"].ToString())) continue;
                                var url = dt.Rows[i]["PushUrl"].ToString();
                                if (dt.Rows[i]["PushUrl"].ToString().Contains("?"))
                                {
                                    url = url + "&";
                                }
                                else
                                {
                                    url = url + "?";
                                }
                                url = url + "orderId=" + dt.Rows[i]["OrderKey"] + "&result=" + dt.Rows[i]["Result"] + "&msg=" + dt.Rows[i]["Msg"] + "&transNo=" + dt.Rows[i]["BatchNo"];
                                BaseCode.WriteLog("回调地址：" + url );
                                var json = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                                BaseCode.WriteLog("回调返回：" + json );
                                sql = "update FD_PushResultRecords_Temp set sendstatus = '2' where PUSHRESULTRECORDtEMPkEY = " + dt.Rows[i]["PushResultRecordTempKey"];
                                BaseCode.ExcuteSQL(sql);
                                sql = "insert into FD_PushResultRecords(PushResultRecordKey,PushUrl,result,msg,OrderKey,CreateTime,BatchNo) values(" +
                                    dt.Rows[i]["PushResultRecordTempKey"] + "," + dt.Rows[i]["PushUrl"] + "," + dt.Rows[i]["Result"] + "," + dt.Rows[i]["Msg"] + " ," + dt.Rows[i]["OrderKey"] + "," + dt.Rows[i]["CreateTime"] + "," + dt.Rows[i]["BatchNo"] + ")";
                                BaseCode.ExcuteSQL(sql);
                                sql = "delete from FD_PushResultRecords_Temp where sendstatus = 2";
                                BaseCode.ExcuteSQL(sql);
                            }

                        }
                    }
                    dt.Dispose();
                }
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message);
            }
        }
    }
}
