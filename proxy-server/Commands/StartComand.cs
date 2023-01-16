using proxy_server.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy_server.Commands
{
    public class StartComand : CommandBase
    {
        private readonly HomeViewModel _homeViewModel;
        public StartComand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }
        public override void Execute(object? parameter)
        {
            _homeViewModel.HTTPService.Start();
            _homeViewModel.SetStartText();
        }

        public override bool CanExecute(object? parameter)
        {
            return _homeViewModel.IsAdressesValid && base.CanExecute(parameter);
        }


        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
          OnCanExecutedChanged();   
        }
    }
}
