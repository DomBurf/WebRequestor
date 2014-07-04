using System;

namespace WebRequestor
{
    class WebRequestorClient
    {
        static void TestClient(string[] args)
        {
            if (args == null) return;
            if (args.Length == 0) return;

            try
            {
                string webUrl = args[0];
                string webResponseType = args[1];
                string webParameters = args[2];

                Console.WriteLine("URL={0}", webUrl);
                Console.WriteLine("ResponseType={0}", webResponseType);
                Console.WriteLine("Parameters={0}", webParameters);

                WebRequestor requestor = new WebRequestor(webUrl, webResponseType, webParameters);
                Console.WriteLine(requestor.GetResponse());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Message={0}", ex.Message);
                Console.WriteLine("Stack={0}", ex.StackTrace);
                Console.WriteLine("InnerException={0}", ex.InnerException);
                Console.WriteLine("Source={0}", ex.Source);
                Console.WriteLine("TargetSite={0}", ex.TargetSite);
            }
        }
    }
}
