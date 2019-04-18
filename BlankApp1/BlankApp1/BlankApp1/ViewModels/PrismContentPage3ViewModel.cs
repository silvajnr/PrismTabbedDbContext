using BlankApp1.Services;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace BlankApp1.ViewModels
{
    public class PrismContentPage3ViewModel : BindableBase
    {
        IPrismContentPage3Services prismContentPage3Services;

        private ObservableCollection<Chat> _chats;
        public ObservableCollection<Chat> Chats
        {
            get { return _chats; }
            set { SetProperty(ref _chats, value); }
        }

        public PrismContentPage3ViewModel(IPrismContentPage3Services prismContentPage3Services)
        {
            this.prismContentPage3Services = prismContentPage3Services;
            Initialize();
        }

        private async void Initialize()
        {
            Chats = new ObservableCollection<Chat>(await prismContentPage3Services.GetChatsWithDetailsAsync());
        }
    }
}
