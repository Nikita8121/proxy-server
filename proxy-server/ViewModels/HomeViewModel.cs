using proxy_server.Commands;
using proxy_server.Models;
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
        public HTTPService HTTPService => _httpService;
        private string _transferorIp;
        private string _transferorPort;
        private string _targetIp;
        private string _targetPort;
        private string _status;
        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        public bool IsAdressesValid => IpAddress.Validate(new IpAddress(_transferorIp, _transferorIp)) && IpAddress.Validate(new IpAddress(_targetIp, _targetPort));


        public HomeViewModel(HTTPService httpService)
        {
            _httpService = httpService;

            StartCommand = new StartComand(this);
            StopCommand = new StopCommand(this);
            SetStopText();
        }

        public string TransferorIp
        {
            get => _transferorIp;
            set
            {
                _transferorIp = value;
                OnPropertyChanged(nameof(TransferorIp));
            }
        }

        public string TransferorPort
        {
            get => _transferorPort;
            set
            {
                _transferorPort = value;
                OnPropertyChanged(nameof(TransferorPort));
            }
        }

        public string TargetIp
        {
            get => _targetIp;
            set { _targetIp = value; OnPropertyChanged(nameof(TargetIp)); }
        }
        public string TargetPort { get => _targetPort; set { _targetPort = value; OnPropertyChanged(nameof(TargetPort)); } }
        public string Status 
        { 
          get 
            { 
                return _status; 
            }  
          set 
            { 
                _status = value; 
                OnPropertyChanged(nameof(Status)); 
            } 
        }


        public void SetStartText()
        {
            Status = "started";
        }

        public void SetStopText()
        {
            Status = "Stopped";
        }
    }
}
