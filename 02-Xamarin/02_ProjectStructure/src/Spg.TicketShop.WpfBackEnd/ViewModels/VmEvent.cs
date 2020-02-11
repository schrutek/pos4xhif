using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.Core.Eceptions;
using Spg.TicketShop.Core.Services;
using Spg.TicketShop.WpfBackEnd.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Spg.TicketShop.WpfBackEnd.ViewModels
{
    /// <summary>
    /// View-Model für die WPF-App. Stellt klassisch das Bindeglied zwischen Daten
    /// (in diesem Fall eine REST-Api) und der View (XAML) dar.
    /// </summary>
    public class VmEvent : ViewModelBase
    {
        /// <summary>
        /// Binding-Property für EMail (Username)
        /// </summary>
        public string EMail
        {
            get => _eMail;
            set { _eMail = value; OnPropertyChanged(nameof(EMail)); }
        }
        private string _eMail = "martin@schrutek.at";

        /// <summary>
        /// Binding-Property für Password
        /// </summary>
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        private string _password = "geheim";

        /// <summary>
        /// Binding-Property für IsBusy (wenn deer Service beschäftigt ist, weil z.B. ein Request länger dauert)
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); }
        }
        private bool _isBusy;



        /// <summary>
        /// Binding-Property für die Lite der anzuzeigenden Events
        /// </summary>
        public IEnumerable<EventDto> Events
        {
            get => _events;
            set { _events = value; OnPropertyChanged(nameof(Events)); }
        }
        private IEnumerable<EventDto> _events;

        /// <summary>
        /// Binding-Property für die Lite der anzuzeigenden Shows, wenn ein Event ausgewählt wurde.
        /// Siehe <see cref="Spg.TicketShop.WpfBackEnd.ViewModels.VmEvent.EventSelected"/>
        /// </summary>
        public IEnumerable<ShowDto> ShowsByEvent
        {
            get
            {
                if (RestService.Instance.CurrentUser != null)
                {
                    if (_eventSelected != new Guid())
                    {
                        Task<IEnumerable<ShowDto>> result = Task.Run<IEnumerable<ShowDto>>(async () => await RestService.Instance.GetShowsByEventAsync(_eventSelected));
                        return result.Result;
                    }
                }
                return new List<ShowDto>();
            }
        }

        /// <summary>
        /// Binding-Property für das ausgewählte Event
        /// </summary>
        public Guid EventSelected
        {
            get => _eventSelected;
            set { _eventSelected = value; OnPropertyChanged(nameof(ShowsByEvent)); }
        }
        private Guid _eventSelected;



        /// <summary>
        /// Command-Binding-Property für den Anmelden-Button
        /// </summary>
        public ICommand SignIn
        {
            get
            {
                if (_signIn == null)
                {
                    _signIn = new RelayCommand(async (parameter) => await SignInExecuted(), (parameter) => SignInCanExecute(parameter));
                }
                return _signIn;
            }
        }
        private ICommand _signIn;

        /// <summary>
        /// Command-Binding-Property für den Load-Button
        /// </summary>
        public ICommand LoadEvents
        {
            get
            {
                if (_loadEvents == null)
                {
                    _loadEvents = new RelayCommand(async (parameter) => await LoadEventsExecuted(parameter), (parameter) => LoadEventsCanExecute(parameter));
                }
                return _loadEvents;
            }
        }
        private ICommand _loadEvents;

        /// <summary>
        /// Command-Binding-Property für den Update-Button
        /// </summary>
        public ICommand UpdateItem
        {
            get
            {
                if (_updateItem == null)
                {
                    _updateItem = new RelayCommand(async (parameter) => await UpdateItemExecuted(parameter), (parameter) => UpdateItemCanExecute(parameter));
                }
                return _updateItem;
            }
        }
        private ICommand _updateItem;





        /// <summary>
        /// Command-Binding-Property ob der Sign-In-Button aktiv ist, oder nicht.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool SignInCanExecute(object parameter)
        {
            return !IsBusy;
        }

        /// <summary>
        /// Diese Methode meldet sich an der REST-Api an, und lädt anschließend (bei erfolgreicher Anmeldung) alle Events. 
        /// </summary>
        private async Task SignInExecuted()
        {
            IsBusy = true;
            try
            {
                if (await RestService.Instance.TryLoginAsync(new UserDto { EMail = _eMail, Password = _password }))
                {
                    await GetAllEventsAsync();
                }
            }
            catch (AuthenticationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            IsBusy = false;
        }

        /// <summary>
        /// Command-Binding-Property ob der Load-Button aktiv ist, oder nicht. (Nur zu Demo-Zwecken)
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool LoadEventsCanExecute(object parameter)
        {
            return !IsBusy;
        }

        /// <summary>
        /// Diese Methode lädt nur alle Events, ohne sich vorher anzumelden. (Nur zu Demo-Zwecken)
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private async Task LoadEventsExecuted(object parameter)
        {
            IsBusy = true;
            try
            {
                await GetAllEventsAsync();
            }
            catch (AuthenticationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            IsBusy = false;
        }

        /// <summary>
        /// Command-Binding-Property ob der Update-Button aktiv ist, oder nicht.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool UpdateItemCanExecute(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Die eingentliche Update-Logik. Hier ist noch nichts implementiert!
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private async Task UpdateItemExecuted(object parameter)
        {
            //TODO: Implementierung ...
            await new Task(() => { Thread.Sleep(500); });
        }


        /// <summary>
        /// Holt asynchron Event-Daten von der REST-API ab
        /// </summary>
        /// <returns></returns>
        private async Task GetAllEventsAsync()
        {
            Events = await RestService.Instance.GetAllEventsAsync();

            OnPropertyChanged(nameof(Events));
        }
    }
}
