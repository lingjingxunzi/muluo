using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.FlowAgentViewModels;

namespace MONO.Distribution.Test
{
    public partial class OrderSuccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                var str =Request.QueryString["data"];

               var strs = str.TrimStart('[').TrimEnd(']');
               var model = new JavaScriptSerializer().Deserialize<XYCallBackModels>(str.TrimStart('[').TrimEnd(']'));
               
            }
        }
    }
}