using BlankApp1.Services;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace BlankApp1.ViewModels
{
    public class PrismContentPage1ViewModel : BindableBase
    {
        IPrismContentPage1Services prismContentPage1Services;

        private ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public PrismContentPage1ViewModel(IPrismContentPage1Services prismContentPage1Services)
        {
            this.prismContentPage1Services = prismContentPage1Services;
            Initialize();
        }

        private async void Initialize()
        {
            Messages = new ObservableCollection<Message>(await prismContentPage1Services.GetMessagesAsync());
        }
    }
}
