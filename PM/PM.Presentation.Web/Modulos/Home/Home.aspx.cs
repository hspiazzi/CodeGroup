using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PM.Presentation.Web.Modulos.Home
{
    public partial class Home : System.Web.UI.Page
    {
        public static void Show(TabPanel tab)
        {
            Ext.Net.Panel p = new Ext.Net.Panel();
            p.ID = "tabHome";
            p.Title = "&nbsp; Home";
            p.IconCls = "fa fa-home";
            p.Closable = false;
            p.IDMode = IDMode.Explicit;
            p.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            p.CloseAction = CloseAction.Destroy;
            p.Loader = new ComponentLoader
            {
                AutoLoad = true,
                LoadMask = { ShowMask = true },
                Mode = LoadMode.Frame,
                ShowWarningOnFailure = true,
                Url = Ext.Net.X.ResourceManager.ResolveClientUrl("~/Modulos/Home/Home")
            };
            p.Render(tab);
            tab.SetActiveTab(p);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}