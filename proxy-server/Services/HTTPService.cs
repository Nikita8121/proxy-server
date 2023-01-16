using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace proxy_server.Services
{
    public class HTTPService
    {
        public int Port = 8080;

        private HttpListener _listener;
        static readonly HttpClient client = new HttpClient();


        public void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + Port.ToString() + "/");
            _listener.Start();
            Receive();
        }

        public void Stop()
        {
            _listener.Stop();
        }

        private void Receive()
        {
            _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }

        private void ListenerCallback(IAsyncResult result)
        {
            if (_listener.IsListening)
            {
                var context = _listener.EndGetContext(result);
                var request = context.Request;
                int gg1 = request.RemoteEndPoint.Port;
                string gg2 = request.RemoteEndPoint.Address.ToString();

                // do something with the request
                Console.WriteLine($"{request.Url}");

                Receive();

                var response = context.Response;
                SendResponse(response);
            }
        }

        private async Task SendResponse(HttpListenerResponse response)
        {

            try
            {
                using HttpResponseMessage httpResponse = await client.GetAsync("http://www.contoso.com/");
                httpResponse.EnsureSuccessStatusCode();
                string responseBody = await httpResponse.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);

                response.StatusCode = (int)HttpStatusCode.OK;
                response.ContentType = "text/plain";
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] b = encoding.GetBytes(responseBody);
                response.OutputStream.Write(b, 0, b.Length);
                //response.OutputStream.Close();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            finally
            {
                response.Close();
            }
            
        }


    }
}
