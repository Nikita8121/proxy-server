using proxy_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace proxy_server.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly HTTPService _httpService;
        private string _trasnsferorIp;
        private string _trasnsferorPort;
        private string _targetIp;
        private string _targetPort;
        private string _status;
        public ICommand StartCommand;
        public ICommand StopCommand;

        public HomeViewModel(HTTPService httpService)
        {
            _httpService = httpService;
        }
    }
}
