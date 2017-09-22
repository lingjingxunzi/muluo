using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FlowOrderConsole.Tools
{
    public class CarrierCharManipulation
    {
        public static string GetStrByMd5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }

        public static byte[] GetAbstractByMd5(string str)
        {
            byte[] result = Encoding.UTF8.GetBytes(str);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return output;
        }


        public static string GetMd5ForJn(int code, string str)
        {
            string strmd5 = "";
            byte[] result = Encoding.UTF8.GetBytes(str);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string md5str = BitConverter.ToString(output).Replace("-", "");

            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                strmd5 = md5str.Substring(8, 16);
            }
            if (code == 32) //32位加密 
            {
                strmd5 = md5str;
            }
            return strmd5;
        }


        public static string SHA1(string text)
        {
            byte[] cleanBytes = Encoding.Default.GetBytes(text);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        public static string GetSign(string text)
        {
            var shaStr = SHA1(text);
            var sig = new StringBuilder();
            for (var i = 0; i < shaStr.Length; i++)
            {
                if (i % 3 == 1)
                    sig.Append(shaStr[i]);
            }
            return sig.ToString();
        }
        /// <summary>  
        /// AES加密  
        /// </summary>  
        /// <param name="toEncrypt">加密串</param>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public static string Encrypt_Cu0531(string toEncrypt, string key)
        {
            byte[] resultArray = Encrypt_byte(toEncrypt, key);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>  
        /// AES加密  
        /// </summary>  
        /// <param name="toEncrypt">加密串</param>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        private static byte[] Encrypt_byte(string toEncrypt, string key)
        {
            key = getIv(key);
            byte[] keyArray = encoding.GetBytes(key);
            byte[] toEncryptArray = encoding.GetBytes(toEncrypt);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);  
            return resultArray;
        }

        public static string SHA256(string str)
        {
            //如果str有中文，不同Encoding的sha是不同的！！
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);

            SHA256Managed Sha256 = new SHA256Managed();
            byte[] by = Sha256.ComputeHash(SHA256Data);

            return BitConverter.ToString(by).Replace("-", "").ToLower(); //64
            //return Convert.ToBase64String(by);                         //44
        }

        /// <summary>  
        /// 选择加密因子  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        private static string getIv(string key)
        {
            if (key == null || key.Trim() == "")
            {
                return myIV;
            }
            else
            {
                return key;
            }
        }

       
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            try
            {

                var des = new DESCryptoServiceProvider();
                //以下两个很重要 ，解决了其它语言结果不一样的问题
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                //把字符串放到byte数组中   //原来使用的UTF8编码，我改成Unicode编码了，不行  
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                //建立加密对象的密钥和偏移量  //原文使用ASCIIEncoding.ASCII方法的GetBytes方法   //使得输入密码必须输入英文文本            
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();

            }
            catch (Exception ex)
            {

            }
            return "";
        }


        public static string StringToBase64(string str)
        {
            Encoding encode = Encoding.ASCII;
            byte[] bytedata = encode.GetBytes(str);
            return Convert.ToBase64String(bytedata, 0, bytedata.Length);
        }

        public static string CU023Encode(String txt)
        {
            byte[] result = Encoding.GetEncoding("GBK").GetBytes(txt);
            MD5 md5 = new MD5CryptoServiceProvider();
            var sb = new StringBuilder();
            byte[] targets = md5.ComputeHash(result);//byte[] md = mdTemp.digest();

            int j = targets.Length;
            char[] str = new char[j * 2];
            int k = 0;
            for (int i = 0; i < j; i++)
            {
                byte byte0 = targets[i];
                str[(k++)] = HEX_DIGITS[MoveByte(byte0, 4) & 0xF];
                str[(k++)] = HEX_DIGITS[(byte0 & 0xF)];
            }
            return new String(str);
        }


        /// <summary>
        /// 特殊的右移位操作，补0右移，如果是负数，需要进行特殊的转换处理（右移位）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int MoveByte(int value, int pos)
        {
            if (value < 0)
            {
                string s = Convert.ToString(value, 2);    // 转换为二进制
                for (int i = 0; i < pos; i++)
                {
                    s = "0" + s.Substring(0, 31);
                }
                return Convert.ToInt32(s, 2);            // 将二进制数字转换为数字
            }
            else
            {
                return value >> pos;
            }
        }


        private static char[] HEX_DIGITS = { '0', '1', 't', '3', 'r', '5', '4', 'p', '8', '9', 'l', 's', 'b', 's', 'd', 'j' };



        public static string GetMd5(int code, string str)
        {
            string strmd5 = "";
            byte[] result = Encoding.Default.GetBytes(str);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string md5str = BitConverter.ToString(output).Replace("-", "");

            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                strmd5 = md5str.Substring(8, 16);
            }
            if (code == 32) //32位加密 
            {
                strmd5 = md5str;
            }
            return strmd5;
        }


        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string myIV = "2993822400392426";
        public static Encoding encoding = UTF8Encoding.UTF8;

    }
}
