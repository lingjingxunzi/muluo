using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverOperates
{
    public class CreditCard : EventArgs
    {
        private float _spendAmount;
        public event EventHandler<CreditCard> SpendMoney;

        public float SpendAmount
        {
            get
            {
                return _spendAmount;
            }
            set
            {
                _spendAmount = value;
                Notify();
            }
        }

        private void Notify()
        {
            if (SpendMoney != null)
            {
                SpendMoney(this, this);
            }
        }
    }
}
