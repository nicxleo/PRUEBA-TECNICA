using System.Web.UI;

namespace SegurosPrueba.Tools
{
    public class Util
    {
        public static void ShowMessage(string pTexto, Page pPage)
        {
            pPage.ClientScript.RegisterStartupScript(pPage.GetType(), "alert", "alert('" + pTexto + "');", true);
        }
    }
}