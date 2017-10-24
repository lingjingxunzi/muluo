using System.Text;

namespace CoolShow.Common
{
    public class ContentCombinationHandler
    {
        public static string GetContent(string content, params object[] param)
        {
            var contentwithParm = new StringBuilder();
            var conArr = content.Trim('@').Split('%');
            for (var i = 0; i < conArr.Length - 1; i++)
            {
                contentwithParm.Append(conArr[i] + param[i]);
            }
            contentwithParm.Append(conArr[param.Length]);
            return contentwithParm.ToString();
        }


    }
}
