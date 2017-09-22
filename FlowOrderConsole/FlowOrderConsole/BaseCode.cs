using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using log4net;

namespace FlowOrderConsole
{
    class BaseCode
    {
        static ILog LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region BaseCode                                                              ●构造函数
        public BaseCode()
        {

        }
        #endregion

        #region GetSysConnect                                                      ●取得连接对象
        public static OleDbConnection GetSysConnect()
        {
            OleDbConnection gCon = ConnectToDB();
            return gCon;
        }
        #endregion

        #region ConnectToDB                                                        ●连接到数据库
        private static OleDbConnection ConnectToDB()
        {
            string configStr = getConfig();
            string serverIP = configStr.Split(Convert.ToChar(";"))[0];//ConfigurationManager.AppSettings["ServerIP"];
            string serverUser = configStr.Split(Convert.ToChar(";"))[1];
            string dbName = configStr.Split(Convert.ToChar(";"))[3];
            string userPwd = configStr.Split(Convert.ToChar(";"))[2];
            string strCon = "Provider=SQLOLEDB;Data Source=" + serverIP + ";User ID=" + serverUser + ";Password=" + userPwd + ";Initial Catalog=" + dbName;// + ";Trusted_Connection=yes";
            OleDbConnection newgCon = new OleDbConnection();
            newgCon.ConnectionString = strCon;
            newgCon.Open();
            return newgCon;
        }
        #endregion

        #region ExcuteSQL                                                          ●执行SQL
        /// <summary>
        /// 执行一句SQL文
        /// </summary>
        public static int ExcuteSQL(string sql)
        {
            OleDbConnection con = GetSysConnect();
            //事务处理--开始
            OleDbTransaction tran = con.BeginTransaction(IsolationLevel.Unspecified);
            OleDbCommand cmd = new OleDbCommand();
            int tmp = 0;
            try
            {
                cmd = new OleDbCommand(sql, con);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                //事务处理--提交
                tran.Commit();
                tmp = 1;
            }
            catch (Exception ex)
            {
                //事务处理--回滚
                tran.Rollback();
                tmp = 0;
                throw ex;

            }
            finally
            {
                cmd.Dispose();
                tran.Dispose();
                con.Dispose();
            }
            return tmp;
        }
        #endregion

        #region GetDataTableBySql                                                  ●通过一条SQL得到一张DataTable
        public static DataTable GetDataTableBySql(string sql)
        {
            DataTable dt = new DataTable();
            OleDbConnection con = GetSysConnect();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        #endregion

        #region 写日志
        public static void WriteLog(string LogInfo)
        {
            try
            {
                LogMsg.Info(LogInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region 读取配置
        public static string getConfig()
        {
            string tmp = string.Empty;
            try
            {
                StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + "/config.txt", Encoding.GetEncoding("utf-8"));
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(line.Trim()))
                    {
                        tmp = line.ToString();
                        break;
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tmp = "";
            }
            return tmp;
        }
        #endregion

        #region 更新账户条数
        public static bool updateUserBalance(string userCode, int toCount)
        {
            bool tmp = false;
            try
            {
                string sql = string.Empty;
                if (chkAccount(userCode))
                {
                    sql = "update Sms_User_Balance set UserBalance = UserBalance + " + toCount.ToString() + " where UserCode = '" + userCode + "'";
                }
                else
                {
                    sql = "insert into Sms_User_Balance(UserBalance,UserCode) values (" + toCount.ToString() + ",'" + userCode + "')";
                }
                int result = BaseCode.ExcuteSQL(sql);
                if (result > 0)
                {
                    tmp = true;
                }
                else
                {
                    tmp = false;
                }
            }
            catch (Exception ex)
            {
                //BaseCode.WriteErrorLog(ex.Message.Replace(Environment.NewLine, string.Empty), HttpContext.Current.Server.MapPath("../") + "ErrorLog\\");
                WriteLog(ex.Message);
                tmp = false;
            }
            return tmp;
        }

        public static bool chkAccount(string userCode)
        {
            bool tmp = false;
            try
            {
                string sql = "select * from Sms_User_Balance where UserCode = '" + userCode + "'";
                DataTable dt = BaseCode.GetDataTableBySql(sql);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        tmp = true;
                    }
                    else
                    {
                        tmp = false;
                    }
                }
                else
                {
                    tmp = false;
                }
                dt.Dispose();
            }
            catch (Exception ex)
            {
                //BaseCode.WriteErrorLog(ex.Message.Replace(Environment.NewLine, string.Empty), HttpContext.Current.Server.MapPath("../") + "ErrorLog\\");
                WriteLog(ex.Message);
                tmp = false;
            }
            return tmp;
        }
        #endregion

        #region 插入账户明细记录
        public static bool insertAccountDetail(string userCode, int ChargeType, int Charge, string ChargeNote, string Operator, string toUser, string InterSeq)
        {
            bool tmp = false;
            try
            {
                string sql = "insert into Sms_User_Account_Detail (UserCode,ChargeType,Charge,ChargeNote,ChargeDate,Operator,toUser,InterSeq) values ('" + userCode + "'," + ChargeType.ToString() + "," + Charge.ToString() + ",'" + ChargeNote + "',getdate(),'" + Operator + "','" + toUser + "','" + InterSeq + "')";
                int result = ExcuteSQL(sql);
                if (result > 0)
                {
                    tmp = true;
                }
                else
                {
                    tmp = false;
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                tmp = false;
            }
            return tmp;
        }
        #endregion

        #region 获取用户通道编号,需要用户代码和号码电信类型
        public static int getUserSmsChannel(string userCode, int TeleComCode)
        {
            int tmp = 0;
            try
            {
                string sql = "select * from Sms_User_Conf where UserCode = '" + userCode + "'";
                DataTable dt = BaseCode.GetDataTableBySql(sql);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        switch (TeleComCode)
                        {
                            case 1: tmp = int.Parse(dt.Rows[0]["SmsTelecom"].ToString()); break;
                            case 2: tmp = int.Parse(dt.Rows[0]["SmsUnicom"].ToString()); break;
                            case 3: tmp = int.Parse(dt.Rows[0]["SmsMobile"].ToString()); break;
                        }
                    }
                    else
                    {
                        tmp = 0;
                    }
                }
                else
                {
                    tmp = 0;
                }
                dt.Dispose();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message.Replace(Environment.NewLine, string.Empty));
                tmp = 0;
            }
            return tmp;
        }
        #endregion
    }
}
