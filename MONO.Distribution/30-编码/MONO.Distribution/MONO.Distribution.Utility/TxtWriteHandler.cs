using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Utility
{
    public class TxtWriteHandler
    {
        public static void FileStreamWrite(string folder, string txtName, string txtContent)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            FileStream fs = new FileStream(folder + "//" + txtName, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(txtContent);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
}
