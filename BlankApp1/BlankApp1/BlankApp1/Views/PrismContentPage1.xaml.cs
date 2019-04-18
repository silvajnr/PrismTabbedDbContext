using Xamarin.Forms;

namespace BlankApp1.Views
{
    public partial class PrismContentPage1 : ContentPage
    {
        public PrismContentPage1()
        {
            InitializeComponent();
        }

        void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MainChatListView.SelectedItem = null;
        }

        void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MainChatListView.SelectedItem = null;

        }
    }
}
