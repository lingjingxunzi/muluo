using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverOperates
{
    public interface IObserver<T>
    {
        void Update(Object sender, T e);
    }
}
