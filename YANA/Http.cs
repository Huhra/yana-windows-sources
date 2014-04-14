/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de gestion de requetes HTTP (requetes asynchrones)
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace YANA
{
    class Http
    {

        public static void get(string url, AsyncCallback method)
        {
            SSLValidator.OverrideValidation();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/html";
            request.Method = WebRequestMethods.Http.Get;
            //request.Timeout = 2000;
            request.Proxy = null;
            IAsyncResult result = (IAsyncResult)request.BeginGetResponse(method, request);
            ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), request, Program.REQUEST_TIMEOUT, true);

        }

        // Abort the request if the timer fires. 
        private static void TimeoutCallback(object state, bool timedOut)
        {
            if (timedOut)
            {
                HttpWebRequest request = state as HttpWebRequest;
                if (request != null)
                {
                    MainWindow mainWindow = MainWindow.getInstance();
                    mainWindow.Invoke((MethodInvoker)delegate
                    {
                        mainWindow.addMessage("Ton URL m'a l'air foireuse, ou ton serveur n'est pas allumé", true);
                    });
                    Function.error("Timeout sur l'url :" + request.RequestUri + " (url invalide ou yana-server inactif, si votre réseau est lent, tentez d'augmenter le timeout dans les configurations)");
                    request.Abort();
                }
            }
        }


        public static void callback(IAsyncResult result)
        {
            HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                string strContent = sr.ReadToEnd();
                Console.WriteLine(strContent);
            }
            // request.EndGetResponse(result);
        }

    }

    public static class SSLValidator
    {
        private static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain,
                                                  SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public static void OverrideValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                OnValidateCertificate;
            ServicePointManager.Expect100Continue = true;
        }
    }
}
