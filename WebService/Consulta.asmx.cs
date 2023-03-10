using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SistemaWS.WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class ConsultaWs : System.Web.Services.WebService
    {
        #region Consulta 01
        [WebMethod(Description = "Retorna STRING", MessageName = "Consulta01")]
        public string Consulta_01(string strTexto)
        {
            return strTexto;
        }
        #endregion

        #region Consulta 02
        [WebMethod(Description = "Retorna STRING", MessageName = "Consulta02")]
        public string Consulta_02(Envio envio)
        {
            if (envio.Nome == "Victor")
            {
                return "Sucesso";
            }
            else
            {
                return "Erro";
            }
        }
        #endregion
    }
}
