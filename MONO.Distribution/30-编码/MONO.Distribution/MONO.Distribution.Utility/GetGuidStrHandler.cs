using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Utility
{
    public class GetGuidStrHandler
    {
        public static string GenerateStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        public static string GenerateDt023ID()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
