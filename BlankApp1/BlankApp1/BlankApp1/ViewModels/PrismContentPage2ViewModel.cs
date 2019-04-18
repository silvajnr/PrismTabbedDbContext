using BlankApp1.Services;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace BlankApp1.ViewModels
{
    public class PrismContentPage2ViewModel : BindableBase
    {
        IPrismContentPage2Services prismContentPage2Services;

        private ObservableCollection<Chat> _chats;
        public ObservableCollection<Chat> Chats
        {
            get { return _chats; }
            set { SetProperty(ref _chats, value); }
        }

        public PrismContentPage2ViewModel(IPrismContentPage2Services prismContentPage2Services)
        {
            this.prismContentPage2Services = prismContentPage2Services;
            Initialize();
        }

        private async void Initialize()
        {
            Chats = new ObservableCollection<Chat>(await prismContentPage2Services.GetChatsAsync());
        }
    }
}
