using System;

namespace CoolCode.Web
{
    public class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/home/index");
        }
    }
}