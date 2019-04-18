using Xamarin.Forms;

namespace BlankApp1.Views
{
    public partial class PrismContentPage3 : ContentPage
    {
        public PrismContentPage3()
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
