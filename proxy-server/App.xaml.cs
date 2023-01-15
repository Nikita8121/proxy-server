using proxy_server.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace proxy_server
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private HttpServer _httpServer;

        public App()
        {
            _httpServer = new HttpServer();
            _httpServer.Start();
        }
    }
}
