namespace MONO.Distribution.UIProcess
{
    public interface IPageHelper
    {
        int getPage(int pageSize, int RecordCount);
        string DataRecordTxt(int pageInd, int PageCount);
        string PageInfo(int pageIndex, int PageTotle);

        void SetPageSize(int size);

        void SetPageTotal(int total);
        void SetPageIndex(int index);
        void SetStartIndex(int index);
        void SetEndIndex(int index);
        void SetPageNumber(int count);

        int GetPageSize();
        int GetPageTotal();
        int GetPageIndex();
        int GetStartIndex();
        int GetEndIndex();
        int GetPageNumber();

    }
}
