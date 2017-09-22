using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObserverOperates;

namespace ObserverTest
{
    public partial class Top : System.Web.UI.Page, ObserverOperates.IObserver<CreditCard>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Update(object sender, CreditCard e)
        {
            lblAmount.Text = (int.Parse(lblAmount.Text) + 1).ToString();
        }
    }
}