using proxy_server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy_server.Commands
{
    public class StopCommand : CommandBase
    {
        private readonly HomeViewModel _homeViewModel;

        public StopCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }
        public override void Execute(object? parameter)
        {
            _homeViewModel.HTTPService.Stop();
            _homeViewModel.Status = "Stopped";
        }
    }
}
