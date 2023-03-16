using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaWS.Consulta;

namespace SistemaWS
{
    public class Envio
    {
        public string Token { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    public class Pesquisa
    {
        //Consulta.WSConsultar.WebFormConsulta 
        //private WebService. Consulta.WSConsultar.WsPesquisar _wsPesquisa;
        //private WSConsultar.WebFormConsulta wsPesquisa
        //{
        //    get
        //    {
        //        if (_wsPesquisa == null)
        //        {
        //            _wsPesquisa = new wsPesquisa.wsMegaLaudo();
        //            _wsPesquisa.Timeout = 45000;
        //        }
        //        return _wsPesquisa;
        //    }
        //}
    }
}