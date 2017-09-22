using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace MONO.Order.Test
{
    public class FileComparer : IComparer
    {
        int IComparer.Compare(Object o1, Object o2)
        {
            FileInfo fi1 = o1 as FileInfo;
            FileInfo fi2 = o2 as FileInfo;
            return fi2.CreationTime.CompareTo(fi1.CreationTime);
        }
    }
}
