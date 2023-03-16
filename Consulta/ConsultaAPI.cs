using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace SistemaWS.Consulta
{
    public class ConsultaAPI
    {
        #region CONSULTA API
        public string Consulta02(Envio envio)
        {
            string retornoXML = string.Empty;

            Stopwatch contador = new Stopwatch();
            string url = "https://linkparaenvio.com";

            #region GET
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Accept = "application/json; charset=utf-8;";
                httpWebRequest.Method = "GET";
                httpWebRequest.ClientCertificates.Add(new X509Certificate2(@"C:caminhocertificado.pfx", "1234"));

                contador.Start();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                contador.Stop();

                double duracao = contador.Elapsed.TotalSeconds;

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream())) { retornoXML = streamReader.ReadToEnd(); }
            }
            catch (Exception ex)
            {
                retornoXML = "<RETORNO><EXISTE_ERRO>1</EXISTE_ERRO><MSG_ERRO>ERRO AO CONSULTAR</MSG_ERRO></RETORNO>";

                if (contador.IsRunning) contador.Stop();
                double duracao = contador.Elapsed.TotalSeconds;
            }
            #endregion

            try
            {
                Envio Retorno01 = new JavaScriptSerializer().Deserialize<Envio>(retornoXML);
                retornoXML = ConvertRetornoParaXML(Retorno01);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retornoXML;
        }
        private string ConvertRetornoParaXML(Envio response)
        {
            StringBuilder retornoXML = new StringBuilder();

            try
            {
                retornoXML.Append("<RETORNO>");
                retornoXML.Append("<EXISTE_ERRO>0</EXISTE_ERRO>");
                retornoXML.Append("<NOME>" + response.Nome + "</NOME>");
                retornoXML.Append("<IDADE>" + response.Idade + "</IDADE>");
                retornoXML.Append("</RETORNO>");
            }
            catch (Exception ex)
            {
                retornoXML = new StringBuilder();

                retornoXML.Append("<RETORNO>");
                retornoXML.Append("<EXISTE_ERRO>1</EXISTE_ERRO>");
                retornoXML.Append("<MSG_ERRO> ERRO AO CONVERTER RETORNO.</MSG_ERRO>");
                retornoXML.Append("</RETORNO>");

            }
            return retornoXML.ToString();
        }
        #endregion
    }
}