using Spg.TicketShop.App.Services;
using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.Core.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spg.TicketShop.App.ViewModel
{
    /// <summary>
    /// View-Model App
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly RestService _restService;

        public MainViewModel()
        {
            SignInCommand = new Command(async () => await SignIn(), () => !IsBusy);
            _restService = DependencyService.Get<RestService>();
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;

                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }
        private string _userName = "martin@schrutek.at";

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }
        private string _password = "geheim";

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;

                OnPropertyChanged(nameof(IsBusy));
                OnPropertyChanged(nameof(DisplayMessage));

                SignInCommand.ChangeCanExecute();
            }
        }
        private bool _isBusy;

        public Command SignInCommand { get; }

        public IEnumerable<EventDto> Events
        {
            get => _events;
            set { _events = value; OnPropertyChanged(); }
        }
        private IEnumerable<EventDto> _events;

        private async Task SignIn()
        {
            IsBusy = true;

            if (await _restService.TryLoginAsync(new UserDto { EMail = _userName, Password = _password}))
            {
                Events = await _restService.GetAllEventsAsync();
                OnPropertyChanged(nameof(Events));
            }

            IsBusy = false;
        }

        public string DisplayMessage
        {
            get { return $"{UserName} - {Password} ({IsBusy})"; }
        }
    }
}
