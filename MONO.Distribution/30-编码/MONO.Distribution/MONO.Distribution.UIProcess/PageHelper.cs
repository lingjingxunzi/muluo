using System;
using System.Text;

namespace MONO.Distribution.UIProcess
{
    public class PageHelper : IPageHelper
    {
        int IPageHelper.getPage(int pageSize, int RecordCount)
        {
            int pageS = 0;
            if (RecordCount > 0)
            {
                if (RecordCount % 10 > 0) { pageS = RecordCount / 10 + 1; }
                else
                { pageS = RecordCount / pageSize; }
            }
            return pageS;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageInd">当前页导航</param>
        /// <param name="PageCount">数据总数</param>
        /// <returns></returns>
        string IPageHelper.DataRecordTxt(int pageInd, int PageCount)
        {
            string tmp = string.Empty;
            try
            {
                tmp = "共<i class=\"blue\">" + PageCount.ToString() + "</i>条记录，当前显示第&nbsp;<i class=\"blue\">" + pageInd.ToString() + "&nbsp;</i>页";
            }
            catch (Exception ex)
            {
                //BaseCode.WriteErrorLog(ex.Message.Replace(Environment.NewLine, string.Empty), HttpContext.Current.Server.MapPath("../") + "ErrorLog\\");
                tmp = "";
            }
            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex">页面导航页</param>
        /// <param name="PageTotle">数据总数</param>
        /// <returns></returns>
        string IPageHelper.PageInfo(int pageIndex, int PageTotle)
        {
            StringBuilder tmp = new StringBuilder();
            tmp.Append("<li class=\"paginItem\"><a href=\"javascript:toPage(" + (pageIndex - 1).ToString() + ");\"><span class=\"pagepre\"></span></a></li>");
            tmp.Append("<li class=\"paginItem \"><a href=\"javascript:;\">" + pageIndex.ToString() + "</a></li>");
            tmp.Append("<li class=\"paginItem\"><a href=\"javascript:toPage(" + (NextPageIndex()).ToString() + ");\"><span class=\"pagenxt\"></span></a></li>");
            return tmp.ToString();
        }



        void IPageHelper.SetPageSize(int size)
        {
            PageSize = size;
        }

        void IPageHelper.SetPageTotal(int total)
        {
            PageCount = total;
        }

        void IPageHelper.SetPageIndex(int index)
        {
            PageIndex = index;
        }

        int IPageHelper.GetPageSize()
        {
            return PageSize;
        }

        int IPageHelper.GetPageTotal()
        {
            return PageCount;
        }

        int IPageHelper.GetPageIndex()
        {
            return PageIndex;
        }

        void IPageHelper.SetStartIndex(int index)
        {
            StartIndex = index;
        }

        void IPageHelper.SetEndIndex(int index)
        {
            EndIndex = index;
        }

        int IPageHelper.GetStartIndex()
        {
            StartIndex = PageIndex > 0 ? ((PageIndex - 1) * PageSize + 1) : 1;
            return StartIndex;
        }

        int IPageHelper.GetEndIndex()
        {
            return StartIndex + PageSize - 1;
        }

        void IPageHelper.SetPageNumber(int count)
        {
            PageNumber = count;
        }

        int IPageHelper.GetPageNumber()
        {
            var num = PageCount / PageSize;
            if (PageCount % PageSize == 0)
            {
                PageNumber = num;
            }
            else
            {
                PageNumber = num + 1;
            }
            return PageNumber;
        }


        private int NextPageIndex()
        {
            if (PageIndex == GetPageNumber())
                return PageIndex;
            return PageIndex + 1;
        }

        private int GetPageNumber()
        {
            var num = PageCount / PageSize;
            if (PageCount % PageSize == 0)
            {
                PageNumber = num;
            }
            else
            {
                PageNumber = num + 1;
            }
            return PageNumber;
        }




        public int PageSize = 10;

        public int PageIndex = 0;

        public int PageCount = 0;


        public int StartIndex = 1;

        public int EndIndex;

        public int PageNumber = 0;

    }
}
